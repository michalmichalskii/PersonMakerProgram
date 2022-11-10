using System;
using System.Collections.Generic;
using System.Text;

namespace PersonMaker.UI
{
    //fake pesels
    //12345678910
    //02262602930
    //02070803628
    class UserInterface
    {
        readonly Logic logic = new Logic();
        readonly SaveListToFile toFile = new SaveListToFile();
        

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
        
        public void MainUI()
        {
            do
            {
                PeselChecker pc = new PeselChecker();
                Person person = new Person();
                do
                {
                    Console.WriteLine("Podaj miasto:");
                    string city = Console.ReadLine();
                    person.City = logic.EnteringCity(city);

                    if (person.City == null)
                    {
                        ErrorCall("Wypełnij pole!");
                    }

                } while (person.City == null);


                do
                {
                    Console.WriteLine("Podaj imie:");
                    string name = Console.ReadLine();

                    person.Name = logic.EnteringName(name);

                    if (person.Name == null)
                    {
                        ErrorCall("Wypełnij pole!");
                    }

                } while (person.Name == null);

                do
                {
                    Console.WriteLine("Podaj nazwisko:");
                    string surrname = Console.ReadLine();

                    person.SurrName = logic.EnteringSurrname(surrname);

                    if (person.SurrName == null)
                    {
                        ErrorCall("Wypełnij pole!");
                    }

                } while (person.SurrName == null);

                do
                {
                    Console.WriteLine("Podaj pesel:");
                    string pesel = Console.ReadLine();

                    person.Pesel = logic.EnteringPesel(pesel);
                    
                    if (person.Pesel == null)
                    {
                        ErrorCall("Wypełnij pole!");
                    }

                } while (person.Pesel == null);

                logic.AddingToList(person);
                toFile.SavingToFile(Logic.people);

            } while (Logic.people.Count != 3);

            //foreach (var p in Logic.people)
            //{
            //    Console.WriteLine($"{p.City}, {p.Name}, {p.SurrName}, {p.Pesel}");
            //}
            //Console.ReadKey();
        }
    }
}
