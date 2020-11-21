using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab9
{
    class Director
    {
        public delegate void DirectorHandler(object sender, DirectorEventArgs e);
        public event DirectorHandler SalaryEvent;
        public void AddFail(Worker w)
        {
            w.FailsCount++;
            if (w.FailsCount == 3)
            {
                w.FailsCount = 0;
                Penalize(w, 300);
            }
        }

        public void AddSuccess(Worker w)
        {
            w.SuccessCount++;
            if (w.SuccessCount == 3)
            {
                w.SuccessCount = 0;
                IncreaseSalaries(w, 300);
            }
        }

        public void Penalize(Worker w, int penalty)
        {
            int salary = w.Salary;
            if (salary - penalty >= 300)
            {
                salary -= penalty;
                w.SetSalary(salary);
                SalaryEvent?.Invoke(this, new DirectorEventArgs($"Вы оштрафованы на {penalty}.", penalty));
            }
        }

        public void IncreaseSalaries(Worker w, int prize)
        {
            int salary = w.Salary;
            salary += prize;
            w.SetSalary(salary);
            SalaryEvent?.Invoke(this, new DirectorEventArgs($"Вам начислена премия {prize}.", prize));
        }
    }
}
