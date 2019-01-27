using NUnit.Framework;
using System.Collections.Generic;

namespace WebAaddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            if (app.Groups.IsGroupPresent() == false)
            {
                // если старой группы нет , то создаем ее предварительно с любыми параметрами
                GroupData nogroup = new GroupData("GroupForDeleting");
                nogroup.Header = null;
                nogroup.Footer = null;

                app.Groups.Create(nogroup);
                Assert.IsTrue(app.Groups.IsGroupPresent());
            }
            //если существует только одна  - удаляем первую
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            
            app.Groups.Remove(0);
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());
            GroupData toBeRemoved = oldGroups[0];//запоминаем ID удаленной группы в переменную
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
          //  Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                //Assert.AreNotEqual(group.Id, oldGroups[0].Id);
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
                }
            
            



        }

    }
}



   

   
    