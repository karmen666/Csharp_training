using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests 
{
    [TestFixture]

    public class ContactCreationTests:TestBase 
    {
                   
        [Test]
        public void ContactCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            InitializeNewContactCreation();
            PersonData person = new PersonData("Artas");
            person.Lastname = "Tour";
            FillInTheFields(person);
            SubmitContactCreation();
            ReturnToHomePage();
            LogOut();
        }

      
     

        

    

     

       

    

             

    }
}
