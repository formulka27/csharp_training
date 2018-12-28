using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebAaddressbookTests
{
    public class ContactHelper:HelperBase
    {
        
        public ContactHelper (IWebDriver driver) : base(driver)
        {
        }

        //for contacts
        public void GoToContactPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
        public void FillNewContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
        }
        public void SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
        }
    }
}
