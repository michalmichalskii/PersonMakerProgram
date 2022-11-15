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

    class UserInterface
    {
        readonly Entries appLogic = new Entries();
        readonly SaveListToFile toFile = new SaveListToFile();
        readonly ListModifier listModifier = new ListModifier();

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

            bool isCorrectKey = false;

            ConsoleKey key;
            while (!isCorrectKey)
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

            }
            return false; // to nigdy sie nie stanie (CHYBA)
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
                    person.City = appLogic.EnteringCity(city, person);

                    if (person.City == null)
                    {
                        ErrorCall("Wypełnij pole!");
                    }

                } while (person.City == null);


                do
                {
                    Console.WriteLine("Podaj imie:");
                    string name = Console.ReadLine();

                    person.Name = appLogic.EnteringName(name, person);

                    if (person.Name == null)
                    {
                        ErrorCall("Wypełnij pole!");
                    }

                } while (person.Name == null);

                do
                {
                    Console.WriteLine("Podaj nazwisko:");
                    string surrname = Console.ReadLine();

                    person.SurrName = appLogic.EnteringSurrname(surrname, person);

                    if (person.SurrName == null)
                    {
                        ErrorCall("Wypełnij pole!");
                    }

                } while (person.SurrName == null);

                do
                {
                    Console.WriteLine("Podaj pesel:");
                    string pesel = Console.ReadLine();

                    person.Pesel = appLogic.EnteringPesel(pesel, person);

                    if (person.Pesel == null)
                    {
                        ErrorCall("Numer pesel jest niepoprwny - popraw go!");
                    }

                } while (person.Pesel == null);

                listModifier.DuplicatesInListChecking(person.Pesel, listModifier.people);

                listModifier.people.Add(person);

                ending = ProgramEnding();

            } while (ending == true);

            toFile.SavingToFile(listModifier.GetList());
        }
    }
}
