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
                Logic logic = new Logic();
                PeselChecker pc = new PeselChecker();
                bool isCorrectAmount = pc.AmountOfNumbersChecking(value);
                bool isCorrectChecksum = pc.ChecksumOfLastNumberChecking(value);
                
                if (isCorrectAmount && isCorrectChecksum)
                {
                    pesel = value;
                }

                logic.DuplicatesChecking(value);
            }
        }
        //public Person()
        //{

        //}
        //public Person(string name_, string surrName_, string city_, string pesel_)
        //{
        //    name = name_;
        //    surrName = surrName_;
        //    city = city_;
        //    pesel = pesel_;
        //}
        
    }
}
