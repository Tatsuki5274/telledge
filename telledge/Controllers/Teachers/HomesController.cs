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

		[HttpPost]
		public ActionResult update(String imagePath ,String mailaddress ,String name, String nationality, int sex, String intoroduction)
		{
			Teacher teacher = Teacher.currentUser();
			if (teacher != null)
			{
				if (mailaddress != "") teacher.mailaddress = mailaddress;
				if (name != "") teacher.name = name;
				if (nationality != "") teacher.nationality = nationality;
				if (intoroduction != "") teacher.intoroduction = intoroduction;
				teacher.sex = sex;

				if (teacher.Update())
				{
					//正常系
					return RedirectToRoute("teacher", new { controller = "homes", action = "mypage" });
				}
				else
				{
					//異常系
					return RedirectToRoute("teacher", new { controller = "homes", action = "mypage" });
				}
			}
			//ログインしていない場合にする処理
			return RedirectToRoute("teacher", new { controller = "sessions", action = "create" });

		}

		public ActionResult edit()
		{
			return View("/Views/Teachers/Homes/edit.cshtml");
		}
    }
}