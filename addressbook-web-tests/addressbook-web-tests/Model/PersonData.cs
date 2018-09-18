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
        private string allInformation;
        private string allEmails;

        public PersonData()
        {
        }

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

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

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

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanMail(Email) + CleanMail(Email2) + CleanMail(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }
        
        public string AllInformation
        {
            get
            {
                if (allInformation != null)
                {
                    return allInformation;
                }
                else
                {
                    string result = (Firstname + " " + Lastname).Trim();
                    string halfresult = "";

                    if (Address != null && Address != "")
                    {
                        halfresult = halfresult + Address + "\r\n\r\n";
                    }
                    if (HomePhone != null && HomePhone !="")
                    {
                        halfresult = halfresult + "H: " + CleanUp(HomePhone);
                    }
                    if (MobilePhone != null && MobilePhone!="")
                    {
                        halfresult = halfresult + "M: " + CleanUp(MobilePhone);
                    }
                    if (WorkPhone != null && WorkPhone!="")
                    {
                        halfresult = halfresult + "W: " + CleanUp(WorkPhone);
                    }
                    if (Email != null && Email !="")
                    {
                        halfresult= halfresult+ "\r\n" + Email;
                    }
                    if (Email2 != null && Email2 != "")
                    {
                        halfresult = halfresult + "\r\n" + Email2;
                    }
                    if (Email3 != null && Email3 != "")
                    {
                        halfresult = halfresult + "\r\n" + Email3;
                    }

                    if (halfresult != "")
                    {
                        result = result + "\r\n" + halfresult;
                    }
                    return result;
                }
            }

            set
            {
                allInformation = value;
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


        private string CleanMail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return Regex.Replace(email, "[ -()]", "") + "\r\n";
        }
    }
}
