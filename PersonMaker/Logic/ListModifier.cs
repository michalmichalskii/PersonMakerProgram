using System;
using System.Collections.Generic;
using System.Text;

namespace PersonMaker.Logic
{
    class ListModifier
    {
        public void AddingToList(Person person)
        {
            AppLogic.people.Add(person);
        }
        
        public void DuplicatesInListChecking(string pesel/*, Person person*/)
        {
            List<Person> people = AppLogic.people;

            int index = people.FindIndex(person => person.Pesel.ToString() == (pesel));

            if (index != -1)
            {

                //people[index] = person;
                people.Remove(people[index]);
            }


        }
    }
}
