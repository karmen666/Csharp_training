using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;

namespace WebAddressbookTests 
{
    [TestFixture]

    public class ContactCreationTests:AuthTestBase
    {
        public static IEnumerable<PersonData> RandomContactDataProvider()
        {
            List<PersonData> person = new List<PersonData>();
            for (int i = 0; i < 3; i++)
            {
                person.Add(new PersonData(GenerateRandomString(20))
                {
                    Lastname=GenerateRandomString(20)
                });
            }
            return person;
        }

        public static IEnumerable<PersonData> ContactDataFromXmlFile()
        {
          return (List<PersonData>) 
                new XmlSerializer(typeof(List<PersonData>))
                    .Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<PersonData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<PersonData>>(
                File.ReadAllText(@"contacts.json"));
        }

        [Test, TestCaseSource("ContactDataFromJsonFile")]

        public void ContactCreationTest(PersonData person)
        {
            List<PersonData> oldUsers = app.contact.GetUserList();

            app.contact.CreateContact(person);

            List<PersonData> newUsers = app.contact.GetUserList();
            oldUsers.Add(person);
            oldUsers.Sort();
            newUsers.Sort();
            Assert.AreEqual(oldUsers, newUsers);

            app.Navigator.ReturnToHomePage();
        }
    }
}
