using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]

    public class ContactModifTests:TestBase
    {
        [Test]

        public void ContactModifTest()
        {
            PersonData newPerson = new PersonData("TU");
            newPerson.Lastname = "Tu-ti-tu";
            app.contact.ContactModify(5,newPerson);
            app.Auth.LogOut();
        }

    }
}
