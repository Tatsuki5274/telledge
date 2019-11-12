using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace telledge.Models
{
    public class Student : Controller
    {
        public int id { get; set; }
        public String name { get; set;}
        public String mailaddress { get; set; }
        public String skypeId { get; set; }
        public int passwordDigest { get; set; }
        public bool is2FA { get; set; }
        public int point { get; set; }
        public DateTime inactiveDate {get; set;}
    }
}
