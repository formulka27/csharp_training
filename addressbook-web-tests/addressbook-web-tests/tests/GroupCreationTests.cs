using NUnit.Framework;

namespace WebAaddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {

        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
           
            GroupData group = new GroupData("AAA");
            group.Header = "BBB";
            group.Footer = "CCC";

            app.Groups.InitGroupCreation();
            app.Groups.FillGroupForm(group);
            app.Groups.SubmitGroupCreation();
            app.Groups.ReturnToGroupsPage();

        }
    }
}