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

        [HttpPost]
        public ActionResult Create(String mailaddress, String password)
        {
			if (Student.login(mailaddress, password) != null)
			{
				return RedirectToAction("Index", "Rooms");
			}
			ViewBag.ErrorMessage = "メールアドレスかパスワードが一致しませんでした";
			return View("/Views/Students/Sessions/create.cshtml");

        }
        [HttpPost]
        public ActionResult Delete()
        {
            Student.logout();
            return RedirectToAction("index", "student/rooms");
        }
    }
}