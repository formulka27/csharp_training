using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAaddressbookTests
{
    [TestFixture]
    public class LoginTests :TestBase
    {
        [Test]

        public void LoginWithValidCredentials()
        {
            //Готовим тестовую ситуацию
            app.Auth.Logout();
            //совершаем действия 
            AccountData account = new AccountData("admin", "secret");          
            app.Auth.Login(account);
            //проверка 
            Assert.IsTrue(app.Auth.IsLoggedIn(account));

        }
        [Test]
        public void LoginWithInvalidCredentials()
        {
            //Готовим тестовую ситуацию
            app.Auth.Logout();
            //совершаем действия 
            AccountData account = new AccountData("admin", "55555");
            app.Auth.Login(account);
            //проверка 
            Assert.IsFalse(app.Auth.IsLoggedIn(account));

        }

    }
    
}
