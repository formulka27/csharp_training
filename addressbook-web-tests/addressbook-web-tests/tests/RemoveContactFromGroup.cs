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
    public class RemoveContactFromGroup: AuthTestBase
    {
        [Test]
        public void TestRemoveContactFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];//выбираем группу
            List<ContactData> oldList = group.GetContatcs();
            ContactData contact = ContactData.GetAllContactFromTable().First(); //получаем список контактов 

            app.Contacts.TestRemoveContactfromGroup(contact, group);


            //сравнение
            List<ContactData> newList = group.GetContatcs();
            oldList.RemoveAt(0);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);


        }
    }

}