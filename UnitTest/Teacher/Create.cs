using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using telledge.Models;  //プロジェクトのテスト対象

namespace telledge.Tests.Models
{
    [TestClass]
    public class TeacherCreate
    {
        [TestMethod]
        public void TestCreate()
        {
            Teacher teacher = new Teacher();
            teacher.name = "Test";
            teacher.sex = 1;
            teacher.profileImage = "Gafeokfwaoefa.pix";
            teacher.age = 20;
            teacher.language = "English";
            teacher.intoroduction = "Japan";
            teacher.setPassword("password");
            teacher.mailaddress = "OARO@jec.ac.jp";
            teacher.is2FA = false;
            teacher.point = 0;
            teacher.address = "Japan Sinjuku Kabukityo";
            teacher.nationality = "???";
            bool test = teacher.create();
            Assert.IsTrue(test);
        }
        [TestMethod]
        public void TestCreateFailed()
        {
            Teacher teacher = new Teacher();
            teacher.name = "Test";
            teacher.sex = 1;
            teacher.profileImage = "Gafeokfwaoefa.pix";
            teacher.age = 20;
            teacher.intoroduction = "Japan";
            teacher.setPassword("password");
            teacher.mailaddress = "OARO@jec.ac.jp";
            teacher.is2FA = false;
            teacher.point = 0;
            teacher.address = "Japan Sinjuku Kabukityo";
            teacher.nationality = "???";
            bool test = teacher.create();
            Assert.IsFalse(test);
        }
    }
}
