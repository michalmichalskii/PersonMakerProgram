using PersonMaker.Logic;
using PersonMaker.UI;
using System.Collections.Generic;
using System.Linq;

namespace PersonMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonsList personsList = new PersonsList();
            FileSaver fileSaver = new FileSaver("people.txt");


            UserInterface UI = new UserInterface(fileSaver,personsList);
            UI.MainUI();

        }

    }
}
