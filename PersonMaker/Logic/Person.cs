using PersonMaker.Exceptions;
using PersonMaker.Logic;
using System;

namespace PersonMaker.Logic
{
    public class Person
    {
        private string city;

        public string City
        {
            get { return city; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    city = value;
                }
            }
        }


        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    name = value;
                }
            }
        }

        private string surrName;

        public string SurrName
        {
            get { return surrName; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    surrName = value;
                }
            }
        }


        private string pesel;

        public string Pesel
        {
            get { return pesel; }
            set
            {
                string tmpPesel = value;

                PeselChecker pc = new PeselChecker();

                bool correctPesel = false;

                while (!correctPesel)
                {
                    try
                    {
                        correctPesel = pc.AmountOfNumbersCheck(tmpPesel);
                        correctPesel = pc.ChecksumOfLastNumberCheck(tmpPesel);

                    }
                    catch (NotCorrectLengthException lengthEx)
                    {
                        Console.WriteLine(lengthEx.Message);
                        break;
                    }
                    catch (NotCorrectChecksumException sumEx)
                    {
                        Console.WriteLine(sumEx.Message);
                        break;
                    }
                    pesel = value;
                }

                
            }
        }
    }
}
