﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{

    public class AddressBookDB:LinqToDB.Data.DataConnection
    {
        public AddressBookDB() : base("AddressBook") { }
    }
}
