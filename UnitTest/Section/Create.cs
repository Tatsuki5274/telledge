using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using telledge.Models;

namespace UnitTest.Sections
{
    [TestClass]
    public class SectionCreate
    {
        [TestMethod]
        public void ValuationNullSuccess()
        {
            Section section = new Section();
            section.roomId = 1;
            section.studentId = 1;
            section.request = "リクエスト";
            section.valuation = null;
            section.beginTime = DateTime.Parse("2010-01-10 10:30:00.000");
            section.talkTime = 50;
            bool test = section.create();
            Assert.IsTrue(test);
        }
        [TestMethod]
        public void ValuationNotNullSuccess()
        {
            Section section = new Section();
            section.roomId = 1;
            section.studentId = 2;
            section.request = "リクエスト";
            section.valuation = 4;
            section.beginTime = DateTime.Parse("2010-01-10 10:30:00.000");
            section.talkTime = 50;
            bool test = section.create();
            Assert.IsTrue(test);
        }
        [TestMethod]
        public void Failed()
        {
            Section section = new Section();
            section.roomId = 1;
            section.valuation = 4;
            section.order = 1;
            section.beginTime = DateTime.Parse("2010-01-10 10:30:00.000");
            section.talkTime = 50;
            bool test = section.create();
            Assert.IsFalse(test);
        }
    }
}
