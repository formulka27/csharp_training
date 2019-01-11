using System;
using OpenQA.Selenium;

namespace WebAaddressbookTests
{
    public class NavigationHelper:HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }
            
//navigate to the home page
            public void GoToHomePage()
        {
            if (driver.Url == baseURL + "/addressbook")
            {
                return;
            }
              
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }
//navigate to the group page
        public void GoToGroupsPage()
        {
            if (driver.Url==baseURL + "/addressbook/group.php"
                && IsElementPresent(By.Name("new")))
                {
                return;
                  }
            driver.FindElement(By.LinkText("groups")).Click();
        }
//navigate to the contact page
        public void GoToNewContactPage()
        {
             if (driver.Url == baseURL + "/addressbook/edit.php"
                && IsElementPresent(By.LinkText("add new")))
            {
                return;
            }
              driver.FindElement(By.LinkText("add new")).Click();
        }
//navigate to Home to make sure we can work with contacts
        public void VerifyHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }
    }
}
