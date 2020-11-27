using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;
using Microsoft.VisualBasic;

namespace OOP_Lab10
{
    class MyCollection<T>
    {
        private ConcurrentBag<T> list;

        public MyCollection()
        {
            list = new ConcurrentBag<T>();
        }
        
        // Методы 
        public bool RemoveElement(out T item)
        {
            if (!list.TryTake(out item))
            {
                Console.WriteLine("Отказано в доступе!");
                return false;
            }
            return true;   
        }

        public bool GetElement(out T item)
        {
            if (!list.TryPeek(out item))
            {
                Console.WriteLine("Отказано в доступе!");
                return false;
            }
            return true;
        }

        public void Add(T item)
        {
            list.Add(item);
        }

        public int Count()
        {
            return list.Count;
        }

        public void Print()
        {
            if (list.Count == 0)
                Console.WriteLine("Контейнер пуст!");
            else
            {
                Console.WriteLine();
                foreach (T item in list)
                {
                    Console.Write($"\t{item}");
                }
                Console.WriteLine();
            } 
        }
    }
}
