using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebAaddressbookTests
{
    [TestFixture]
    public class ContactCreationTests:AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Irina", "KIZZZZZZooooo");
            
           
            app.Contacts.CreateContact(contact);
            
        }
        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");


            app.Contacts.CreateContact(contact);
        }
    }
}
