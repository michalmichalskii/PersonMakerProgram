using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PersonMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new Logic();
            logic.MainUI();
        }

    }
    public class Logic
    {
        private const string path = @"../../../../people.txt";

        public void MainUI()
        {
            List<Person> people = new List<Person>();
            List<string> pesele = new List<string>();

            char answ;
            do
            {
                Person person = new Person();

                Console.WriteLine("Miasto:");
                person.city = Console.ReadLine();


                Console.WriteLine("Podaj Imie:");
                person.name = Console.ReadLine();

                Console.WriteLine("Podaj Nazwisko:");
                person.lastName = Console.ReadLine();

                do
                {
                    Console.WriteLine("Podaj Pesel:");
                    person.Pesel = Console.ReadLine();
                } while (person.Pesel==null);


                pesele.Add(person.Pesel);

                DuplicateChecker(pesele, people, person);

                people.Add(person);

                ConfirmCall("Osoba została dodana!");
                Console.WriteLine();
                Console.WriteLine(@"czy chcesz dodac kolejną osobe? [t\n]");
                answ = Console.ReadLine()[0];
                Console.Clear();

            } while (answ != 'n');

            SaveListToFile(people);
        }
        public void SaveListToFile(List<Person> people)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (Person p in people)
                {
                    if (p.Pesel != null)
                    {
                        sw.WriteLine($"{p.city},{p.name},{p.lastName},{p.Pesel}");
                    }

                }
            }
        }
        public void DuplicateChecker(List<string> pesele, List<Person> people, Person person)
        {
            for (int j = 0; j < pesele.Count - 1; j++)
            {
                if (person.Pesel == pesele[j])
                {
                    Console.WriteLine("Osoba o danym peselu już istniała, ale została nadpisana!");
                    people.RemoveAt(j);
                }
            }
        }
        public void ConfirmCall(string call)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(call);
            Console.ResetColor();
        }

    }
    public class Person
    {
        public string city { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }

        private string pesel;

        public string Pesel
        {
            get { return pesel; }
            set
            {
                bool isCorrect = CheckCorrectPesel(value);

                if (isCorrect)
                {
                    pesel = value;
                }

            }
        }
        public void ErrorCall(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ResetColor();
        }
        public bool CheckCorrectPesel(string pesel)
        {
            if (pesel.Length == 11)
            {
                int summary = 0;
                for (int i = 0; i < pesel.Length - 1; i++)
                {
                    int importance = 0;
                    if (i == 0 || i == 4 || i == 8)
                    {
                        importance = 1;
                    }
                    else if (i == 1 || i == 5 || i == 9)
                    {
                        importance = 3;
                    }
                    else if (i == 2 || i == 6)
                    {
                        importance = 7;
                    }
                    else
                    {
                        importance = 9;
                    }

                    int a = int.Parse(pesel[i].ToString());
                    a *= importance;
                    summary += a;
                }
                int modulo = summary % 10;
                if (!(modulo == 0))
                {
                    int cyfraKontrolna = 10 - modulo;
                    if (cyfraKontrolna == pesel[10])
                    {
                        return true;
                    }
                    else
                    {
                        ErrorCall("Osoba nie zostala dodana. Powod - zly numer kontrolny");
                        return false;
                    }
                }
                else
                {
                    if (modulo == int.Parse(pesel[10].ToString()))
                    {
                        return true;
                    }
                    else
                    {
                        ErrorCall("Osoba nie zostala dodana. Powod - zly numer kontrolny");
                        return false;
                    }
                }

            }
            else
            {
                ErrorCall($"Osoba nie zostala dodana. Powod - niepoprawny numer pesel");
                return false;
            }

        }
    }
}
