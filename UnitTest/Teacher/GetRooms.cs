using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using telledge.Models;  //プロジェクトのテスト対象

namespace UnitTest.Teachers
{
    [TestClass]
    public class TeacherGetRooms
    {
        [TestMethod]
        public void TestGetRooms()
        {
			Teacher teacher = new Teacher();
			teacher.id = 1;
            Room[] test = teacher.getRooms();
            Assert.IsNotNull(test);
        }
        [TestMethod]
        public void TestGetRoomsFailed()
        {
			Teacher teacher = new Teacher();
			teacher.id = 999;
			Room[] test = teacher.getRooms();
			Assert.IsNull(test);
		}
    }
}
