using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests:AuthTestBase
    {      

        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("Limon");
            group.Header = "Sour";
            group.Footer = "Yellow";
            app.Groups.Create(group);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
        }
    }
}
