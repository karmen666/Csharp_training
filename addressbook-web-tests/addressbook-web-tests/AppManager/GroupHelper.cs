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
   public class GroupHelper:HelperBase
    {
        public GroupHelper(ApplicationManager manager):base(manager)
        {
        }
        
        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitializeGroupCreation();
            FillInGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Modify(int p, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            InitializeGroupModification();
            FillInGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int v)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(v);
            RemoveGroup(v);
            groupCache = null;
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper InitializeGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
    
        public GroupHelper FillInGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }

        public GroupHelper RemoveGroup(int number)
        {
            driver.FindElement(By.XPath("(//input[@name='delete'])[" + (number+1) + "]")).Click();
            return this;
        }
     
        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper InitializeGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        public bool IsGroupPresent()
        {
          return IsElementPresent(By.Name("selected[]"));
        }

        public void CreateIfNoGroupPresent()
        {
            manager.Navigator.GoToGroupsPage();

            if (!IsGroupPresent())
            {
               Create(new GroupData("Orange"));
            }
        }

        public List<GroupData> groupCache = null;

        public  List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();

                List<GroupData> groups = new List<GroupData> ();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text));
                }
                // the line above can be written differently:
                //GroupData group = new GroupData(element.Text);
                //groups.Add(group);
            }
            return new List<GroupData> (groupCache);
        }
    }
}
