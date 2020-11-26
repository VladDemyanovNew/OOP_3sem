using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab9
{
    class Director
    {
        public void Penalize(Worker sender, WorkerEventArgs e)
        {
            int penalty = 0;
            if (sender is Developer)
                penalty = 600;
            if (sender is Accountant)
                penalty = 300;

            int salary = e.Salary;
            if (salary - penalty >= 300)
            {
                salary -= penalty;
                sender.SetSalary(salary);
                e.SalaryOperation = penalty;
            }
            e.SalaryOperation = penalty;
        }

        public void IncreaseSalaries(Worker sender, WorkerEventArgs e)
        {
            int prize = 0;
            if (sender is Developer)
                prize = 1000;
            if (sender is Accountant)
                prize = 500;

            int salary = e.Salary;
            salary += prize;
            sender.SetSalary(salary);
            e.SalaryOperation = prize;
        }

        public void SalaryInfo(Worker sender, WorkerEventArgs e)
        {
            Console.WriteLine("\n");
            Console.WriteLine($"Имя: {sender.Name}");
            Console.WriteLine(e.Message);
            Console.WriteLine($"Первоначальная зарплата: {e.StartingSalary}");
            Console.WriteLine($"Транзакция: {e.SalaryOperation}");
            Console.WriteLine($"Текущая зарплата: {sender.Salary}");
            Console.WriteLine("\n");
        }

    }
}
