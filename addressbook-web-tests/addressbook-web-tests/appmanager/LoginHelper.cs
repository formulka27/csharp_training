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
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
          
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();

        }
    }
}
