using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemovingContactFromGroup : AuthTestBase
    {
        [Test]
        public void TestRemovingContactFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<PersonData> oldList = group.GetContacts();
            PersonData personToRemove = oldList[0];

            app.contact.RemoveContactFromGroup(personToRemove, group);

            List<PersonData> newList = group.GetContacts();
            oldList.Remove(personToRemove);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
