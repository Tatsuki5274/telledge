using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using telledge.Models;

namespace telledge.Controllers.Students
{
    public class HomesController : Controller
    {
        // GET: Homes
        public ActionResult Index()
        {
            return View();
        }
		[HttpGet]
		public ActionResult edit()
		{
			return View("/Views/Students/Homes/edit.cshtml");
		}
		public ActionResult update(String mailaddress,String name,String imagePath,String skypeId)
		{
			Student student = Student.currentUser();
			if(mailaddress != "")//入力してあれば、引数をデータを保持する。
			{
				student.mailaddress = mailaddress;
			}
			if(name != "")//入力してあれば、引数をデータを保持する。
			{
				student.name = name;
			}
			if(imagePath != "")//入力してあれば、引数をデータを保持する。
			{
				student.profileImage = imagePath;
			}
			if(skypeId != "")//入力してあれば、引数をデータを保持する。
			{
				student.skypeId = skypeId;
			}
			bool check = student.Update();
			if(check == true)
			{
				return RedirectToRoute("Student", new { controller = "Homes", Action = "mypage"});
			}
			else
			{
				return View("/Views/Students/Homes/edit.cshtml");
			}
		}
    }
}