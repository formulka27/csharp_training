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

       
        //поле , где хранится запомненный список контактов
        private List<ContactData> contactCashe = null;

        //метод возвращает список контактов     
        public List<ContactData> GetContactList()
        {
            //если кэш не заполнен еще, то заполняем 
            if (contactCashe == null)
            {
                contactCashe = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                //сохраняем найденный список элементов в коллекцию объектов IWebElement
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));
                //превращаем все элементы типа IWebElement  в нужные нам объект Типа ContactData
                foreach (IWebElement element in elements)
                {
                    //собственно список
                    //string Lastname = element.FindElement(By.XPath(".//td[2]")).Text;// kizzzzzz
                    ////*[@id="maintable"]/tbody/tr[2]/td[3] //Irina =firstname

                    contactCashe.Add(new ContactData(element.FindElement(By.XPath(".//td[3]")).Text, element.FindElement(By.XPath(".//td[2]")).Text));
                }
                }
                return new List<ContactData>(contactCashe);//возвращаем список
            }
        


        public ContactHelper ContactRemoval()
        //вариант 1 , выбираем по иконке  Edit ,тогда можно удалить без alert на странице Edit
        //{
        //    manager.Navigator.VerifyHomePage();
        //    EditContact();
        //    RemoveContact();            
        //    manager.Navigator.VerifyHomePage();
        //    return this;
        //}
        //вариант 2, выбираем по checkbox , тогда удаляется на номе и с alert.
        {
            manager.Navigator.VerifyHomePage();
            SelectContact();
            RemoveContact();
            CloseAlert();
            manager.Navigator.VerifyHomePage();
            return this;
        }
        public ContactHelper ModifyContact(ContactData newData)
        {

            manager.Navigator.VerifyHomePage();
            EditContact();
            FillNewContactForm(newData);
            SubmitContactModification();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCashe = null;
            return this;
        }

        public ContactHelper EditContact()
        {
            //click on the pencil icon
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }
           

        public ContactHelper SelectContact()
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
            contactCashe = null;
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
            contactCashe = null;
            return this;
        }
        //проверяем , хотя бы один контакт существует на нужной странице
        public bool IsContactPresent()
        {
            
            manager.Navigator.GoToHomePage();
            return IsElementPresent(By.XPath("//img[@alt='Edit']"));
        }

        internal int GetContactsCount()
        {
            return driver.FindElements(By.CssSelector("tr[name='entry']")).Count;
        }

    }
}


