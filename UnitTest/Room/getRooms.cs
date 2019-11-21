using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using telledge.Models;

namespace UnitTest.Rooms
{
    [TestClass]
    public class getRooms
    {
        [TestMethod]
        public void Success()
        {
            Room[] rooms = Room.getRooms();
            Assert.IsNotNull(rooms);
        }
    }
}
