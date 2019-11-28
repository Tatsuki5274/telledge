using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using telledge.Models;

namespace UnitTest.Rooms
{
    [TestClass]
    public class find
    {
        [TestMethod]
        public void success()
        {
            Room room = Room.find(1);
            Assert.IsNotNull(room);
        }
    }
}
