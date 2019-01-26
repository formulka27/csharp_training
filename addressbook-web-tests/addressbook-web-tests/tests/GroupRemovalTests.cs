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
            
        //    Assert.IsTrue(app.Groups.IsGroupPresent());
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);



        }

    }
}



   

   
    