using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using telledge.Models;

namespace UnitTest.Inquirys
{
    [TestClass]
    public class InquiryCreate
    {
        [TestMethod]
        public void TestCreate()
        {
			Inquiry inquiry = new Inquiry();
			inquiry.inquiryContent = "InquiryContent";
			inquiry.inquiryTime = DateTime.Now;
			inquiry.senderName = "Name";
			inquiry.senderContent = "senderContent";
			inquiry.isReplied = false;
			bool check = inquiry.create();
			Assert.IsTrue(check);
		}
        [TestMethod]
        public void TestCreateFailed()
        {
			Inquiry inquiry = new Inquiry();
			inquiry.inquiryContent = "InquiryContent";
			inquiry.inquiryTime = DateTime.Now;
			inquiry.replierId = null;
			inquiry.replierContent = null;
			inquiry.isReplied = false;
			bool check = inquiry.create();
			Assert.IsFalse(check);
		}
    }
}
