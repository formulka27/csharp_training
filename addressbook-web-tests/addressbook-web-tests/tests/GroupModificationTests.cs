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

            GroupData newData = new GroupData("New Modification");
            newData.Header = null;
            newData.Footer = null;
      

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Modify(0, newData);
            Assert.IsTrue(app.Groups.IsGroupPresent());
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
     
        }

    }

