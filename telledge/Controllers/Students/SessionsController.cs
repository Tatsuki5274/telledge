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
            return View("/Views/Students/Sessions/create.cshtml");
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
                return RedirectToAction("Index", "Rooms");
            }
            return View("new");

        }
        [HttpDelete]
        public ActionResult Delete()
        {
            Student.logout();
            return RedirectToAction("index", "student/rooms");
        }
    }
}