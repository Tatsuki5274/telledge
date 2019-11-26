using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using telledge.Models;

namespace telledge.Controllers.Students
{
    public class SessionsController : Controller
    {
        // GET: Sessions
        public ActionResult Create()
        {
            return View("Create");
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(String mailaddress, String password)
        {
            Student ret = Student.login(mailaddress, password);
            if(ret != null)
            {
                RedirectToAction("Index", "Rooms");
            }
            return View("new");

        }
    }
}