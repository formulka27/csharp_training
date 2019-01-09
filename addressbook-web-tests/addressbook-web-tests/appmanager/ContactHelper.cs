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
        //вариант 1 , выбираем по иконке  Edit ,тогда можно удалить без alert на странице Edit
        //{
        //    manager.Navigator.VerifyHomePage();
        //    EditContact(v);
        //    RemoveContact();            
        //    manager.Navigator.VerifyHomePage();
        //    return this;
        //}
        //вариант 2, выбираем по checkbox , тогда удаляется на номе и с alert.
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
            //click on the pencil icon
             driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
              return this;
        }
        public ContactHelper SelectContact(int v)
        {
            //click on check box on the left
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[2]/td/input")).Click();

            return this;
        }

        //for contacts


        public ContactHelper FillNewContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("middlename"), contact.Middlename);

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

    }
}
