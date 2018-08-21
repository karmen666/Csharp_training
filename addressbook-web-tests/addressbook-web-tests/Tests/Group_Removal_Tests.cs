﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressbookTests
    {
    [TestFixture]

    public class GroupRemovalTests : AuthTestBase

    {  
        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.CreateIfNoGroupPresent();
            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);
            app.Auth.LogOut();
            Assert.AreEqual(oldGroups, newGroups);
        }      
     }
}
