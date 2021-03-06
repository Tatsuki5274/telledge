using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using telledge.Models;

namespace telledge.Controllers.Students
{
    public class RoomsController : Controller
    {
        //
        // GET: /Rooms/

        public ActionResult Index()
        {
            var model = Room.getRooms();
            return View("/Views/Students/Rooms/index.cshtml", model);
        }
        public ActionResult Show(int id)
        {
            var model = Room.find(id);
            return View("/Views/Students/Rooms/show.cshtml", model);
        }

        //
        // GET: /Rooms/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult call(int id)
        {
			if (Student.currentUser() == null) return RedirectToRoute("Student", new { controller = "Sessions", action = "Create" });
            var model = Room.find(id);
            return View("/Views/Students/Rooms/call.cshtml", model);
        }
        //
        // GET: /Rooms/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Rooms/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Rooms/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Rooms/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Rooms/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Rooms/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
		[HttpPost]
		public ActionResult join(int id, string request)
		{
			if (Student.currentUser() == null) return RedirectToAction("create", "sessions");
			Section section = new Section();
			section.roomId = id;
			section.studentId = Student.currentUser().id;
			section.request = request;
			section.beginTime = DateTime.Now;
			section.create();
			return RedirectToAction("call", "rooms", new { Id = Convert.ToInt32(id) });
		}

		[HttpGet]
		public ActionResult leave(int id)
		{
			//ルームから退出する処理
			if (Student.currentUser() == null) return RedirectToAction("create", "sessions");
			Section section = new Section();
			section.roomId = id;
			section.studentId = Student.currentUser().id;
			section.delete();
			return RedirectToAction("index", "rooms");
		}
		[HttpPost]
		public ActionResult end(int id, int score)
		{
			if (Student.currentUser() == null) return RedirectToAction("create", "sessions");
			Section section = Section.find(id, Student.currentUser().id);
			TimeSpan span = DateTime.Now - section.beginTime;
			section.talkTime = span.Minutes + span.Hours * 60;
			section.valuation = score;
			section.update();
			return RedirectToAction("index", "rooms");
		}
	}
}
