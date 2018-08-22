using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]

    public class ContactModifTests: AuthTestBase
    {
        [Test]

        public void ContactModifTest()
        {
            app.contact.CreateIfNoContactPresent();
            PersonData newPerson = new PersonData("Catwoman");
            newPerson.Lastname = null;

            List<PersonData> oldUsers = app.contact.GetUserList();

            app.contact.ContactModify(1,newPerson);

            List<PersonData> newUsers = app.contact.GetUserList();
            oldUsers[0].Firstname = newPerson.Firstname;
            oldUsers.Sort();
            newUsers.Sort();
            Assert.AreEqual(oldUsers, newUsers);

            app.Auth.LogOut();
        }
    }
}
