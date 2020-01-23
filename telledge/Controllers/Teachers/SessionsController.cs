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
            return View("/Views/Teachers/Sessions/create.cshtml");
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
			ViewBag.ErrorMessage = "メールアドレスかパスワードが一致しませんでした";
			return View("/Views/Teachers/Sessions/create.cshtml");

        }
        [HttpDelete]
        public ActionResult Delete()
        {
            Teacher.logout();
            return RedirectToAction("index", "teacher/rooms");
        }
    }
}