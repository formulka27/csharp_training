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
            //если нет ни одного контакта -создаем
            if (app.Contacts.IsContactPresent() == false)
            {                
                ContactData contact = new ContactData("Contactadmin", "secret");
                app.Contacts.CreateContact(contact);
                //проверка 
                Assert.IsTrue(app.Contacts.IsContactPresent());
            }

            ////совершаем действия 
            List<ContactData> oldContacts = app.Contacts.GetContactList();//пустой список
            app.Contacts.ContactRemoval();//удаляем первый контакт из старой группы
            List<ContactData> newContacts = app.Contacts.GetContactList();//получаем список контактов с уже удаленным контактом
            oldContacts.RemoveAt(0);//количество должно быть одинаковым => удаляем удаленный контакт
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }
            }
}
