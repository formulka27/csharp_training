using NUnit.Framework;

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

            app.Groups.Create(group);
          }


        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Groups.Create(group);
        }
    }
}