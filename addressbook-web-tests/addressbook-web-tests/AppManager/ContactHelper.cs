﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper CreateContact(PersonData person)
        {
            InitializeNewContactCreation();
            FillInTheFields(person);
            SubmitContactCreation();
            return this;
        }

        public ContactHelper DriverAlert()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper ContactDeletion(int l)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(l);
            RemoveContact();
            DriverAlert();
            return this;
        }

        public ContactHelper ContactDeletion(PersonData person)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(person.Id);
            RemoveContact();
            DriverAlert();
            WaitUntilPageReloads();
            return this;
        }
        public ContactHelper ContactModify(int p, PersonData newPerson)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(p);
            FillInTheFields(newPerson);
            SubmitContactModification();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper SelectContact(int v)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + v + "]")).Click();
            return this;
        }

        public ContactHelper SelectContact(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='"+id+"'])")).Click();
            //driver.FindElement(By.Id(id)).Click();
            return this;
        }

        public ContactHelper InitializeNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillInTheFields(PersonData person)
        {
            Type(By.Name("firstname"), person.Firstname);
            Type(By.Name("lastname"), person.Lastname);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactModification(int t)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (t + 1) + "]")).Click();
            /*        The code of the line above without XPath:
                      driver.FindElements(By.Name("entry"))[t]
                           .FindElements(By.TagName("td"))[7]
                           .FindElement(By.TagName("a")).Click(); */

            return this;
        }

        public ContactHelper InitContactProps(int k)
        {
            driver.FindElement(By.XPath("(//img[@alt='Details'])[" + (k+1)+"]")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        public bool IsContactPresent()
        {
            return IsElementPresent(By.CssSelector("img[alt=\"Edit\"]"));
        }

        public void CreateIfNoContactPresent()
        {
            manager.Navigator.GoToHomePage();

            if (!IsContactPresent())
            {
                CreateContact(new PersonData("Honey"));
            }
        }

        private List<PersonData> contactCache = null;

        public List<PersonData> GetUserList()
        {
            if (contactCache == null)
            {
                contactCache = new List<PersonData>();
                List<PersonData> person = new List<PersonData>();
                manager.Navigator.GoToHomePage();

                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));

                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));

                    string F = cells[2].Text;
                    string L = cells[1].Text;

                    contactCache.Add(new PersonData(F, L));
                }
            }

            return new List<PersonData>(contactCache);
        }

        public PersonData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new PersonData(firstName, lastName)
            {
                Address = address,
                AllEmails = allEmails,
                AllPhones = allPhones
            };
        }

        public PersonData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new PersonData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2=email2,
                Email3=email3
            };
        }

        public PersonData GetContactInformationFromProperties(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactProps(index);
            string m = driver.FindElement(By.Id("content")).Text;

            return new PersonData("", "")
            {
                AllInformation = m
            };
        }

        public void AddContact2Group(PersonData person, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContact(person.Id);
            SelectGroup2Add(group.Name);
            CommitAddingContact2Group();
            WaitUntilPageReloads();
        }

        public void CommitAddingContact2Group()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void SelectGroup2Add(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
            
        }

        public void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");

        }

        public void RemoveContactFromGroup(PersonData person, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            SelectGroupInFilter(group.Name);
            SelectContactToRemove(person.Id);
            CommitContactRemovalFromGroup();
            WaitUntilPageReloads();

        }

        private void CommitContactRemovalFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        private void SelectContactToRemove(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();
        }

        private void SelectGroupInFilter(string id)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(id);
        }
    }
}

