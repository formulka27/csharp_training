using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;



namespace WebAaddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            //создаем список групп
            List<GroupData> groups = new List<GroupData>();
            //чем то заполняем
            for (int i = 0; i <5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))//30 тут длина строки ,которую собираемся генерировать                {
                { 
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
//возвращаем список групп
            return groups;
        }
        //метод альтернативный предыдущему -читает данные из сsv
        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            //создаем список групп
            List<GroupData> groups = new List<GroupData>();
            //будем читать из списка значений,разделенных запятыми . самая простая ситуация
            //читаем все строчки из этого файла и помещаем его в массив строк
           string[] lines=File.ReadAllLines(@"group.csv");
            foreach (string l in lines) 
            {
                string[] parts = l.Split(',');//разбили строку на куски
                //создаем новый объект и добавляем его в список групп
                groups.Add(new GroupData(parts[0])
                {
                    //заполняем остальные свойства
                    Header = parts[1],
                    Footer = parts[2]
                });
            }

            return groups;
        }

        //метод альтернативный предыдущему -читает данные из xml
        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            //создаем список групп
            List<GroupData> groups = new List<GroupData>();
            //будем читать из xml и возвращать его указав явно тип (List<GroupData>) потому как Desirialize понятия не имеет о типе данных
            return (List<GroupData>) //приведение типа
                new XmlSerializer(typeof(List<GroupData>)).
                Deserialize(new StreamReader(@"group.xml"));         
        }

        //метод альтернативный предыдущему -читает данные из Json
        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {

            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"group.json"));

        }


        // [Test, TestCaseSource("RandomGroupDataProvider")] //параметр,что используется внешний источник текстовыых данных, из метода в данном случае
        // [Test, TestCaseSource("GroupDataFromCsvFile")]
        // [Test, TestCaseSource("GroupDataFromXmlFile")]
        [Test, TestCaseSource("GroupDataFromJsonFile")]

        public void GroupCreationTest(GroupData group)
        {
            //буду брать извне потому инициализация тестовых данных не нужна
            //GroupData group = new GroupData("AAA");
            //group.Header = "BBB";
            //group.Footer = "CCC";
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);
            //полезно лишь в случаях часто падающих тестов
            //быстро возвращает количество групп и переходить к дальнейшим деяниям имеет смысл, если количество групп равно
            // int count = app.Groups.GetGroupCount();
            //Assert.AreEqual(oldGroups.Count+1, count);
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());
            //return the list of existing group
            List<GroupData> newGroups=app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
           Assert.AreEqual(oldGroups, newGroups);
          }

//пустая группа это теперь головняк данных 
        //[Test]
        //public void EmptyGroupCreationTest()
        //{
        //    GroupData group = new GroupData("");
        //    group.Header = "";
        //    group.Footer = "";
        //    List<GroupData> oldGroups = app.Groups.GetGroupList();

        //    app.Groups.Create(group);
        //    Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());
        //    //return the list of existing group
        //    List<GroupData> newGroups = app.Groups.GetGroupList();
        //    oldGroups.Add(group);
        //    oldGroups.Sort();
        //    newGroups.Sort();
        //    Assert.AreEqual(oldGroups, newGroups);
        //}
        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());
            //return the list of existing group
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}