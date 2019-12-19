using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using telledge.Models;

namespace UnitTest.Inquirys
{
    [TestClass]
    public class InquiryUpdate
    {
        [TestMethod]
        public void TestUpdate()
        {
			Inquiry inquiry = new Inquiry();
			inquiry.id = 2;
			inquiry.inquiryContent = "InquiryContent";
			inquiry.inquiryTime = DateTime.Now;
			inquiry.senderName = "Name";
			inquiry.replierId = 2;
			inquiry.senderContent = "senderContent";
			inquiry.isReplied = false;
			bool check = inquiry.update();
			Assert.IsTrue(check);
		}
        [TestMethod]
        public void TestUpdateFailed()
        {
			Inquiry inquiry = new Inquiry();
			inquiry.id = 3;
			inquiry.inquiryContent = "InquiryContent";
			inquiry.inquiryTime = DateTime.Now;
			inquiry.replierId = null;
			inquiry.repliersContent = null;
			inquiry.isReplied = false;
			bool check = inquiry.update();
			Assert.IsFalse(check);
		}
    }
}
