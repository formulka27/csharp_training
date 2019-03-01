using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;


namespace addressbook_test_autoit
{
    public class TestBase
    {
        ApplicationManager app;

        [OneTimeSetUp]

        public void initApplication()
        {
            app = new ApplicationManager();
         }

        [OneTimeTearDown]

        public void stopApplication()
        {
            app.Stop();
        }
    }
}
