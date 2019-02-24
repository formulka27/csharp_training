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
            //List<ContactData> oldContacts = app.Contacts.GetContactList();//пустой список
            List< ContactData> oldContacts = ContactData.GetAllContactFromTable();//поменяли на табличный
            ContactData toBeRemoved = oldContacts[0]; //объект ,который должен быть удален 

            app.Contacts.ContactRemoval(toBeRemoved);//удаляем первый контакт из старой группы
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactsCount());//быстрая проверка

            // List<ContactData> newContacts = app.Contacts.GetContactList();//получаем список контактов с уже удаленным контактом
            List<ContactData> newContacts = ContactData.GetAllContactFromTable();
            oldContacts.RemoveAt(0);//количество должно быть одинаковым => удаляем удаленный контакт
            oldContacts.Sort();
            newContacts.Sort();
            
            foreach (ContactData contact in newContacts)
            {
                
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}
