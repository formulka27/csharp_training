using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAaddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {

        [Test]
        public void ContactModificationTest()
        {

            if (app.Contacts.IsContactPresent() == false)
            {
                // если контакт не существует , то создаем его предварительно
                ContactData contact = new ContactData("NEWadmin", "LastSecretName");
                app.Contacts.CreateContact(contact);
                Assert.IsTrue(app.Contacts.IsContactPresent());
            }
            //если существует - модифицируем первый
            ContactData newData = new ContactData("676767", "LASTNAME");

            //List<ContactData> oldContacts = app.Contacts.GetContactList();
            //ContactData oldData = oldContacts[0];
            //app.Contacts.ModifyContact(newData);
            //Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactsCount());//быстрая проверка
            //List<ContactData> newContacts = app.Contacts.GetContactList();
            //oldContacts[0].Firstname = newData.Firstname;
            //oldContacts[0].Lastname = newData.Lastname;
            //oldContacts.Sort();
            //newContacts.Sort();
            //// Assert.AreEqual(oldContacts, newContacts);

            //foreach (ContactData contact in newContacts)
            //{
            //    if (contact.Id == oldData.Id)
            //    {
            //        Assert.AreEqual(newData.Lastname, contact.Lastname);
            //    }

            //вариант с базой

            List<ContactData> oldContacts = ContactData.GetAllContactFromTable();
            ContactData oldData = oldContacts[0];
            // app.Contacts.ModifyContact(newData);
            app.Contacts.ModifyByID(oldData, newData);
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = ContactData.GetAllContactFromTable();
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Lastname, contact.Lastname);
                }
            }
            }
        }
    }

