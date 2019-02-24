using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAaddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {

            if (app.Groups.IsGroupPresent() == false)
            {
                // если группы нет , то создаем ее предварительно с любыми параметрами
                GroupData nogroup = new GroupData("Нет ни одной группы");
                nogroup.Header = null;
                nogroup.Footer = null;
                

                app.Groups.Create(nogroup);
                Assert.IsTrue(app.Groups.IsGroupPresent());
            }
            //если существует - модифицируем первую

            GroupData newData = new GroupData("Новая группа");
            newData.Header = null;
            newData.Footer = null;
            

            //версия старая
            ////List<GroupData> oldGroups = app.Groups.GetGroupList();
            ////GroupData oldData = oldGroups[0];
            ////app.Groups.Modify(0, newData);
            ////Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());//быстрая проверка 

            ////List<GroupData> newGroups = app.Groups.GetGroupList();
            ////oldGroups[0].Name = newData.Name;
            ////oldGroups.Sort();
            ////newGroups.Sort();
            ////Assert.AreEqual(oldGroups, newGroups);

            ////foreach (GroupData group in newGroups)
            ////{
            ////    if (group.Id == oldData.Id)
            ////    {
            ////        Assert.AreEqual(newData.Name, group.Name);
            ////    }
                //вариант с базой

                List<GroupData> oldGroups = GroupData.GetAll();//поменяли на табличный
                GroupData oldData = oldGroups[0]; //объект ,который должен быть модифицирован
                 app.Groups.ModifyByDBID(oldData, newData);

                Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

                  List<GroupData> newGroups = GroupData.GetAll();//поменяли на табличный
                 oldGroups[0].Name = newData.Name;
                 oldGroups.Sort();
                 newGroups.Sort();
                 Assert.AreEqual(oldGroups, newGroups);

                foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }

    }
    }
}

    

