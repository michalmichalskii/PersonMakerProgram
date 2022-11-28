using System;
using System.Collections.Generic;
using System.Text;

namespace PersonMaker.Logic
{
    public class ListModifier
    {
        public List<Person> people = new List<Person>();
        public List<Person> GetList()
        {
            return people;
        }

        public void DuplicatesInListChecking(string pesel, List<Person> people)
        {
            int index = people.FindIndex(person => person.Pesel.ToString() == (pesel));

            if (index != -1)
            {
                people.Remove(people[index]);
            }
        }
    }
}
