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
		[HttpGet]
		public ActionResult create()
		{
			return View("/Views/Teachers/Registrations/create.cshtml");
		}
		[HttpPost]
		public ActionResult create(String name,String mailaddress,String password,String passwordConfirmation,String imagePath)
		{
			if(password != "" && passwordConfirmation != "")//空文字で登録できないようにする
			{
				if(password == passwordConfirmation)//パスワードと確認用パスワードの一致
				{
					Teacher teacher = new Teacher();
					teacher.name = name;
					teacher.mailaddress = mailaddress;
					teacher.setPassword(password);//パスワードダイジェスト化
					teacher.profileImage = imagePath;
					teacher.language = DBNull.Value.ToString();
					teacher.intoroduction = DBNull.Value.ToString();
					teacher.address = DBNull.Value.ToString();
					teacher.nationality = DBNull.Value.ToString();
					teacher.create();
					return View("/Views/Teachers/Registrations/top.cshtml");
				}
			}
			return View("/Views/Teachers/Registrations/create.cshtml");
		}
	}
}