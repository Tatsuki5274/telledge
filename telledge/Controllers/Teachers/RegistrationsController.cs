using System;
using System.Collections.Generic;
using System.IO;
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
		public ActionResult create(String name,String mailaddress,String password,String passwordConfirmation,HttpPostedFileWrapper imagePath)
		{
			if(password != "" && passwordConfirmation != "")//空文字で登録できないようにする
			{
				if(password == passwordConfirmation)//パスワードと確認用パスワードの一致
				{
					Teacher teacher = new Teacher();
					teacher.name = name;
					teacher.mailaddress = mailaddress;
					teacher.setPassword(password);//パスワードダイジェスト化
					if (imagePath != null)
					{
						imagePath.SaveAs(Server.MapPath(@"/uproadFiles/") + Path.GetFileName(imagePath.FileName));
						teacher.profileImage = Path.GetFileName(imagePath.FileName);
					}	
					teacher.language = DBNull.Value.ToString();
					teacher.intoroduction = DBNull.Value.ToString();
					teacher.address = DBNull.Value.ToString();
					teacher.nationality = DBNull.Value.ToString();
					teacher.create();
					Teacher.login(mailaddress,password);
					return View("/Views/Teachers/Homes/mypage.cshtml",Teacher.currentUser());
				}
			}
			return View("/Views/Teachers/Registrations/create.cshtml");
		}
	}
}