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
            // Create contacts and/or groups if needed
            if (GroupData.GetAll().Count == 0)
            {
                app.Groups.Create(new GroupData("Animals"));
            }
            if (PersonData.GetAll().Count == 0)
            {
                app.contact.CreateContact(new PersonData("Lady", "Bug"));
            }

            PersonData person = new PersonData();
            List<GroupData> allGroups = GroupData.GetAll();
            int groupIndex = -1;

            for (int i = 0; i < allGroups.Count; i ++)
            {
                IEnumerable<PersonData> personsExceptInGroup = PersonData.GetAll()
                                                        .Except(allGroups[i].GetContacts());

                if (personsExceptInGroup.Count() > 0)
                {
                    groupIndex = i;
                    person = personsExceptInGroup.First();
                    break;
                }
            }

            if (groupIndex == -1)
            {
                app.contact.CreateContact(new PersonData(GenerateRandomString(6), GenerateRandomString(6)));
                groupIndex = 0;
            }

            GroupData group = allGroups[groupIndex];
            List<PersonData> oldList = group.GetContacts();
            List<PersonData> allPersons = PersonData.GetAll();
            person = PersonData.GetAll().Except(oldList).First();

            app.contact.AddContact2Group(person, group);
            
            List<PersonData> newList = group.GetContacts();
            oldList.Add(person);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);

        }
    }

}
