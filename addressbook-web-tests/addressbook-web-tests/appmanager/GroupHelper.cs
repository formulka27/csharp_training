﻿using System;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using WebAaddressbookTests;
using System.Collections.Generic;

namespace WebAaddressbookTests
{
    public class GroupHelper:HelperBase
    {


        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }
        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }
        



        public GroupHelper Modify(int p, GroupData newData)
        {
           manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper ModifyByDBID(GroupData oldData, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(oldData.Id);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;

        }

        public GroupHelper Remove(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(group.Id);//принимает объект по идентификатору
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        //будет выбирать группу и отмечать ее галочкой по идентификатору
        public GroupHelper SelectGroup(string id )
        {
           // Console.Out.Write(id);
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='"+id+"'])")).Click();
            return this;
        }

        

        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroupsPage();
                 SelectGroup(p);
                 RemoveGroup();
                 ReturnToGroupsPage();
            return this;
        }





        //for groups

        public GroupHelper InitGroupCreation()
        {

            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
        
                Type(By.Name("group_name"), group.Name);
                Type(By.Name("group_header"), group.Header);
                Type(By.Name("group_footer"), group.Footer);
          
            return this;
        }   
        
        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCashe = null;
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }
        public GroupHelper SelectGroup(int index)

        {
            
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();

            return this;
        }


        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCashe = null;
            return this;
        }
        public GroupHelper SubmitGroupModification()
        {

            driver.FindElement(By.Name("update")).Click();
            groupCashe = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
        //поле , где хранится запомненный список групп
        private List<GroupData> groupCashe = null;

        //проверяем , хотя бы одна группа существует
        public bool IsGroupPresent()
        {
            manager.Navigator.GoToGroupsPage();
            return IsElementPresent(By.Name("selected[]"));
         }

  //метод возвращает список групп     
        public List<GroupData> GetGroupList()
        {
            //если кэш не заполнен еще, то заполняем 
            if (groupCashe==null)
            {

                groupCashe = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                //сохраняем найденный список элементов в коллекцию объектов IWebElement
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                //превращаем все элементы типа IWebElement  в нужные нам объект Типа GroupData
                foreach (IWebElement element in elements)
                {
                    // groupCashe.Add(new GroupData(element.Text)
                    groupCashe.Add(new GroupData(null)//на первом проходе не берем
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
                string allGroupsName = driver.FindElement(By.CssSelector("div#content form")).Text;//нашли элемент с идентификатором , внутри него форма,именно из нее и берем техт
                
                string[] parts = allGroupsName.Split('\n');  //получили массив с именами всех групп
                int shift = groupCashe.Count - parts.Length;
                for (int i=0; i<groupCashe.Count; i++ )
                {
                    if (i<shift)//если индекс меньше чем сдвиг , то прописывем пустое имя
                    {
                        groupCashe[i].Name = "";
                    }
                    else
                    {
                        groupCashe[i].Name = parts[i-shift].Trim();
                    }
                    
                }
            }
            // return groupCashe;//возвращаем кэш после того как все загружено
            return new List<GroupData>(groupCashe);//возвращаем не кэш ,  а его копию,потому как злые дядьки могут его испортить доюавлением или удалением элемента из кэша
            }

        //метод возвращает количество групп
        public int GetGroupCount()
        {
           return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        

    }
}
