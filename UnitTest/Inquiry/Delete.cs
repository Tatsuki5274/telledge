using telledge.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Inquirys
{
	[TestClass]
	public class Inquerydelete
	{
		[TestMethod]
		public void TestDelete()
		{
			Inquiry inquiry = new Inquiry();
			inquiry.id = 1;
			bool test = inquiry.delete();
			Assert.IsTrue(test);
		}
		[TestMethod]
		public void TestDeleteFailed()
		{
			Inquiry inquiry = new Inquiry();
			inquiry.id = 1;
			bool test = inquiry.delete();
			Assert.IsFalse(test);
		}
	}
}
