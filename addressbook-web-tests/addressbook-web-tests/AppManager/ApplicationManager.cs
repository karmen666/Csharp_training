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
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected LogIn_LogOut_Helper logIn_LogOut_Helper;
        protected NavigationHelper navigator;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        private static ApplicationManager instance;

        private ApplicationManager()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox\firefox.exe";
            options.UseLegacyImplementation = true;
            driver = new FirefoxDriver(options);
            baseURL = "http://localhost";

            logIn_LogOut_Helper = new LogIn_LogOut_Helper(this);
            navigator = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);

        }

        public static ApplicationManager GetInstance()
        {
            if (instance == null)
            {
                instance = new ApplicationManager();
            }
            return instance;
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
            set
            {
                this.Driver = value;
            }
        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        } 
        
            public LogIn_LogOut_Helper Auth
        {
            get
            {
                return logIn_LogOut_Helper;
            }
        }

        public NavigationHelper Navigator
        {
        get 
            {
                return navigator;
             }
        }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }

        public ContactHelper contact
        {
            get
            {
                return contactHelper; 
            }
        }
    }
}
