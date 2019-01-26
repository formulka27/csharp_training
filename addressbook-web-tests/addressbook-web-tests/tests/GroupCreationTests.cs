using NUnit.Framework;
using System.Collections.Generic;

namespace WebAaddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {

        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("AAA");
            group.Header = "BBB";
            group.Footer = "CCC";
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            //return the list of existing group
           List<GroupData> newGroups=app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
           Assert.AreEqual(oldGroups, newGroups);
          }


        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            //return the list of existing group
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            //return the list of existing group
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}