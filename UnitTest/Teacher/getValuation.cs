using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using telledge.Models;
//using telledge.Models;  //プロジェクトのテスト対象

namespace UnitTest.Teachers
{
    [TestClass]
    public class TeachergetValuation
    {
        [TestMethod]
        public void getValuation()
        {
			Teacher teacher = new Teacher();
			teacher.id = 1;
			double valuation = teacher.getValuation();
			Assert.AreNotEqual(valuation,0);
        }
		[TestMethod]
		public void getValuationFailed()
		{
			Teacher teacher = new Teacher();
			teacher.id = 3;
			double valuation = teacher.getValuation();
			Assert.AreEqual(valuation,-1);
		}
	}
}
