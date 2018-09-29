using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContact2GroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContact2Group()
        {
            GroupData group = GroupData.GetAll()[0];
            List<PersonData> oldList = group.GetContacts();
            PersonData person= PersonData.GetAll().Except(oldList).First();

            app.contact.AddContact2Group(person,group);
            
            List<PersonData> newList = group.GetContacts();
            oldList.Add(person);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);

        }
    }

}
