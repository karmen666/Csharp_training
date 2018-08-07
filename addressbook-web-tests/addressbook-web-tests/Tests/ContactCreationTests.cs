using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests 
{
    [TestFixture]

    public class ContactCreationTests:TestBase 
    {
                   
        [Test]
        public void ContactCreationTest()
        {
         //   app.Navigator.GoToHomePage();
         //   app.Auth.Login(new AccountData("admin", "secret"));

           
            PersonData person = new PersonData("Leonard");
            person.Lastname = "Willis";
            app.contact.CreateContact(person);
            app.Auth.LogOut();
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            //   app.Navigator.GoToHomePage();
            //   app.Auth.Login(new AccountData("admin", "secret"));

            PersonData person = new PersonData("");
            person.Lastname = "";
            app.contact.CreateContact(person);
            app.Auth.LogOut();
        }
    }
}
