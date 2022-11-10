using PersonMaker.UI;
using System;
using System.Collections.Generic;
using System.IO;

namespace PersonMaker
{
    public class Logic
    {

        public const string filePath = "people.txt";

        public Person person = new Person();
        

        public static List<Person> people = new List<Person>();
        //public List<Person> GetList()
        //{
        //    return people;
        //}

        public string EnteringCity(string city)
        {
            person.City = city;
            return person.City;
        }
        public string EnteringName(string name)
        {

            person.Name = name;
            return person.Name;

        }
        public string EnteringSurrname(string surrName)
        {
            person.SurrName = surrName;
            return person.SurrName;
        }
        public string EnteringPesel(string pesel)
        {
            person.Pesel = pesel;
            return person.Pesel;
        }
        public void DuplicatesChecking(string pesel)
        {
            List<Person> people = Logic.people;

            //if(people.Any(x => x.Pesel.Contains(pesel)))
            //{
            //    people.Remove(ui.person);
            //}

            int index = people.FindIndex(x => x.Pesel.ToString() == (pesel));

            if (index != -1)
            {
                people[index] = person;
            }


        }
        public Person GetPerson()
        {
            return person;
        }
        public void AddingToList(Person person)
        { 
            Logic.people.Add(person);
        }

    }
}
