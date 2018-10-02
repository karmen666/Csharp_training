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
            // Create contacts and/or groups if needed
            if (GroupData.GetAll().Count == 0)
            {
                app.Groups.Create(new GroupData("Animals"));
            }
            if (PersonData.GetAll().Count == 0)
            {
                app.contact.CreateContact(new PersonData("Lady", "Bug"));
            }

            GroupData group = GroupData.GetAll()[0];
            List<PersonData> oldList = group.GetContacts();

            if (oldList.Count == 0)
            {
                PersonData person = PersonData.GetAll()[0];
                app.contact.AddContact2Group(person, group);
                oldList = group.GetContacts();
            }

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
