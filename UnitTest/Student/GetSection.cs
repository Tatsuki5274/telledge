using Microsoft.VisualStudio.TestTools.UnitTesting;
using telledge.Models;

namespace UnitTest.Students
{
    [TestClass]
    public class StudentGetSection
    {
        [TestMethod]
        public void TestGetSection()
        {
            Student student = new Student();
			student.id = 1;
            Section[] section = student.GetSection();
            Assert.IsNotNull(section);
        }
        [TestMethod]
        public void TestGetSectionFailed()
        {
			Student student = new Student();
			student.id = 999;
			Section[] section = student.GetSection();
			Assert.IsNull(section);
		}
    }
}
