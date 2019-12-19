using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using telledge.Models;

namespace UnitTest.Students
{
    [TestClass]
    public class StudentUpdate
    {
        [TestMethod]
        public void TestUpdate()
        {
            Student student = new Student();
			student.id = 1;
            student.name = "test";
            student.mailaddress = "mailaddress";
            student.setPassword("password");
            student.is2FA = true;
            student.point = 0;
            student.profileImage = "kfswaoefa.pix";
            student.skypeId = "Tests@skypeid";
			student.inactiveDate = null;
			bool test = student.Update();
            Assert.IsTrue(test);
        }
        [TestMethod]
        public void TestUpdateFailed()
        {
			Student student = new Student();
			student.id = 16;
			student.name = "TestS";
			student.mailaddress = "AOARO@jec.ac.jp";
			student.profileImage = "kfswaoefa.pix";
			student.skypeId = "Tests@skypeid";
			student.inactiveDate = null;
			bool test = student.Update();
			Assert.IsFalse(test);
        }
    }
}
