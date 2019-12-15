using telledge.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.FAQs
{
	[TestClass]
	public class Faqdelete
	{
		[TestMethod]
		public void TestDelete()
		{
			FAQ faq = new FAQ();
			faq.id = 1;
			bool test = faq.delete();
			Assert.IsTrue(test);
		}
		[TestMethod]
		public void TestDeleteFailed()
		{
			FAQ faq = new FAQ();
			faq.id = 1;
			bool test = faq.delete();
			Assert.IsFalse(test);
		}
	}
}
