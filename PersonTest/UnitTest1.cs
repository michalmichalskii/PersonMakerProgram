using NUnit.Framework;
using PersonMaker.UI;

namespace PersonTest
{
    public class Tests
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        [Test]
        public void Test1()
        {
            //ARRANGE
            var person = new PersonMaker.Person();
            var pesel = new PersonMaker.PeselChecker("12345678910");
            var ui = new UserInterface(person, pesel.ToString());
            
            //ACT
            pesel.AmountOfNumbersChecking(pesel.ToString());
            //pesel.ChecksumOfLastNumberChecking(pesel.ToString());

            //ASSERT
            Assert.AreEqual(true, pesel.AmountOfNumbersChecking(pesel.ToString()));
        }
    }
}