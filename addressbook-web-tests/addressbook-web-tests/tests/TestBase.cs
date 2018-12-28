using NUnit.Framework;

namespace WebAaddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();

        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }
        //*for groups were moved to GroupHelper

        //*for contactswere moved to ContactHelper

    }
}
