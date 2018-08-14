using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests:TestBase 
    {      

        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("Kaktus");
            group.Header = "Fikus";
            group.Footer = "Orchid";
            app.Groups.Create(group);
          //  app.Auth.LogOut();
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
          //  app.Auth.LogOut();
        }
    }
}
