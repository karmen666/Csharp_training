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
            PersonData newPerson = new PersonData("TU");
            newPerson.Lastname = null;

            app.contact.ContactModify(1,newPerson);

            app.Auth.LogOut();
        }

    }
}
