using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using telledge.Models;

namespace telledge.Controllers.Teachers
{
    public class RoomsController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View("/Views/Teachers/Rooms/Create.cshtml");


		}
        public ActionResult index()
        {
            var model = Room.getRooms();
            return View("/Views/Teachers/Rooms/index.cshtml", model);
        }
		public ActionResult call(int id)
		{
			var model = Room.find(id);
			return View("/Views/Teachers/Rooms/call.cshtml", model);
        }
		[HttpPost]
		public ActionResult Create(String roomName,String tag,String description,int? worstTime,int? extensionTime,int? point,DateTime? endScheduleTime)
		{
			Room room = new Room();
			room.teacherId = Teacher.currentUser().id;
			room.roomName = roomName;
			room.tag = tag;
			room.description = description;
			room.beginTime = DateTime.Now;
			room.endTime = null;
			try
			{
				room.worstTime = worstTime.Value;
				room.extensionTime = extensionTime.Value;
				room.point = point.Value;
				room.endScheduleTime = endScheduleTime.Value;
			}
			catch (InvalidOperationException)
			{
				ViewBag.ErrorMsg = "必須項目を入力してください。また、最低保障時間、最大延長時間、ポイントは数字を入力してください。";
				return View("/Views/Teachers/Rooms/create.cshtml");
			}
			
			int ret = room.create();
			if(ret != 0)
			{
				return RedirectToRoute("Teacher", new { controller = "Rooms", Action = "call" , id = ret });
			}else
			{
				ViewBag.ErrorMsg = "必須項目を入力してください。また、最低保障時間、最大延長時間、ポイントは数字を入力してください。";
				return View("/Views/Teachers/Sessions/create.cshtml");
			}
		}
		public ActionResult delete(int id)
		{
			Room room = Room.find(id);
			room.id = id;
			Section[] sections = room.getSections();
			if (sections != null)
			{
				foreach (Section section in sections)
				{
					if (section.talkTime == null)
						section.delete();
				}
			}
			room.close();
			room.update();
			return View("/Views/Teachers/Homes/mypage.cshtml", Teacher.currentUser());
		}
		[HttpGet]
		public ActionResult show(int roomid)
		{
			var model = Room.find(roomid);
			return View("/Views/Teachers/Rooms/call.cshtml", model);
		}
	}
}