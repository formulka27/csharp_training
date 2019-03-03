using System;
using NUnit.Framework;
using System.Collections.Generic;


namespace addressbook_test_autoit
{
    [TestFixture]

        public class GroupCreationTests:TestBase
    {
        [Test]
        public void TestGroupCreation()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();//запомнили старый список

            GroupData newGroup = new GroupData()
            {
                Name = "Test"
            };
            app.Groups.Add(newGroup);

            List<GroupData> newGroups = app.Groups.GetGroupList();//новый записали
            oldGroups.Add(newGroup);//добавили к старому списку новую группу
            oldGroups.Sort();
            newGroups.Sort();




            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
