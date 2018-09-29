using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;

namespace WebAddressbookTests
{

    public class AddressBookDB:LinqToDB.Data.DataConnection
    {
        public AddressBookDB() : base("AddressBook") { }

        public ITable<GroupData> Groups { get { return GetTable<GroupData>(); } }

        public ITable<PersonData> Contacts { get { return GetTable<PersonData>(); } }

        public ITable<GroupContactRelation> GCR { get { return GetTable<GroupContactRelation>(); } }

    }
}
