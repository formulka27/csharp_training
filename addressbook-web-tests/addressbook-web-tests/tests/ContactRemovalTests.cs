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
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
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
                //app.Contacts.ContactRemoval();//удаляем первый контакт из старой группы
                //Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactsCount());//быстрая проверка
                //ContactData toBeRemoved = oldContacts[0];//запомнили удаленный контакт
                //List<ContactData> newContacts = app.Contacts.GetContactList();//получаем список контактов с уже удаленным контактом
                //oldContacts.RemoveAt(0);//количество должно быть одинаковым => удаляем удаленный контакт
                //oldContacts.Sort();
                //newContacts.Sort();

                //foreach (ContactData contact in newContacts)
                //{

                //    Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
                //}
                List<ContactData> oldContacts = ContactData.GetAllContactFromTable();
                ContactData toBeRemoved = oldContacts[0];
                //app.Contacts.Remove(toBeRemoved);
                app.Contacts.ContactRemoval();
                Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactsCount());
                List<ContactData> newContacts = ContactData.GetAllContactFromTable();
                oldContacts.RemoveAt(0);
                oldContacts.Sort();
                newContacts.Sort();

                Assert.AreEqual(oldContacts, newContacts);

                foreach (ContactData contact in newContacts)
                {

                    Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
                }


            }
        }
    }
    }
