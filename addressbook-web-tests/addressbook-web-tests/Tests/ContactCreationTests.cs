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
            PersonData person = new PersonData("Kate");
            person.Lastname = "Sorokina";
            app.contact.CreateContact(person);
           // manager.Navigator.ReturnToHomePage();
            app.Auth.LogOut();
        }

        [Test]
        public void EmptyContactCreationTest()
        {
           PersonData person = new PersonData("");
            person.Lastname = "";
            app.contact.CreateContact(person);
            //manager.Navigator.ReturnToHomePage();
            app.Auth.LogOut();
        }
    }
}
