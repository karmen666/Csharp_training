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
            app.contact.ContactDeletion(1);
            app.Navigator.ReturnToHomePage();
            app.Auth.LogOut();
        }
    }
}
