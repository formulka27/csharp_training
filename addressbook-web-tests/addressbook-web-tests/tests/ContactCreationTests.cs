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

namespace WebAaddressbookTests
{
    [TestFixture]
    public class ContactCreationTests:AuthTestBase

    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            //создаем список контактов
            List<ContactData> contacts = new List<ContactData>();
            //чем то заполняем
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))//сделала как в группе тут длина строки ,которую собираемся генерировать                {
                {
                    Address = GenerateRandomString(100),
                    MobilePhone = GenerateRandomString(100)
                });
            }

            return contacts;
        }
        //метод альтернативный предыдущему -читает данные из сsv
        public static IEnumerable<ContactData> ContactDataFromCsvFile()
        {
            //создаем список контактов
            List<ContactData> contacts = new List<ContactData>();
            //будем читать из списка значений,разделенных запятыми . самая простая ситуация
            //читаем все строчки из этого файла и помещаем его в массив строк
            string[] lines = File.ReadAllLines(@"contact.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');//разбили строку на куски
                //создаем новый объект и добавляем его в список групп
                contacts.Add(new ContactData(parts[0],parts[1])
                {
                    //заполняем остальные свойства
                    
                    Address = parts[2],
                    Title=parts[3]
                });
            }

            return contacts;
        }

        //метод альтернативный предыдущему -читает данные из xml
        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            //создаем список контактов
            List<ContactData> contacts = new List<ContactData>();
            //будем читать из xml и возвращать его указав явно тип (List<ContactData>) потому как Desirialize понятия не имеет о типе данных
            return (List<ContactData>) //приведение типа
                new XmlSerializer(typeof(List<ContactData>)).
                Deserialize(new StreamReader(@"contact.xml"));
        }
        //метод альтернативный предыдущему -читает данные из json
        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
               File.ReadAllText(@"contact.json"));
        }



        //[Test,TestCaseSource("RandomContactDataProvider")]
        // [Test, TestCaseSource("ContactDataFromXmlFile")]
           [Test, TestCaseSource("ContactDataFromJsonFile")]



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
        [Test]
        public void TestContactDBConnectivity() //читает информацию из базы и выводит ее на консоль
        {
            DateTime start = DateTime.Now;
            //читаем из ui
            List<ContactData> fromUI = app.Contacts.GetContactList();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

            //из базы 


            start = DateTime.Now;
            List<ContactData> fromDb = ContactData.GetAllContactFromTable();
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));



        }
    }
}
