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

            List<GroupData> oldGroups = GroupData.GetAll();//поменяли на табличный
            GroupData toBeRemoved = oldGroups[0]; //сохранили объект(имеено объект вместе с его идентиф и всеми остальными свойствами) ,который должен быть удален 
            //app.Groups.Remove(0);//0 в ui совсем не то что в таблице
            app.Groups.Remove(toBeRemoved);//удаляем объект
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());
           List<GroupData> newGroups = GroupData.GetAll();//поменяли на табличный
            oldGroups.RemoveAt(0);
           
          Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
               
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
                }
            
            



        }

    }
}



   

   
    