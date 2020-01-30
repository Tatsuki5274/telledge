using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using telledge.Models;

namespace UnitTest.Rooms
{
    [TestClass]
    public class update
    {
        [TestMethod]
        public void success()
        {
            Room room = new Room();
            room.id = 16;
			room.teacherId = 1;
			room.roomName = "AAA";
			room.tag = "tag";
			room.description = "AAAAAAA";
			room.worstTime = 20;
			room.extensionTime = 20;
			room.point = 20;
			room.beginTime = DateTime.Now;
			room.endScheduleTime = DateTime.Now;
			bool check = room.update();
			Assert.IsTrue(check);
        }
		[TestMethod]
		public void failed()
		{
			Room room = new Room();
			room.id = 999;
			room.teacherId = 1;
			room.roomName = "AAA";
			room.tag = "tag";
			room.description = "AAAAAAA";
			room.worstTime = 20;
			room.extensionTime = 20;
			room.point = 20;
			room.beginTime = DateTime.Now;
			room.endScheduleTime = DateTime.Now;
			bool check = room.update();
			Assert.IsFalse(check);
		}
	}
}
