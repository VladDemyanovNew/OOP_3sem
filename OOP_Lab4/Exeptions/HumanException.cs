using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab4
{
    class HumanException : HeaderException
    {
        public HumanException (string message, int code)
            : base(message)
        {
            errorCode = code;
        }

        public override void ExceptionHandler()
        {
            Console.WriteLine("Дополнительная информация: Исключение для класса Humman.");
        }
    }
}
