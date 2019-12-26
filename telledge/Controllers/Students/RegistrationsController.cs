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
		[HttpPost]
		public ActionResult create(String mailaddress,String password,String passwordConfirmation)
		{		
			if(password != "" && passwordConfirmation != "")//空文字で登録できないようにする
			{
				if(password == passwordConfirmation)//パスワードと確認用パスワードの一致
				{
					Student student = new Student();
					student.setPassword(password);//パスワードダイジェスト化
					student.mailaddress = mailaddress;
					student.skypeId = ""; //nullが自動で入ってしまう為、空文字を代入
					student.name = DBNull.Value.ToString();
					student.profileImage = DBNull.Value.ToString();
					student.create();
					return View("/Views/Students/Registrations/top.cshtml");
				}
			}
			return View("/Views/Students/Registrations/create.cshtml");
		}
		[HttpGet]
		public ActionResult create()
		{
			return View("/Views/Students/Registrations/create.cshtml");
		}
	}
}