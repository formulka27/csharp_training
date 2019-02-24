using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAaddressbookTests
{
    [TestFixture]
    public class GroupModificationTests:AuthTestBase
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
      

            //List<GroupData> oldGroups = app.Groups.GetGroupList();
            //GroupData oldData = oldGroups[0];
            //app.Groups.Modify(0, newData);
            List<GroupData> oldGroups = GroupData.GetAll();//поменяли на табличный
            GroupData toBeModified = oldGroups[0]; //объект ,который должен быть модифицирова
            app.Groups.ModifyByID(toBeModified);


            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());//быстрая проверка 

            // List<GroupData> newGroups = app.Groups.GetGroupList();
            List<GroupData> newGroups= GroupData.GetAll();
             oldGroups[0].Name = newData.Name;
           // System.Console.Out.Write(oldGroups[0].de
           // oldGroups[0].Name = toBeModified.Name;
            //      oldGroups.Sort();
            //      newGroups.Sort();



   //         Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {

                Assert.AreNotEqual(group.Id, toBeModified.Id);
            }

     //       foreach (GroupData group in newGroups)
      //      {
       //         if (group.Id == toBeRemoved.Id)
      //          {
       //             Assert.AreEqual(newData.Name,group.Name);
       //         }
                
       //     }
        }
     
        }

    }

