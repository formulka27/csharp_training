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
                   ContactData contact = new ContactData(element.FindElement(By.XPath(".//td[3]")).Text, element.FindElement(By.XPath(".//td[2]")).Text)
                    { Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    };
                    
                   contactCashe.Add(contact);

               //     contactCashe.Add(new ContactData(element.FindElement(By.XPath(".//td[3]")).Text, element.FindElement(By.XPath(".//td[2]")).Text));
                    
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
        //сколько контактов на странице
        internal int GetContactsCount()
        {
            return driver.FindElements(By.CssSelector("tr[name='entry']")).Count;
        }

        internal ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(0);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string firstemail = driver.FindElement(By.Name("email")).GetAttribute("value");
            string secondemail = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string thirdemail = driver.FindElement(By.Name("email3")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
           
            return new ContactData(firstname, lastname)
            //надо указать дополнительные проперти
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                //FirstEmail=firstemail,
                //SecondEmail=secondemail,
                //ThirdEmail =thirdemail
            };
          
        }
        
        
        public void InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            
        }
        internal ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));//сохраняем все наши ячейки в массив (для меня это матрица)
            string lastname = cells[1].Text;
            string firstname = cells[2].Text;
            string address = cells[3].Text;
         //   string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstname, lastname)
            //надо указать дополнительные свойства
            {
                Address = address,
                AllPhones =allPhones,
              //  AllEmails=allEmails
            };

          }

    }
}


