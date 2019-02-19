using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAaddressbookTests;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace addressbook_test_data_generations
{
    class Program
    {
        static void Main(string[] args)
        {
            //    //задали параметры
            int count = Convert.ToInt32(args[0]); //в 0 передаем количество текстовых данных ,которые мы хоти сгенерировать
            StreamWriter writer = new StreamWriter(args[1]);//параметр - имя нашего файла
            string format = args[2];
            List<GroupData> groups = new List<GroupData>();
            //начали собственно генерацию


            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(100),
                    Footer = TestBase.GenerateRandomString(100)
                });
            }
            if (format == "excell")
            {

            }
            if (format == "csv")
            {
                WriteGroupsToCsvFile(groups, writer);
            }
            else if (format == "xml")
            {
                WriteGroupsToXmlFile(groups, writer);
            }
            else if (format == "json")
            {
                WriteGroupsToJsonFile(groups, writer);
            }

            else
            {
                System.Console.Out.Write("Unrecognized format" + format);

            }
            writer.Close();//гарантия того ,  что мы данные не потеряем и файл с 0 размером не будет создан
        }
        ////для контактов

        //static void MainContacts(string[] args)
        //{
        //    //задали параметры
        //    int count = Convert.ToInt32(args[0]); //в 0 передаем количество текстовых данных ,которые мы хоти сгенерировать
        //    StreamWriter writer = new StreamWriter(args[1]);//параметр - имя нашего файла
        //    string format = args[2];
        //    List<ContactData> contacts = new List<ContactData>();
        //    //начало собственно генерации

        //    for (int i = 0; i < count; i++)
        //    {
        //        contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
        //        {
        //            Address = TestBase.GenerateRandomString(100),
        //            MobilePhone = TestBase.GenerateRandomString(100)

        //        });
        //    }
        //    if (format == "csv")
        //    {
        //        WriteContactsToCsvFile(contacts, writer);
        //    }
        //    else if (format == "xml")
        //    {
        //        WriteContactsToXmlFile(contacts, writer);
        //    }
        //    else if (format == "json")
        //    {
        //        WriteContactsToJsonFile(contacts, writer);
        //    }

        //    else
        //    {
        //        System.Console.Out.Write("Unrecognized format" + format);

        //    }
        //    writer.Close();//гарантия того ,  что мы данные не потеряем и файл с 0 размером не будет создан
        //}




        public static void WriteGroupsToCsvFile(List<GroupData> groups , StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        public static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups); //1 - куда , 2 -что 
        }
        public static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups,Newtonsoft.Json.Formatting.Indented));

        }
         public static void WriteContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    contact.Firstname, contact.Lastname, contact.Address));
            }
        }
        public static void WriteContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts); //1 - куда , 2 -что
        }

        public static void WriteContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
           // writer.Write(JsonConvert.SerializeObject(contacts));
              writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));

        }
    }
}
