using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace telledge.Controllers.Teachers
{
    public class RegistrationsController : Controller
    {
		// GET: Registrations
		public ActionResult deactivate()
		{
			return View("/Views/Teachers/Registrations/deactivate.cshtml");
		}
	}
}