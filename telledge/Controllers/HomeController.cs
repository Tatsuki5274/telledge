using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace telledge.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "ASP.NET MVC へようこそ";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
