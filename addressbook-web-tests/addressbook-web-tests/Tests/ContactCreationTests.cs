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
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.contact.InitializeNewContactCreation();
            PersonData person = new PersonData("Leonard");
            person.Lastname = "Willis";
            app.contact.FillInTheFields(person);
            app.contact.SubmitContactCreation();
            app.Navigator.ReturnToHomePage();
            app.Auth.LogOut();
        }

      
     

        

    

     

       

    

             

    }
}
