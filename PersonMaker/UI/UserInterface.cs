using PersonMaker.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonMaker.UI
{
    //fake pesels
    //12345678910
    //02070803628
    //90090515836
    //92071314764
    //81100216357
    //80072909146

    public class UserInterface
    {
        private readonly FileSaver _fileSaver;
        private readonly PersonsList _personsList;

        public UserInterface(FileSaver fileSaver, PersonsList personsList)
        {
            _fileSaver = fileSaver;
            _personsList = personsList;
        }

        public void ErrorCall(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ResetColor();
        }
        public void ConfirmCall(string call)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(call);
            Console.ResetColor();
        }
        public bool ProgramEnding()
        {
            ConsoleKey key;
            do
            {
                Console.WriteLine("Czy chcesz dodac kolejna osobe? [t/n]");
                key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.T:

                        Console.WriteLine();
                        Console.Clear();

                        return true;

                    case ConsoleKey.N:

                        Console.WriteLine();

                        return false;

                    default:
                        Console.WriteLine();
                        ErrorCall("Podano niepoprawny przycisk");
                        break;

                }

            } while (true);
            
        }
        public void MainUI()
        {
            bool ending;
            do
            {
                Person person = new Person();
                
                do
                {
                    Console.WriteLine("Podaj miasto:");
                    string city = Console.ReadLine();
                    person.City = city;

                    if (person.City == null)
                    {
                        ErrorCall("Wypełnij pole!");
                    }

                } while (person.City == null);


                do
                {
                    Console.WriteLine("Podaj imie:");
                    string name = Console.ReadLine();

                    person.Name = name;

                    if (person.Name == null)
                    {
                        ErrorCall("Wypełnij pole!");
                    }

                } while (person.Name == null);

                do
                {
                    Console.WriteLine("Podaj nazwisko:");
                    string surrname = Console.ReadLine();

                    person.SurrName = surrname;

                    if (person.SurrName == null)
                    {
                        ErrorCall("Wypełnij pole!");
                    }

                } while (person.SurrName == null);

                do
                {
                    Console.WriteLine("Podaj pesel:");
                    string pesel = Console.ReadLine();

                    person.Pesel = pesel;

                } while (person.Pesel == null);

                _personsList.DuplicatesInListDelete(person.Pesel);

                _personsList.AddPerson(person);

                ending = ProgramEnding();

            } while (ending == true);

            _fileSaver.SaveToFile(_personsList.GetList());
        }
    }
}
