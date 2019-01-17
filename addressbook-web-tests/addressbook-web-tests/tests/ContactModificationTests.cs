using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAaddressbookTests
{
    [TestFixture]
    public class ContactModificationTests:AuthTestBase
    {

        [Test]
        public void ContactModificationTest()
        {

            if (app.Contacts.IsContactPresent() == false)
            {
// если контакт не существует , то создаем его предварительно
                ContactData contact = new ContactData("admin", "secret");
                app.Contacts.CreateContact(contact);
                Assert.IsTrue(app.Contacts.IsContactPresent());
            }
//если существует - модифицируем первый
            ContactData newData = new ContactData("676767","llkklklklkl");
            app.Contacts.ModifyContact(newData);
            Assert.IsTrue(app.Contacts.IsContactPresent());
        }
    }
}
