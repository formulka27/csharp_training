using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAaddressbookTests 
{
    public class ContactTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareContactsUI_DB()
        {
            if (PERFOM_LONG_UI_CHECKS_CONTACTS)
            {
                List<ContactData> fromUI = app.Contacts.GetContactList();//ui
                List<ContactData> fromDB = ContactData.GetAllContactFromTable();
                fromUI.Sort();
                fromDB.Sort();
                Assert.AreEqual(fromUI, fromDB);
            }
        }
    }
}
