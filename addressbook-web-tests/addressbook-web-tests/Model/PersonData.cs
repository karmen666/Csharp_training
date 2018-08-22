using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests 
{
    public class PersonData : IEquatable<PersonData>, IComparable<PersonData>
    {
        private string firstname;
        private string lastname;

        public PersonData(string firstname) {

            this.firstname = firstname;
        }

        public PersonData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }


        public bool Equals(PersonData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            string line = Firstname + Lastname;
            return line.GetHashCode();
        }

        public override string ToString()
        {
            return Firstname + " " + Lastname;
        }

        public int CompareTo(PersonData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            string line = Firstname + Lastname;
            string lineOther = other.Firstname + other.Lastname;
            return line.CompareTo(lineOther);
        }

        public string Firstname {
            get {
                return firstname; 
            }
            set {
                firstname = value;
            }
         }

        public string Lastname {
            get {
                return lastname;
                }
            set {
                lastname = value;
            }
        }
        
    }
}
