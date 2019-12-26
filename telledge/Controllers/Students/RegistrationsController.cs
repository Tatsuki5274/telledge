using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using telledge.Models;

namespace telledge.Controllers.Students
{
    public class RegistrationsController : Controller
    {
        // GET: Registrations
        public ActionResult deactivate()
        {
			if (Student.currentUser() == null) return RedirectToRoute("Student", new { controller = "Sessions", Action = "create" });
			return View("/Views/Students/Registrations/deactivate.cshtml");
		}

		[HttpPost]
		public ActionResult delete()
		{
			if (Student.currentUser() == null) return RedirectToRoute("Student", new { controller = "Sessions", Action = "create" });
			Student.currentUser().delete();
			Student.logout();
			return RedirectToAction("top", "Homes");
		}
	}
}