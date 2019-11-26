using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using telledge.Models;

namespace telledge.Controllers.Teachers
{
    public class SessionsController : Controller
    {
        // GET: Sessions
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(String mailaddress, String password)
        {
            Teacher ret = Teacher.login(mailaddress, password);
            if (ret != null)
            {
                RedirectToAction("Index", "Rooms");
            }
            return View("new");

        }
    }
}