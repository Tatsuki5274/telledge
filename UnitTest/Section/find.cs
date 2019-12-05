using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using telledge.Models;

namespace UnitTest.Sections
{
	[TestClass]
	public class find
	{
		[TestMethod]
		public void success()
		{
			Assert.IsNotNull(Section.find(2, 1));
		}
	}
}
