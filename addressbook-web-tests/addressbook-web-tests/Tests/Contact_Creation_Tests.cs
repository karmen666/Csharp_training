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
        public static IEnumerable<PersonData> RandomContactDataProvider()
        {
            List<PersonData> person = new List<PersonData>();
            for (int i = 0; i < 3; i++)
            {
                person.Add(new PersonData(GenerateRandomString(20))
                {
                    Lastname=GenerateRandomString(20)
                });
            }
            return person;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(PersonData person)
        {
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
