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
        public ActionResult Create()
        {
			ViewBag.signInPath = "/teacher/sessions/create";
			ViewBag.signUpPath = "/teacher/registrations/create";
			ViewBag.pageTitle = "講師用ログイン画面";
			ViewBag.ForgetPath = "/teacher/passwords/create";
			return View("/Views/Shared/signin.cshtml");
		}
		public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(String mailaddress, String password)
        {
			if (Teacher.login(mailaddress, password)!=null)
			{
				return RedirectToRoute("Teacher", new { controller = "Rooms", Action = "Index" });
			}
			ViewBag.signInPath = "/teacher/sessions/create";
			ViewBag.signUpPath = "/teacher/registrations/create";
			ViewBag.pageTitle = "講師用ログイン画面";
			ViewBag.ForgetPath = "/teacher/passwords/create";
			ViewBag.ErrorMessage = "メールアドレスかパスワードが一致しませんでした";
			return View("/Views/Shared/signin.cshtml");

		}
		[HttpDelete]
        public ActionResult Delete()
        {
            Teacher.logout();
            return RedirectToAction("index", "teacher/rooms");
        }
    }
}