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
            Assert.AreEqual(fromTable.Email, fromForm.Email);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }
    }
}
