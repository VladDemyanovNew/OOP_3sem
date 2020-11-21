using System;

namespace OOP_Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            Accountant Pasha = new Accountant(1300);
            Developer Vasya = new Developer(2000);
            Director director = new Director();

            director.SalaryEvent += Pasha.SalaryInfo;
            director.SalaryEvent += Vasya.SalaryInfo;

            director.AddFail(Vasya);
            director.AddFail(Vasya);
            director.AddFail(Vasya);
        }
    }
}
