using System;
using System.Text;
using System.Collections.Generic;
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
            PersonData person = new PersonData("Spider");
            person.Lastname = "Man";

            List<PersonData> oldUsers = app.contact.GetUserList();

            app.contact.CreateContact(person);

            List<PersonData> newUsers = app.contact.GetUserList();
            oldUsers.Add(person);
            oldUsers.Sort();
            newUsers.Sort();
            Assert.AreEqual(oldUsers, newUsers);

            app.Navigator.ReturnToHomePage();
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            PersonData person = new PersonData("");
            person.Lastname = "";

            List<PersonData> oldUsers = app.contact.GetUserList();

            app.contact.CreateContact(person);
            List<PersonData> newUsers = app.contact.GetUserList();
            oldUsers.Add(person);
            oldUsers.Sort();
            newUsers.Sort();
            Assert.AreEqual(oldUsers, newUsers);

            app.Navigator.ReturnToHomePage();
        }
    }
}
