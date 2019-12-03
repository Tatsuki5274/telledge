using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using telledge.Models;

namespace UnitTest.Sections
{
	/// <summary>
	/// update の概要の説明
	/// </summary>
	[TestClass]
	public class updateTest
	{
		[TestMethod]
		public void success()
		{
			Section section = new Section();
			section.studentId = 1;
			section.roomId = 1;

			section.beginTime = DateTime.Parse("2000/1/1");
			section.request = "変更テスト";
			section.talkTime = 500;
			section.valuation = null;
			Assert.IsNotNull(section.update());
		}
	}
}
