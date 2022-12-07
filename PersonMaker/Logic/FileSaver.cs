using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PersonMaker.Logic
{
    
    public class FileSaver
    {
        private readonly string _fileName;
        public FileSaver(string fileName)
        {
            _fileName = fileName;
        }

        public void SaveToFile(List<Person> people)
        {
            using StreamWriter sw = new StreamWriter(_fileName);
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
