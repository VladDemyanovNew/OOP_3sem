using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab9
{
    class DirectorEventArgs
    {
        public string Message { get; }
        public int SalaryOperation { get; }

        public DirectorEventArgs(string Message, int SalaryOperation)
        {
            this.Message = Message;
            this.SalaryOperation = SalaryOperation;
        }
    }
}
