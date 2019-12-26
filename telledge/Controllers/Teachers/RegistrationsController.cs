using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using telledge.Models;

namespace telledge.Controllers.Teachers
{
    public class RegistrationsController : Controller
    {
		// GET: Registrations
		public ActionResult deactivate()
		{
			if (Teacher.currentUser() == null) return RedirectToRoute("Teacher", new { controller = "Sessions", Action = "create" });
			return View("/Views/Teachers/Registrations/deactivate.cshtml");
		}

		[HttpPost]
		public ActionResult delete()
		{
			if (Teacher.currentUser() == null) return RedirectToRoute("Teacher", new { controller = "Sessions", Action = "create" });
			Teacher.currentUser().delete();
			Teacher.logout();
			return RedirectToAction("top", "Homes");
		}
	}
}