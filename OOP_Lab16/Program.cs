using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OOP_Lab16
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
#if false
                Ex1(50);
#endif
#if false
                Ex2(50);
#endif
#if false
                Ex3();
#endif
#if false
                Ex4();
#endif
#if false
                Ex5();
#endif
#if false
                Warehouse warehouse = new Warehouse();
                Task[] producers = new Task[]
                {
                   Task.Factory.StartNew(() => warehouse.Producer(2)),
                   Task.Factory.StartNew(() => warehouse.Producer(1)),
                   Task.Factory.StartNew(() => warehouse.Producer(3)),
                   Task.Factory.StartNew(() => warehouse.Producer(2)),
                   Task.Factory.StartNew(() => warehouse.Producer(2))
                };
                Task[] consumers = new Task[]
                {
                    Task.Factory.StartNew(() => warehouse.Consumer()),
                    Task.Factory.StartNew(() => warehouse.Consumer()),
                    Task.Factory.StartNew(() => warehouse.Consumer()),
                    Task.Factory.StartNew(() => warehouse.Consumer()),
                    Task.Factory.StartNew(() => warehouse.Consumer()),
                    Task.Factory.StartNew(() => warehouse.Consumer()),
                    Task.Factory.StartNew(() => warehouse.Consumer()),
                    Task.Factory.StartNew(() => warehouse.Consumer()),
                    Task.Factory.StartNew(() => warehouse.Consumer()),
                    Task.Factory.StartNew(() => warehouse.Consumer())
                };

                try
                {
                    Task.WaitAll(producers.Concat(consumers).ToArray());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    foreach (var pr in producers)
                    {
                        pr.Dispose();
                    }

                    foreach (var cons in consumers)
                    {
                        cons.Dispose();
                    }
                }
#endif
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
                Console.WriteLine($"Метод: {ex.TargetSite}");
            }
        }

        static void Ex1(int n)
        {
            int i = 3;
            Stopwatch sw = new Stopwatch();

            while (i > 0)
            {
                sw.Start();
                Task<List<int>> task = new Task<List<int>>(() => SieveEratosthenes(n));
                task.Start();
                Console.WriteLine($"Простые числа: {String.Join(", ", task.Result)}");
                Console.WriteLine($"Номер задачи: {i}\nID: {task.Id}");
                Console.WriteLine($"Статус: {task.Status}");
                task.Wait();
                sw.Stop();
                Console.WriteLine($"Время выполнения задачи: {sw.Elapsed}");
                Console.WriteLine();
                sw.Reset();
                i--;
            }
        }

        static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        static CancellationToken token = cancelTokenSource.Token;

        static void Ex2(int n)
        {
            int i = 3;
            Stopwatch sw = new Stopwatch();

            while (i > 0)
            {
                sw.Start();
                Task<List<int>> task = new Task<List<int>>(() => SieveEratosthenes(n));
                task.Start();
                Console.WriteLine($"Простые числа: {String.Join(", ", task.Result)}");
                Console.WriteLine($"Номер задачи: {i}\nID: {task.Id}");
                Console.WriteLine($"Статус: {task.Status}");

                Console.WriteLine("Введите Y для отмены операции или другой символ для ее продолжения:");
                string s = Console.ReadLine();
                if (s == "Y")
                    cancelTokenSource.Cancel();
                task.Wait();
                sw.Stop();
                Console.WriteLine($"Время выполнения задачи: {sw.Elapsed}");
                Console.WriteLine();
                sw.Reset();
                i--;
            }
        }

        static int Sum (int x, int y) => x + y;
        static int Mul(int x, int y) => x * y;
        static int Dif(int x, int y) => x - y;

        static void Ex3()
        {
            Task<int> task1 = new Task<int>(() => Sum(2, 3));
            Task<int> task2 = new Task<int>(() => Mul(2, 3));
            Task<int> task3 = new Task<int>(() => Dif(2, 3));

            task1.Start();
            task2.Start();
            task3.Start();

            task1.ContinueWith(result => Display(result.Result));
            task2.ContinueWith(result => Display(result.Result));
            task3.ContinueWith(result => Display(result.Result));
        }

        static void Display(int result)
        {
            Console.WriteLine($"Результат: {result}");
            Console.WriteLine();
        }

        static void Ex4()
        {
            Stopwatch sw = Stopwatch.StartNew();
            Parallel.For(0, 10, (x) =>
            {
                int[] arr = new int[1000000];
                int i = 0;
                Parallel.ForEach(arr, (elem) =>
                {
                    elem = i;
                    i++;
                });
            });
            sw.Stop();
            Console.WriteLine($"Время выполнения задачи 1: {sw.Elapsed}");
            Console.WriteLine();
            sw.Reset();
            sw.Start();
            for (int j = 0; j < 10; j++)
            {
                int[] arr = new int[1000000];
                for (int k = 0; k < arr.Length; k++)
                {
                    arr[k] = k;
                }
            }
            sw.Stop();
            Console.WriteLine($"Время выполнения задачи 2: {sw.Elapsed}");
            Console.WriteLine();
        }

        static void Ex5()
        {
            Parallel.Invoke(
                () => {
                    Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                    //Thread.Sleep(3000);
                },
                () => {
                    Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                    //Thread.Sleep(3000);
                },
                () => {
                    Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                    //Thread.Sleep(3000);
                }
            );
        }

        static List<int> SieveEratosthenes(int n)
        {
            var numbers = new List<int>();
            //  заполнение списка числами от 2 до n-1
            for (var i = 2; i < n; i++)
            {
                numbers.Add(i);
            }

            for (var i = 0; i < numbers.Count; i++)
            {
                for (var j = 2; j < n; j++)
                {
                    //  удаляем кратные числа из списка
                    numbers.Remove(numbers[i] * j);
                }
            }

            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Операция прервана");
                return null;
            }

            return numbers;
        }


    }
}
