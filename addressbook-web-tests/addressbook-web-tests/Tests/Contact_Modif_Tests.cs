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
            PersonData newPerson = new PersonData("LadyBug");
            newPerson.Lastname = null;
            app.contact.ContactModify(1,newPerson);
            app.Auth.LogOut();
        }
    }
}
