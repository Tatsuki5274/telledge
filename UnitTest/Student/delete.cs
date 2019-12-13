using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using telledge.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Students
{
	[TestClass]
	public class Delete
	{
		[TestMethod]
		public void TestCreate()
		{
			Student student = new Student();
			student.id = 1;
			bool test = student.delete();
			Assert.IsTrue(test);
		}
		[TestMethod]
		public void TestCreateFailed()
		{
			Student student = new Student();
			student.id = 1;
			bool test = student.delete();
			Assert.IsFalse(test);
		}
	}
}
