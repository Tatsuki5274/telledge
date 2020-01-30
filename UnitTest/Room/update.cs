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
			bool check = room.update();
			Assert.IsTrue(check);
        }
		[TestMethod]
		public void failed()
		{
			Room room = new Room();
			room.id = 999;
			bool check = room.update();
			Assert.IsFalse(check);
		}
	}
}
