using PersonMaker.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonMaker
{
    class PeselChecker
    {
        readonly Logic logic = new Logic();

        public bool AmountOfNumbersChecking(string pesel)
        {
            return pesel.Length == 11;
        }

        public bool ChecksumOfLastNumberChecking(string pesel)
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
                if (cyfraKontrolna == int.Parse(pesel[10].ToString()))
                {
                    return true;
                }
                else
                {
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
                    return false;
                }
            }

        }

        //TODO - make a DuplicatesChecking method properly
       

    }
}
