using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OOP_Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Задание 1
            Exercise1Start();
            //  Задание 2
            Exercise2Start();
            //  Задание 3
            Exercise3Start();
        }

        static void Exercise1Start()
        {
            Console.WriteLine("\nЗадание 1\n");
            Products products = new Products(3);
            products.Add("Product1", 10);
            products.Add("Product2", 20);
            products.Add("Product3", 30);

            products.DisplayCollection();

            products["Product1"] = 150;
            products.Remove("Product2");
            products.Insert(0, "Product4", 44);

            products.DisplayCollection();
        }

        static void Exercise2Start()
        {
            Console.WriteLine("\nЗадание 2\n");
            MyCollection<int> collection1 = new MyCollection<int>();
            collection1.Add(10);
            collection1.Add(11);
            collection1.Add(12);
            collection1.Add(13);
            collection1.Print();

            Dictionary<string, int> collection2 = new Dictionary<string, int>();
            string key = "key";
            int item2, i = 0;
            while (collection1.RemoveElement(out item2))
            {
                collection2.Add(key + i++, item2);
            }

            Console.Write("\nВывод collection2: ");
            foreach (var de in collection2)
            {
                Console.Write($"\t{ de.Key}:{de.Value}");
            }
            Console.WriteLine();

            Console.WriteLine("\nkey2: " + collection2["key2"]);
        }

        static void Exercise3Start()
        {
            Console.WriteLine("\nЗадание 3\n");
            ObservableCollection<Product> products = new ObservableCollection<Product>();
            products.CollectionChanged += Product.Users_CollectionChanged;
            products.Add(new Product("Milk", 2));
            products.Add(new Product("Apple", 4));
            products.Add(new Product("Orange", 3));
            products.RemoveAt(2);
        }
    }
}
