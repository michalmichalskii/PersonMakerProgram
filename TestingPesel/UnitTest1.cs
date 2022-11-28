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
        public void CheckingPeselLengthAndChecksum()
        {
            var peselCheck = new PeselChecker();

            for (int i = 0; i < pesels.Length; i++)
            {
                Assert.IsTrue(peselCheck.AmountOfNumbersChecking(pesels[i]));
                Assert.IsTrue(peselCheck.ChecksumOfLastNumberChecking(pesels[i]));
            }

        }

        [Test]
        public void ListModifierChecking()
        {
            var isOnePersonOnly = new ListModifier();

            List<Person> people = new List<Person>();

            var Person1 = new Person
            {
                City = "Poznan",
                Name = "Adrian",
                SurrName = "Polak",
                Pesel = "92071314764"
            };

            people.Add(Person1);

            var Person2 = new Person()
            {
                City = "Krakow",
                Name = "Maciej",
                SurrName = "Kot",
                Pesel = "92071314764"
            };

            isOnePersonOnly.DuplicatesInListChecking(Person2.Pesel, people);

            people.Add(Person2);

            Assert.AreEqual(people.Count, 1);
        }
    }
}