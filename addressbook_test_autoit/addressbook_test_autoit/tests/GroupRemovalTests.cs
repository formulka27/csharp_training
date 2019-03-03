using System;
using NUnit.Framework;
using System.Collections.Generic;


namespace addressbook_test_autoit
{
    [TestFixture]

    public class GroupRemovalTests:TestBase
    {
        [Test]
        public void TestGroupRemoval()
        {
           List<GroupData> oldGroups = app.Groups.GetGroupList();//запомнили старый список

           
            app.Groups.Remove();

            List<GroupData> newGroups = app.Groups.GetGroupList();//новый записали
            oldGroups.RemoveAt(0);//удалили из старого списка удаленную группу
          

            oldGroups.Sort();
            newGroups.Sort();




            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}



//List<GroupData> oldGroups = app.Groups.GetGroupList();


//app.Groups.Remove(0);
//            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());
//            GroupData toBeRemoved = oldGroups[0];//запоминаем ID удаленной группы в переменную
//List<GroupData> newGroups = app.Groups.GetGroupList();
//oldGroups.RemoveAt(0);
//            oldGroups.Sort();
//            newGroups.Sort();
//            Assert.AreEqual(oldGroups, newGroups);
//          //  Assert.AreEqual(oldGroups, newGroups);

//            foreach (GroupData group in newGroups)
//            {
//                //Assert.AreNotEqual(group.Id, oldGroups[0].Id);
//                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
//                }




