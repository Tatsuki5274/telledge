using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using telledge.Models;

namespace UnitTest.Rooms
{
    [TestClass]
    public class RoomGetSection
    {
        [TestMethod]
        public void GetSection()
        {
            Room room = new Room();
			room.id = 1;
			Section seciton = room.getSection();
            Assert.IsNotNull(seciton);
        }
		[TestMethod]
		public void GetSectionFailed()
		{
			Room room = new Room();
			room.id = 3;
			Section seciton = room.getSection();
			Assert.IsNull(seciton);
		}
	}
}
