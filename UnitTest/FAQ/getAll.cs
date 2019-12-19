using telledge.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTest.FAQs
{
	[TestClass]
	public class getAll
	{
		[TestMethod]
		public void testSucsess()
		{
			FAQ faq = new FAQ();
			FAQ[] faq2 = faq.getAll();
			Assert.IsNotNull(faq2);
		}
	}
}
