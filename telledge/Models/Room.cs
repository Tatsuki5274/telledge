using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace telledge.Models
{
    public class Room : Controller
    {
        public int id { set; get; }
        public int teacherId { set; get;}
        public String roomName { set; get; }
        public String tag { get; set; }
        public String description { get; set; }
        public int worstTime { get; set; }
        public int extensionTime { get; set; }
        public int point { get; set; }
        public DateTime beginTime { get; set; }
        public DateTime endTime { get; set; }

    }
}
