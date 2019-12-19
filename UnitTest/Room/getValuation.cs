using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using telledge.Models;

namespace UnitTest.Rooms
{
    [TestClass]
    public class RoomgetValuation
    {
        [TestMethod]
        public void getValuation()
        {
            Room room = new Room();
            room.id = 1;
            double valuation = room.getValuation();
            Assert.AreNotEqual(0, valuation);
        }
        [TestMethod]
        public void getValuationFailed()
        {
			Room room = new Room();
			room.id = 9999;
			double valuation = room.getValuation();
			Assert.AreEqual(-1,valuation);
		}
    }
}
