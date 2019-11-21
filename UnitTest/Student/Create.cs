using Microsoft.VisualStudio.TestTools.UnitTesting;
using telledge.Models;

namespace telledge.Tests.Models
{
    [TestClass]
    public class StudentCreate
    {
        [TestMethod]
        public void TestCreate()
        {
            Student student = new Student();
            student.name = "Test";
            student.mailaddress = "OARO@jec.ac.jp";
            student.setPassword("password");
            student.is2FA = false;
            student.point = 0;
            student.profileImage = "kfwaoefa.pix";
            student.skypeId = "Test@skypeid";
            student.inactiveDate = null;
            bool test = student.create();
            Assert.IsTrue(test);
        }
        [TestMethod]
        public void TestCreateFailed()
        {
            Student student = new Student();
            student.name = "Test";
            student.mailaddress = "OARO@jec.ac.jp";
            student.is2FA = false;
            student.point = 0;
            student.profileImage = "Gafeokfwaoefa.pix";
            bool test = student.create();
            Assert.IsFalse(test);
        }
    }
}
