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
			ViewBag.signInPath = "/student/sessions/create";
			ViewBag.signUpPath = "/student/registrations/create";
			ViewBag.pageTitle = "生徒用ログイン画面";
			return View("/Views/Shared/signin.cshtml");
        }

        [HttpPost]
        public ActionResult Create(String mailaddress, String password)
        {
			if (Student.login(mailaddress, password) != null)
			{
				return RedirectToAction("Index", "Rooms");
			}
			ViewBag.signInPath = "/student/sessions/create";
			ViewBag.signUpPath = "/student/registrations/create";
			ViewBag.pageTitle = "生徒用ログイン画面";
			ViewBag.ErrorMessage = "メールアドレスかパスワードが一致しませんでした";
			return View("/Views/Shared/signin.cshtml");

		}
		[HttpPost]
        public ActionResult Delete()
        {
            Student.logout();
            return RedirectToAction("index", "student/rooms");
        }
    }
}