using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace telledge.Controllers.Teachers
{
    public class RoomsController : Controller
    {
        // GET: Rooms
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("//Create");

        }
        [HttpGet]
        public ActionResult Call(int roomid)
        {

        }
        [HttpGet]
        public ActionResult Index()
        {
            return View("");
        }
    }
}