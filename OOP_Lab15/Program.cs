using System;
using System.IO;
using System.Threading;

namespace OOP_Lab15
{
    class Program
    {
        static void Main(string[] args)
        {
            //  1.
            Reseacher.PrintProcessesInfo();
            //  2.
            Reseacher.PrintDomainInfo();

            //  3.
            Console.WriteLine("\nЗадние 3:");
            Thread firstThread = new Thread(new ThreadStart(Reseacher.PrintNumbers));
            firstThread.Start();

            Thread.Sleep(4000);
            Console.WriteLine("Главный поток:");
            Thread t = Thread.CurrentThread;
            t.Name = "Main";
            Console.WriteLine($"Имя потока: {t.Name}");
            Console.WriteLine($"Запущен ли поток: {t.IsAlive}");
            Console.WriteLine($"Приоритет потока: {t.Priority}");
            Console.WriteLine($"Статус потока: {t.ThreadState}");
            for (int i = 10; i <= 50; i += 10)
            {
                Console.WriteLine(i);
            }

            //  4.
            Console.WriteLine("\nЗадние 4:");
            MyThread t1 = new MyThread(Reseacher.MakeComputation, "FirstComputation", ThreadPriority.Lowest);
            MyThread t2 = new MyThread(Reseacher.MakeComputation, "SecondComputation", ThreadPriority.Lowest);
            MyThread t3 = new MyThread(Reseacher.FirstComputation, "FirstComputation1", ThreadPriority.Lowest);
            MyThread t4 = new MyThread(Reseacher.SecondComputation, "SecondComputation1", ThreadPriority.Lowest);
            Thread.Sleep(6000);

            //  5.
            Console.WriteLine("\nЗадние 5:");
            // установка метода обратного вызова
            TimerCallback tm = new TimerCallback(Reseacher.Count);
            // создание таймера
            Timer timer = new Timer(tm, 2, 0, 2000);
        }
    }
}
