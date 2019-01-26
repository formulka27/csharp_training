using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;

namespace WebAaddressbookTests
{
    [TestFixture]
    public class ContactCreationTests:AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Irina", "KIZZZZZZooooo");
            List<ContactData> oldContacts = app.Contacts.GetContactList();       
            app.Contacts.CreateContact(contact);

             Assert.AreEqual(oldContacts.Count+1,app.Contacts.GetContactsCount());//быстрая проверка

            //return the list of contacts after the action -add
            List<ContactData> newContacts = app.Contacts.GetContactList(); 
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            
        }
        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");
            List<ContactData> oldContacts = app.Contacts.GetContactList();


            app.Contacts.CreateContact(contact);
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactsCount());//быстрая проверка

            //return the list of contacts after the action -add
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
