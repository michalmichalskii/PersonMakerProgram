using System;
using System.Collections.Generic;
using System.Text;

namespace PersonMaker.Exceptions
{
    class NotCorrectLengthException : ApplicationException
    {
        public NotCorrectLengthException(string text) : base(text)
        {
            
        }
    }
}
