using System;
using telledge.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Students
{
	[TestClass]
	public class isDeleted
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
