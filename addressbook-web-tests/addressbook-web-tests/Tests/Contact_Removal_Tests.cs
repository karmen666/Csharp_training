using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]

    public class Contact_Removal_Tests: ContactTestBase
    {
        [Test]

        public void ContactRemovalTest()
        {
            app.contact.CreateIfNoContactPresent();

            List<PersonData> oldUsers = PersonData.GetAll();
            PersonData toBeRemoved = oldUsers[0];

            app.contact.ContactDeletion(toBeRemoved);
            app.Navigator.ReturnToHomePage();

            List<PersonData> newUsers = PersonData.GetAll();
            oldUsers.RemoveAt(0);
            oldUsers.Sort();
            newUsers.Sort();
            Assert.AreEqual(oldUsers, newUsers);

            foreach (PersonData person in newUsers)
            {
                Assert.AreNotEqual(person.Id, toBeRemoved.Id);
            }

            app.Auth.LogOut();
        }
    }
}
