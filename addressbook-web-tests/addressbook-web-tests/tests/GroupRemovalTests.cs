using NUnit.Framework;

namespace WebAaddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Groups.Remove(2);
        }
    }
}

   

   
    