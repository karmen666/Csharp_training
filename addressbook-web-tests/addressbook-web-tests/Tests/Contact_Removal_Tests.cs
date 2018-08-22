using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]

    public class Contact_Removal_Tests: AuthTestBase
    {
        [Test]

        public void ContactRemovalTest()
        {
            app.contact.CreateIfNoContactPresent();

            List<PersonData> oldUsers = app.contact.GetUserList();

            app.contact.ContactDeletion(1);
            app.Navigator.ReturnToHomePage();

            List<PersonData> newUsers = app.contact.GetUserList();
            oldUsers.RemoveAt(0);
            oldUsers.Sort();
            newUsers.Sort();
            Assert.AreEqual(oldUsers, newUsers);

            app.Auth.LogOut();
        }
    }
}
