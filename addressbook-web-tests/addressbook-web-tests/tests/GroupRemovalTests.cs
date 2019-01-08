using NUnit.Framework;

namespace WebAaddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Groups.Remove(2);
        }
    }
}

   

   
    