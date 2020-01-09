using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using telledge.Models;

namespace telledge.Controllers.Students
{
    public class TeachersController : Controller
    {
        // GET: Teachers
        public ActionResult Index()
        {
			var model = Teacher.getAll();
			return View("/Views/Students/Teachers/index.cshtml", model);
		}

		public ActionResult Show(int id)
		{
			var model = Teacher.find(id);
			return View("/Views/Students/Teachers/show.cshtml", model);
		}

    }
}