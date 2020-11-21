using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab9
{
    class Worker
    {
        public int Salary { get; private set; }
        public int FailsCount { get; set; }
        public int SuccessCount { get; set; }
        public int StartingSalary { get; private set; }
        public Worker (int salary)
        {
            Salary = salary;
            StartingSalary = salary;
        }

        public void SetSalary(int salary)
        {
            Salary = salary;
        }

        public void SalaryInfo(object sender, DirectorEventArgs e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine($"Первоначальная зарплата: {StartingSalary}");
            Console.WriteLine($"Транзакция: {e.SalaryOperation}");
            Console.WriteLine($"Текущая зарплата: {Salary}");
        }
    }
}
