using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab9
{
    class Worker
    {
        public delegate void WorkerHandler(Worker sender, WorkerEventArgs e);
        public event WorkerHandler PenalizeEvent;
        public event WorkerHandler IncreaseEvent;
        public int Salary { get; private set; }
        public int FailsCount { get; set; }
        public int SuccessCount { get; set; }
        public int StartingSalary { get; private set; }
        public string Name { get; }
        public Worker (int salary, string name)
        {
            Salary = salary;
            StartingSalary = salary;
            Name = name;
        }

        public void SetSalary(int salary)
        {
            Salary = salary;
        }

        public void AddFail()
        {
            FailsCount++;
            if (FailsCount == 3)
            {
                FailsCount = 0;
                PenalizeEvent?.Invoke(this, new WorkerEventArgs($"Вы оштрафованы!", Salary, StartingSalary));
            }
        }

        public void AddSuccess()
        {
            SuccessCount++;
            if (SuccessCount == 3)
            {
                SuccessCount = 0;
                IncreaseEvent?.Invoke(this, new WorkerEventArgs($"Вам начислена премия!", Salary, StartingSalary));
            }
        }
    }
}
