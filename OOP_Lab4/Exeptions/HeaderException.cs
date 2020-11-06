using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab4
{
    abstract class HeaderException : Exception
    {
        private protected int errorCode;
        public int ErrorCode { get { return errorCode; } }
        public HeaderException(string message):base(message){}
        abstract public void ExceptionHandler();
    }
}
