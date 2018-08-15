using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests 
{
    [TestFixture]

    public class ContactCreationTests:AuthTestBase
    {
                   
        [Test]
        public void ContactCreationTest()
        {
            PersonData person = new PersonData("Cat");
            person.Lastname = "Woman";
            app.contact.CreateContact(person);
            app.Navigator.ReturnToHomePage();
            app.Auth.LogOut();
        }

        [Test]
        public void EmptyContactCreationTest()
        {
           PersonData person = new PersonData("");
            person.Lastname = "";
            app.contact.CreateContact(person);
            app.Navigator.ReturnToHomePage();
            app.Auth.LogOut();
        }
    }
}
