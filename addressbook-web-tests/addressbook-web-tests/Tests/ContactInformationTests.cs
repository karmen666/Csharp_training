using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class WebAddressbookTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
           PersonData fromTable= app.contact.GetContactInformationFromTable(0);
           PersonData fromForm= app.contact.GetContactInformationFromEditForm(0);
           
            //verification:
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void TestContactProperties()
        {
            PersonData fromProps = app.contact.GetContactInformationFromProperties(0);
            PersonData fromForm = app.contact.GetContactInformationFromEditForm(0);

            //verification:
            System.Console.WriteLine(fromProps.AllInformation);
            System.Console.WriteLine(fromForm.AllInformation);
            Assert.AreEqual(fromProps.AllInformation, fromForm.AllInformation);
        }

    }
}
