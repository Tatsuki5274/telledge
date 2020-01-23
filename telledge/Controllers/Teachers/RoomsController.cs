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
		public ActionResult Create(String roomName,String tag,String description,int worstTime,int extensionTime,int point,DateTime endScheduleTime)
		{
			Room room = new Room();
			room.teacherId = Teacher.currentUser().id;
			room.roomName = roomName;
			room.tag = tag;
			room.description = description;
			room.worstTime = worstTime;
			room.extensionTime = extensionTime;
			room.point = point;
			room.endScheduleTime = endScheduleTime;
			room.beginTime = DateTime.Now;
			room.endTime = null;
			
			int ret = room.create();
			if(ret != 0)
			{
				return RedirectToRoute("Teacher", new { controller = "Rooms", Action = "call" , id = ret });
			}else
			{
				return View("/Views/Teachers/Sessions/create.cshtml");
			}
		}
		public ActionResult delete(int roomId)
		{
			Room room = new Room();
			room.id = roomId;
			Section[] section = room.getSections();
			for (int i = 0; i < section.Length; i++)
			{
				if (section[i].talkTime == null)
				{
					section[i].delete();
				}
			}
			room.close();
			return View("/Views/Teachers/Homes/mypage.cshtml");
		}
		[HttpGet]
		public ActionResult show(int roomid)
		{
			var model = Room.find(roomid);
			return View("/Views/Teachers/Rooms/call.cshtml", model);
		}
	}
}