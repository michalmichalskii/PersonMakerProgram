using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PersonMaker
{
    
    class SaveListToFile
    {

        public void SavingToFile(List<Person> people)
        {
            using (StreamWriter sw = new StreamWriter("people.txt"))
            {
                foreach (Person p in people)
                {
                    if (p.Pesel != null)
                    {
                        sw.WriteLine($"{p.City},{p.Name},{p.SurrName},{p.Pesel}");
                    }

                }
            }
        }
    }
}
