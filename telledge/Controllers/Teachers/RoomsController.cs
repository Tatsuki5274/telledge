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
	}
}