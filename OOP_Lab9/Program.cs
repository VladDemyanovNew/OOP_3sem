using System;
using System.Linq;

namespace OOP_Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            Accountant Pasha = new Accountant(1300, "Паша");
            Developer Vasya = new Developer(2000, "Вася");
            Director director = new Director();

            Vasya.PenalizeEvent += director.Penalize;
            Vasya.PenalizeEvent += director.SalaryInfo;

            Vasya.IncreaseEvent += director.IncreaseSalaries;
            Vasya.IncreaseEvent += director.SalaryInfo;

            Pasha.PenalizeEvent += director.Penalize;
            Pasha.PenalizeEvent += director.SalaryInfo;

            Pasha.IncreaseEvent += director.IncreaseSalaries;
            Pasha.IncreaseEvent += director.SalaryInfo;

            Vasya.AddFail();
            Vasya.AddFail();
            Vasya.AddFail();

            Pasha.AddFail();
            Pasha.AddFail();
            Pasha.AddFail();

            Vasya.AddSuccess();
            Vasya.AddSuccess();
            Vasya.AddSuccess();

            Pasha.AddSuccess();
            Pasha.AddSuccess();
            Pasha.AddSuccess();

            MyString str = new MyString("    Test1,Test2,Test3,Test4    ");
            str.Print();
            str.MakeString(str => str.Trim());
            str.MakeString(str => String.Join(" ", str.Split(',')));
            str.Print();

        }
    }
}
