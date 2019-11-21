using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using telledge.Models;  //プロジェクトのテスト対象

namespace UnitTest.Teachers
{
    [TestClass]
    public class SetPassWord
    {
        [TestMethod]
        public void SetPassWordTest()
        {
            Teacher teacher = new Teacher();
            teacher.setPassword("password");
        }
    }
}
