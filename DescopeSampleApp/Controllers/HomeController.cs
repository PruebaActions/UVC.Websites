using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DescopeSampleApp.Controllers
{
    public class HomeController : Controller
    {
    //adasasdadsadsa
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
