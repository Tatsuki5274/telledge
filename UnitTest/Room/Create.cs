using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using telledge.Models;

namespace UnitTest.Rooms
{
    [TestClass]
    public class RoomCreate
    {
        [TestMethod]
        public void TestCreate()
        {
            Room room = new Room();
            room.teacherId = 1;
            room.roomName = "楽しい英語";
            room.tag = "English,Japan";
            room.description = "Description";
            room.worstTime = 40;
            room.extensionTime = 60;
            room.point = 2000;
            room.endScheduleTime = DateTime.Parse("2010-01-10 10:30:00.000");
            room.beginTime = DateTime.Parse("2010-01-10 10:30:00.000");
            bool test = room.create();
            Assert.IsTrue(test);
        }
        [TestMethod]
        public void TestCreateFailed()
        {
            Room room = new Room();
            room.teacherId = 1;
            room.roomName = "楽しい英語";
            room.worstTime = 40;
            room.extensionTime = 60;
            room.point = 2000;
            room.endScheduleTime = DateTime.Parse("2010-01-10 10:30:00.000");
            room.beginTime = DateTime.Parse("2010-01-10 10:30:00.000");
            bool test = room.create();
            Assert.IsFalse(test);
        }
    }
}
