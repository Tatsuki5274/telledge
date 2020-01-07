using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using telledge.Models;

namespace telledge.Controllers.Students
{
    public class PasswordsController : Controller
    {
        // GET: Passwords
        public ActionResult Index()
        {
            return View();
        }
		[HttpGet]
		public ActionResult edit()
		{
			return View("/Views/Students/Passwords/edit.cshtml");
		}
		[HttpPost]
		public ActionResult update(String oldPassword,String createPassword,String ConfirmationPassword)
		{
			Student student = Student.currentUser();
			if(createPassword == ConfirmationPassword && createPassword != "")
			{
				if (student.changePassword(oldPassword, createPassword) == true)
				{
					student.Update();
					return RedirectToRoute("Student", new { controller = "Sessions", Action = "create" });
				}
			}
			return View("/Views/Students/Passwords/edit.cshtml");
		}
		[HttpGet]
		public ActionResult create()
		{
			return View("/Views/Students/Passwords/create.cshtml");
		}
		[HttpPost]
		public ActionResult create(String mailaddress)
		{

			String pass = System.Web.Security.Membership.GeneratePassword(1,0); //復旧用パスワード自動生成
			Teacher teacher = new Teacher();
			teacher.setPassword(pass);
			
			return RedirectToRoute("Student", new { controller = "Homes", Action = "mypage" });
		}
    }
}