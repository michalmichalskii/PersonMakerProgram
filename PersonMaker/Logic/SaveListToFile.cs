using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PersonMaker.Logic
{
    
    public class SaveListToFile
    {
        public const string filePath = "people.txt";

        public void SavingToFile(List<Person> people)
        {
            using StreamWriter sw = new StreamWriter("people.txt");
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
