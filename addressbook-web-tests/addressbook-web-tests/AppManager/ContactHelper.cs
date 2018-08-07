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
           manager.Navigator.ReturnToHomePage();
         

           return this;
        }
        public ContactHelper InitializeNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillInTheFields(PersonData person)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(person.Firstname);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(person.Lastname);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

    }
}
