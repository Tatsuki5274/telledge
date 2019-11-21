using Microsoft.VisualStudio.TestTools.UnitTesting;
using telledge.Models;

namespace telledge.Tests.Models
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void SetPassWordTest()
        {
            Student student = new Student();
            student.setPassword("password");
        }
    }
}
