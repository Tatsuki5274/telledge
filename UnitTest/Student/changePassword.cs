using Microsoft.VisualStudio.TestTools.UnitTesting;
using telledge.Models;

namespace UnitTest.Students
{
    [TestClass]
    public class StudentchangePassword
    {
        [TestMethod]
        public void TestchengePassword()
        {
            Student student = new Student();
			student.id = 2;
			student.setPassword("password");
			bool test = student.changePassword("password", "newpass");
            Assert.IsTrue(test);
        }
        [TestMethod]
        public void TestchengePasswordFailed()
        {
			Student student = new Student();
			student.id = 2;
			student.setPassword("password");
			bool test = student.changePassword("pappappa", "newpass");
			Assert.IsFalse(test);
        }
    }
}
