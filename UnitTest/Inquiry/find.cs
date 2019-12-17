using telledge.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Inquirys
{
	[TestClass]
	public class find
	{
		[TestMethod]
		public void success()
		{
			Inquiry inquiry = Inquiry.find(6);
			Assert.IsNotNull(inquiry);
		}
	}
}
