using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Reflection;
using System.IO;
using System.Threading;

namespace OOP_Lab15
{
    static class Reseacher
    {
        // переменную будем использовать для синхронизаци
        static object locker = new object();
        private static List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public static void PrintProcessesInfo()
        {
            using (StreamWriter fs = new StreamWriter(@"./../../../Data/ProcessesInfo.txt", false))
            {
                foreach (var process in Process.GetProcesses())
                {
                    fs.WriteLine($"ID: {process.Id}  Имя: {process.ProcessName}");
                    if (process.ProcessName != "Idle")
                        fs.WriteLine($"Приоритет: {process.BasePriority}  Время запуска: {Process.GetProcessesByName(process.ProcessName)[0].StartTime}");
                    fs.WriteLine();
                }
            }
        }

        public static void PrintDomainInfo()
        {
            using (StreamWriter fs = new StreamWriter(@"./../../../Data/DomainInfo.txt", false))
            {
                AppDomain domain = AppDomain.CurrentDomain;
                fs.WriteLine($"Name: {domain.FriendlyName}");
                fs.WriteLine($"Base Directory: {domain.BaseDirectory}");
                fs.WriteLine();

                Assembly[] assemblies = domain.GetAssemblies();
                foreach (Assembly asm in assemblies)
                    fs.WriteLine(asm.GetName().Name);
            }
        }

        public static void PrintNumbers()
        {           
            Console.WriteLine("Поток 1");
            //  Информация о потоке
            Thread t = Thread.CurrentThread;
            t.Name = "PrintNumbers";
            Console.WriteLine($"Имя потока: {t.Name}");
            Console.WriteLine($"Запущен ли поток: {t.IsAlive}");
            Console.WriteLine($"Приоритет потока: {t.Priority}");
            Console.WriteLine($"Статус потока: {t.ThreadState}");

            Console.Write("Введите число: ");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
        }

        public static void MakeComputation()
        {
            lock (locker)
            {
                Thread t = Thread.CurrentThread;
                using (StreamWriter fs = new StreamWriter(@"./../../../Data/Threads.txt", true))
                {
                    fs.WriteLine(t.Name);
                    foreach (int i in numbers)
                    {
                        if (i % 2 == 0 && t.Name == "FirstComputation")
                        {
                            
                            fs.Write($"{i} ");
                        }
                        
                        if (i % 2 != 0 && t.Name == "SecondComputation")
                        {
                            fs.Write($"{i} ");
                        }
                            
                    }
                    fs.WriteLine();
                }
            }
        }

        public static void FirstComputation()
        {
            foreach (int i in numbers)
            {
                
                if (i % 2 == 0)
                    Console.Write($"{i} ");
                Thread.Sleep(300);
            }
            Console.WriteLine();
        }

        public static void SecondComputation()
        {
            foreach (int i in numbers)
            {
                Thread.Sleep(300);
                if (i % 2 != 0)
                    Console.Write($"{i} ");
                
            }
            Console.WriteLine();
        }

        public static void Count(object obj)
        {
            int x = (int)obj;
            for (int i = 1; i < 9; i++, x++)
            {
                Console.WriteLine($"{x * i}");
            }
        }
    }
}
