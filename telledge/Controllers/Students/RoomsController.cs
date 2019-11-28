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

        //
        // GET: /Rooms/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult call(int id)
        {
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
    }
}
