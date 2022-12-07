using System;
using System.Collections.Generic;
using System.Text;

namespace PersonMaker.Logic
{
    public class PersonsList
    {
        private readonly List<Person> _people = new List<Person>();
        public List<Person> GetList()
        {
            return _people;
        }

        public void DuplicatesInListDelete(string pesel)
        {
            int index = _people.FindIndex(person => person.Pesel.ToString() == (pesel));

            if (index != -1)
            {
                _people.Remove(_people[index]);
            }
        }

        public void AddPerson(Person p)
        {
            _people.Add(p);
        }
    }
}
