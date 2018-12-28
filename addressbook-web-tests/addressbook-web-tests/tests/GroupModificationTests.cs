using NUnit.Framework;

namespace WebAaddressbookTests
{
    [TestFixture]

    public class GroupModigicationTests:TestBase
    { 
        [Test]
    
        public void GroupModificationlTest()
        {
            GroupData newData = new GroupData("UUU");
            newData.Header = "ZZZZ";
            newData.Footer = "MODIFIED";

            app.Groups.Modify(1,newData);

        }
    }
}
