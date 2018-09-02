using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests 
{
    public class PersonData : IEquatable<PersonData>, IComparable<PersonData>
    {
        private string allPhones;

        public PersonData(string firstname) {

            Firstname = firstname;
        }

        public PersonData(string firstname, string lastname)
        {
           Firstname = firstname;
           Lastname= lastname;
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

        public string Firstname{get; set;}

        public string Lastname {get; set;}

        public string Address {get; set;}

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }

        }

        public string CleanUp(string phone)
        {
            if (phone == null || phone=="")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]","")+"\r\n";
        }

        public string Email { get; set; }
    }
}
