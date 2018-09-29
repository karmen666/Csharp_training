using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupModificationTests:GroupTestBase
    {
        [Test]
        
        public void GroupModificationTest()
        {
            app.Groups.CreateIfNoGroupPresent();

            GroupData newData = new GroupData("Almonds");
            newData.Header = null;
            newData.Footer = null;
            List<GroupData> oldGroups = GroupData.GetAll();

            GroupData toBeModified = oldGroups[0];

            app.Groups.Modify(toBeModified.Id, newData);

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
