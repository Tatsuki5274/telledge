using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using telledge.Models;

namespace telledge.Controllers.Teachers
{
    public class HomesController : Controller
    {
        // GET: Homes
        public ActionResult mypage()
        {
			if (Teacher.currentUser() == null) return RedirectToRoute("Teacher", new { controller = "Sessions", Action = "create" });
            return View("/Views/Teachers/Homes/mypage.cshtml", Teacher.currentUser());

		}
    }
}