using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using telledge.Models;

namespace UnitTest.Sections
{
    [TestClass]
    public class SectionDeleteAsInstanceMethod
    {
        [TestMethod]
        public void Success()
        {
            Section section = new Section();
            section.roomId = 1;
            section.studentId = 1;
            bool test = section.delete();
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void studentIdfailed()
        {
            Section section = new Section();
            section.roomId = 1;
            section.studentId = 100;
            bool test = section.delete();
            Assert.IsFalse(test);
        }
        [TestMethod]
        public void roomIdfailed()
        {
            Section section = new Section();
            section.roomId = 100;
            section.studentId = 1;
            bool test = section.delete();
            Assert.IsFalse(test);
        }
    }
	[TestClass]
	public class SectionDeleteAsClassMethod
	{
		[TestMethod]
		public void SuccessByRoomId()
		{
			Assert.IsTrue(Section.delete(1, Section.KeyTarget.roomId));
		}
		[TestMethod]
		public void SuccessByStudentId()
		{
			Assert.IsTrue(Section.delete(1, Section.KeyTarget.studentId));
		}
	}
}
