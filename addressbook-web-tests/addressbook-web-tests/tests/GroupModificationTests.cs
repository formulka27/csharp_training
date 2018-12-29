using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAaddressbookTests
{
    [TestFixture]
    public class GroupModificationTests:TestBase
    {
        [Test]
        public void GroupModificationTest()
        {

            GroupData newData= new GroupData("676767");
            newData.Header = "090909";
            newData.Footer = "00000";
            app.Groups.Modify(1,newData);
           
        }

    }
}
