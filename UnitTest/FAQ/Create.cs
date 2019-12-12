using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using telledge.Models;

namespace UnitTest.FAQs
{
    [TestClass]
    public class FAQCreate
    {
        [TestMethod]
        public void TestCreate()
        {
			FAQ faq = new FAQ();
			faq.question = "Question";
			faq.answer = "Answer";
			bool check = faq.create();
			Assert.IsTrue(check);
		}
        [TestMethod]
        public void TestCreateFailed()
        {
			FAQ faq = new FAQ();
			faq.question = "Question";
			bool check = faq.create();
			Assert.IsFalse(check);
		}
    }
}
