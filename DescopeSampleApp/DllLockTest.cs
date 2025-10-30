using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace DescopeSampleApp
{
    public static class DllLockTest
    {
        private static Thread _backgroundThread;
        private static bool _running = false;

        public static void StartLock()
        {
            if (_running) return;
            _running = true;

            _backgroundThread = new Thread(() =>
            {
                try
                {
                    string dllPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", "DescopeSampleApp.dll");
                    while (_running)
                    {
                        // 🔒 Abrir la DLL en modo exclusivo (bloquea escritura)
                        using (FileStream fs = new FileStream(dllPath, FileMode.Open, FileAccess.Read, FileShare.None))
                        {
                            Thread.Sleep(2000); // Mantener el bloqueo 2 segundos
                        }

                        // Esperar un poco y repetir
                        Thread.Sleep(1000);
                    }
                }
                catch (Exception ex)
                {
                    File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "lock_log.txt"), ex.ToString());
                }
            });

            _backgroundThread.IsBackground = true;
            _backgroundThread.Start();
        }

        public static void StopLock()
        {
            _running = false;
        }
    }
}
