using System;
using System.Collections.Generic;
using System.Text;

namespace PersonMaker.Exceptions
{
    class NotCorrectLengthException : ApplicationException
    {
        public NotCorrectLengthException()
        {
            Console.WriteLine("123");
        }
        public NotCorrectLengthException(string text) : base(text)
        {
            
        }
    }
}
