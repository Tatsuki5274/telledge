using telledge.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Teachers
{
	[TestClass]
	class isDeleted
	{
		[TestMethod]
		public void TestisDeleted()
		{
			Teacher teacher = new Teacher();
			teacher.inactiveDate = null;
			bool test = teacher.isDeleted();
			Assert.IsFalse(test);
		}
	}
}
