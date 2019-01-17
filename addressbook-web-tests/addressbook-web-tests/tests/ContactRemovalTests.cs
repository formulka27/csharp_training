using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAaddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests:AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            //Готовим тестовую ситуацию
            if (app.Contacts.IsContactPresent() == false)
            {                
                ContactData contact = new ContactData("admin", "secret");
                app.Contacts.CreateContact(contact);
                //проверка 
                Assert.IsTrue(app.Contacts.IsContactPresent());
            }
            ////совершаем действия 
            app.Contacts.ContactRemoval();
            Assert.IsFalse(app.Contacts.IsContactPresent());

        }

    }
}
