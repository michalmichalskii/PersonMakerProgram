using PersonMaker.Exceptions;
using PersonMaker.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonMaker.Logic
{
    public class PeselChecker
    {
        readonly UserInterface ui = new UserInterface();

        public bool AmountOfNumbersCheck(string pesel)
        {
            if (string.IsNullOrEmpty(pesel) || pesel.Length != 11) 
            {
                ui.NotCorrectLengthCall();
                return false;
                //throw (new NotCorrectLengthException("\nDługść numeru pesel jest niepoprawna!\n"));
            }
            else
            {
                return true;
            }

        }

        public bool ChecksumOfLastNumberCheck(string pesel)
        {
            int summary = 0;
            for (int i = 0; i < pesel.Length - 1; i++)
            {
                int importance;
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

                if (cyfraKontrolna != int.Parse(pesel[10].ToString()))
                {
                    ui.NotCorrectCheckSumCall();
                    return false;
                    //throw (new NotCorrectChecksumException("Suma kontrolna numeru pesel jest niepoprawna!"));
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (modulo != int.Parse(pesel[10].ToString()))
                {
                    ui.NotCorrectCheckSumCall();
                    return false;
                    //throw (new NotCorrectChecksumException("\nSuma kontrolna numeru pesel jest niepoprawna!\n"));
                }
                else
                {
                    return true;
                }
            }

        }



    }
}
