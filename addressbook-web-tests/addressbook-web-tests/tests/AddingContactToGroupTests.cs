using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using System.Xml;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.IO;
using System.Linq;

namespace WebAaddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group= GroupData.GetAll()[0];//выбираем группу
            List<ContactData> oldList = group.GetContatcs();
            ContactData contact = ContactData.GetAllContactFromTable().Except(oldList).First(); //получаем список контактов выкинув саисок контактов,входящих в группу уже

            // actions

            app.Contacts.AddContactToGroup(contact,group);


            //сравнение
            List<ContactData> newList = group.GetContatcs();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList,newList);


        }
    }

}