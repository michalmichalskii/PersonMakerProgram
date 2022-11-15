using PersonMaker.UI;
using System;
using System.Collections.Generic;
using System.IO;

namespace PersonMaker
{
    public class Entries
    {

        public string EnteringCity(string city, Person person)
        {
            person.City = city;
            return person.City;
        }
        public string EnteringName(string name, Person person)
        {
            person.Name = name;
            return person.Name;
        }
        public string EnteringSurrname(string surrName, Person person)
        {
            person.SurrName = surrName;
            return person.SurrName;
        }
        public string EnteringPesel(string pesel, Person person)
        {
            person.Pesel = pesel;
            return person.Pesel;
        }

    }
}
