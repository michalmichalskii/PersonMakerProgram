using System;
using System.Collections.Generic;
using System.Text;

namespace PersonMaker.Exceptions
{
    class NotCorrectChecksumException : ApplicationException
    {
        public NotCorrectChecksumException(string text) : base(text)
        {

        }
    }
}
