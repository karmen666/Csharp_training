﻿using System;
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
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData ("admin","secret"));
            app.Navigator.GoToGroupsPage();
            app.Groups.InitializeGroupCreation();
            GroupData group = new GroupData("Foxes");
            group.Header = "Red";
            group.Footer = "Sly";
            app.Groups.FillInGroupForm(group);
            app.Groups.SubmitGroupCreation();
            app.Groups.ReturnToGroupsPage();
            app.Auth.LogOut();
        } 
    }
}
