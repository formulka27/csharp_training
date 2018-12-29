using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAaddressbookTests
{
    [TestFixture]
    public class ContactModificationTests:TestBase
    {

        [Test]
        public void ContactModificationTest()
        {

            ContactData newData = new ContactData("676767","llkklklklkl");
          
            app.Contacts.ModifyContact(1,newData);

        }


    }
}
