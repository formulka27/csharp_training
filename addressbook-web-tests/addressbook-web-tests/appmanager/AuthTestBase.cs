using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//базовый класс для всех тестов которые требуют входа в систему 
namespace WebAaddressbookTests
{
    public class AuthTestBase:TestBase
    {
        [SetUp]
        public void SetupLogin()
        {
            //          app = new ApplicationManager();
            app = ApplicationManager.GetInstance();
            app.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}
