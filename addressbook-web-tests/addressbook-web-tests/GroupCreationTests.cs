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
            GoToHomePage();
            Login(new AccountData ("admin","secret"));
            GoToGroupsPage();
            InitializeGroupCreation();
            GroupData group = new GroupData("Wolves");
            group.Header = "Grey";
            group.Footer = "Hungry";
            FillInGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            LogOut();
        } 
    }
}
