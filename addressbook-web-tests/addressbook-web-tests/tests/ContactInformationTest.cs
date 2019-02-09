using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAaddressbookTests
{
    [TestFixture]

    public class ContactInformationTest : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0); //Получаем информацию о каком то одном контакте
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            //verifications
            Assert.AreEqual(fromTable, fromForm);//сравнила свойства ,которые прописала в методе Equals,это только имя и фамилия
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);//в таблице все кучкой -одна строка , в форме три =>надо склеить ,прежде чем сравнивать
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }
        [Test]
        public void TestEditContactAndDetails()
        {
            string fromDetails = app.Contacts.GetContactInformationFromDetailsPage(); //Получаем информацию о каком то одном контакте со страницы Details в виде строки
            string fromFormToString = app.Contacts.GetContactInformationFromFormToString();
            
            //verifications
            Assert.AreEqual(fromDetails, fromFormToString);//сравнила свойства ,которые прописала в методе Equals,это только имя и фамилия
           
        }
    }
}
