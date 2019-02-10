using NUnit.Framework;
using System.Collections.Generic;
using System;

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

            return groups;
        }

      

        [Test, TestCaseSource("RandomGroupDataProvider")] //параметр,что используется внешний источник текстовыых данных, из метода в данном случае

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