using System;

namespace PersonMaker
{
    public class Person
    {
        

        private string city;

        public string City
        {
            get { return city; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {

                }
                else
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    
                }
                else
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
                else
                {
                    
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
                bool isCorrectAmount = pc.AmountOfNumbersChecking(tmpPesel);
                if (isCorrectAmount)
                {
                    bool isCorrectChecksum = pc.ChecksumOfLastNumberChecking(tmpPesel);
                    if (isCorrectChecksum)
                    {
                        pesel = value;
                    }
                }

            }
        }
    }
}
