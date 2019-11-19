using Microsoft.VisualStudio.TestTools.UnitTesting;
using telledge.Models;  //プロジェクトのテスト対象


namespace telledge.Tests.Models
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void LoginFailByBothStatus()
        {
            //存在しないメールアドレスとパスワードでnullが返ってくるかどうかテスト
            Student ret = Student.login("notexit", "example");
            Assert.IsNull(ret);
        }
        [TestMethod]
        public void LoginFailByMail()
        {
            //存在する名前と間違ったパスワードでnullが返ってくるかテスト
            Student ret = Student.login("name", "example");
            Assert.IsNull(ret);
        }

        [TestMethod]
        public void LoginFailByPassword()
        {
            //存在しない名前と正しいパスワードでnullが返ってくるかテスト
            Student ret = Student.login("wrongName", "password");
            Assert.IsNull(ret);
        }

        [TestMethod]
        public void LoginSuccess()
        {
            //var session = new Mock<HttpSessionStateBase>();
            //controllerContext.Setup(p => p.HttpContext.Session).Returns(session.Object); 
            Student ret = Student.login("name", "password");
            Assert.IsNotNull(ret);
            //Assert.AreEqual(ret,       
        }

        [TestMethod]
        public void SetPassWordTest()
        {
            Student student = new Student();
            student.setPassword("password");
        }
    }
}
