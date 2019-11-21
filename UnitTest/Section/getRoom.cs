using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using telledge.Models;

namespace UnitTest.Sections
{
    [TestClass]
    public class getRoom
    {
        [TestMethod]
        public void Success()
        {
            Section section = new Section();
            section.roomId = 1;
            Room room = section.getRoom();
            Assert.IsNotNull(room);
        }
        public void failed()
        {
            Section section = new Section();
            Room room = section.getRoom();
            Assert.IsNull(room);
        }
    }
}
