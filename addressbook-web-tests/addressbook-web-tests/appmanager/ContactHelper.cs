using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebAaddressbookTests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }
        public ContactHelper CreateContact(ContactData contact)
        {
            manager.Navigator.GoToNewContactPage();
            FillNewContactForm(contact);
            SubmitContactCreation();
            return this;
        }

        public ContactHelper ContactRemoval(int v)
        {
            manager.Navigator.VerifyHomePage();
            SelectContact(v);
            RemoveContact();
            CloseAlert();
            manager.Navigator.VerifyHomePage();

            return this;
        }
        public ContactHelper ModifyContact(int v, ContactData newData)
        {
            
            manager.Navigator.VerifyHomePage();
            EditContact(v);
            FillNewContactForm(newData);
            SubmitContactModification();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper EditContact(int v)
        {
            driver.FindElement(By.XPath($"//a[@href='edit.php?id=9']")).Click();
           
            return this;
        }

        //for contacts


        public ContactHelper FillNewContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            return this;


        }
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }


        public ContactHelper CloseAlert()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper RemoveContact()
        {

            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper SelectContact(int v)
        {
            driver.FindElement(By.Id("29")).Click();
            return this;
        }
    }
}
