using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using telledge.Models;

namespace UnitTest.Sections
{
    [TestClass]
    public class getStudent
    {
        [TestMethod]
        public void Success()
        {
            Section section = new Section();
            section.studentId= 1;
            Student student = section.getStudent();
            Assert.IsNotNull(student);
        }
        [TestMethod]
        public void failed()
        {
            Section section = new Section();
            Student student = section.getStudent();
            Assert.IsNull(student);
        }
    }
}
