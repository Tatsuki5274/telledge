using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using telledge.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Teachers
{
	[TestClass]
	public class Teacherdelete
	{
		[TestMethod]
		public void TestDelete()
		{
			Teacher teacher = new Teacher();
			teacher.id = 1;
			bool test = teacher.delete();
			Assert.IsTrue(test);
		}
		[TestMethod]
		public void TestDeleteFailed()
		{
			Teacher teacher = new Teacher();
			teacher.id = 1;
			bool test = teacher.delete();
			Assert.IsFalse(test);
		}
	}
}
