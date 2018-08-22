using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper:HelperBase
    {
        public ContactHelper(ApplicationManager manager):base (manager)
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
            return this;
        }

        public ContactHelper InitContactModification(int t)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])["+t+"]")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
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

        public List<PersonData> GetUserList()
        {
            List<PersonData> person = new List<PersonData>();
            manager.Navigator.GoToHomePage();

            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr"));

            int row = 0;

            foreach (IWebElement element in elements)
            {
                if (row > 0)
                {
                    string F = element.FindElement(By.XPath("td[3]")).Text;
                    string L = element.FindElement(By.XPath("td[2]")).Text;

                    person.Add(new PersonData(F, L));
                }

                row++;
            }

            return person;
        }
    }
}
