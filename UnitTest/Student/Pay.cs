using Microsoft.VisualStudio.TestTools.UnitTesting;
using telledge.Models;

namespace UnitTest.Students
{
	[TestClass]
	public class Pay
	{
		[TestMethod]
		public void TestPay()
		{
			Student student = new Student();
			student.point = 100;
			bool test = student.Pay(50);
			Assert.IsTrue(test);
 		}
	}
}
