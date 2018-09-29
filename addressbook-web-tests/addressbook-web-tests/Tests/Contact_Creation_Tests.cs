using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

namespace WebAddressbookTests 
{
    [TestFixture]

    public class ContactCreationTests : ContactTestBase
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
            List<PersonData> oldUsers = PersonData.GetAll();

            app.contact.CreateContact(person);

            List<PersonData> newUsers = PersonData.GetAll();
            oldUsers.Add(person);
            oldUsers.Sort();
            newUsers.Sort();
            Assert.AreEqual(oldUsers, newUsers);
            app.Navigator.ReturnToHomePage();
        }

        [Test]
        public void TestDBConnectivity3()
        {
            DateTime start = DateTime.Now;
            List<PersonData> fromUI=app.contact.GetUserList();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

            start = DateTime.Now;
            List<PersonData> fromdb = PersonData.GetAll();
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));
        }
     }
}
