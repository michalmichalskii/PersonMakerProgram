using NUnit.Framework;
using PersonMaker.Logic;
using PersonMaker.UI;
using System.Collections.Generic;

namespace TestingPesel
{
    public class Tests
    {
        readonly string[] pesels = new string[] { "12345678910", "02070803628", "90090515836", "92071314764", "81100216357", "80072909146" };

        [Test]
        public void PeselLengthAndChecksumTest()
        {
            var peselCheck = new PeselChecker();

            for (int i = 0; i < pesels.Length; i++)
            {
                Assert.IsTrue(peselCheck.AmountOfNumbersCheck(pesels[i]));
                Assert.IsTrue(peselCheck.ChecksumOfLastNumberCheck(pesels[i]));
            }

        }

        [Test]
        public void PersonsListTest()
        {
            var personsList = new PersonsList();

            var Person1 = new Person
            {
                City = "Poznan",
                Name = "Adrian",
                SurrName = "Polak",
                Pesel = "92071314764"
            };

            personsList.DuplicatesInListDelete(Person1.Pesel);
            personsList.AddPerson(Person1);
            Assert.AreEqual(personsList.GetList().Count, 1);


            var Person2 = new Person()
            {
                City = "Krakow",
                Name = "Maciej",
                SurrName = "Kot",
                Pesel = "92071314764"
            };

            personsList.DuplicatesInListDelete(Person2.Pesel);
            personsList.AddPerson(Person2);
            Assert.AreEqual(personsList.GetList().Count, 1);


            var Person3 = new Person()
            {
                City = "Rzeszow",
                Name = "Urszula",
                SurrName = "Mak",
                Pesel = "02070803628"
            };

            personsList.DuplicatesInListDelete(Person3.Pesel);
            personsList.AddPerson(Person3);
            Assert.AreEqual(personsList.GetList().Count, 2);
        }
    }
}