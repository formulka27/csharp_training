using System;
using OpenQA.Selenium;

namespace WebAaddressbookTests
{
    public class LoginHelper:HelperBase
    {
        

        public LoginHelper(ApplicationManager manager):base(manager)
        {
        }

        //login
        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                Logout();
            }
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
          
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();

        }
        //проверяем , что залогинен именно тот юзер ,который указан в account.Username
        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text
                                                            == "(" + account.Username + ")";
        }
//проверяем , что мы имеем какую то открытую сессию уже , атрибут name=logout
        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public void Logout()
        {
            if (IsLoggedIn())
                {
                driver.FindElement(By.LinkText("Logout")).Click();
                 }
            
        }
    }
}
