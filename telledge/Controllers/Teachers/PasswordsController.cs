using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using telledge.Models;

namespace telledge.Controllers.Teachers
{
    public class PasswordsController : Controller
    {
        // GET: Passwords
        public ActionResult Index()
        {
            return View();
        }
		[HttpGet]
		public ActionResult edit()
		{
			return View("/Views/Teachers/Passwords/edit.cshtml");
		}
		[HttpPost]
		public ActionResult update(String oldPassword, String createPassword, String ConfirmationPassword)
		{
			Teacher teacher = Teacher.currentUser();
			if (createPassword == ConfirmationPassword && createPassword != "")
			{
				if(teacher.changePassword(oldPassword, createPassword) == true)
				{
					teacher.Update();
					return RedirectToRoute("Teacher", new { controller = "Sessions", Action = "create" });
				}
			}
			return View("/Views/Teachers/Passwords/edit.cshtml");
		}
	}
}