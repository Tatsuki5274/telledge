using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using telledge.Models;

namespace telledge.Controllers.Students
{
    public class PointsController : Controller
    {
        // GET: Points
        public ActionResult Index()
        {
            return View();
        }
		[HttpGet]
		public ActionResult create()
		{
			return View("/Views/Students/points/create.cshtml");
		}
		[HttpPost]
		public ActionResult create(int selectedPoint)
		{
			Student student = Student.currentUser();
			student.point += selectedPoint;
			student.Update();
			return RedirectToRoute("Student", new { controller = "Homes", Action = "mypage" });
		}
    }
}