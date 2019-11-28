using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using telledge.Models;

namespace UnitTest.Rooms
{
    [TestClass]
    public class getTeacher
    {
        [TestMethod]
        public void success()
        {
            Room room = new Room();
            room.teacherId = 1;
            Teacher teacher = room.getTeacher();
            Assert.IsNotNull(teacher);
            Assert.AreSame(teacher, room.getTeacher());
        }
    }
}
