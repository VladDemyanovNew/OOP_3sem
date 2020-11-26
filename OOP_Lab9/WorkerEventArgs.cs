using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab9
{
    class WorkerEventArgs
    {
        public string Message { get; }
        public int SalaryOperation { get; set; }
        public int Salary { get; }
        public int StartingSalary { get; }

        public WorkerEventArgs(string Message, int Salary, int StartingSalary)
        {
            this.Message = Message;
            this.Salary = Salary;
            this.StartingSalary = StartingSalary;
        }
    }
}
