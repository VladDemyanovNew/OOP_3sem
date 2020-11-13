using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.IO;
using System.Text.Json;

namespace OOP_Lab8
{
    class CollectionType<T> : ICollection<T>
    {
        private List<T> array;

        public CollectionType()
        {
            array = new List<T>();

        }

        public void AddItems(params T[] items)
        {
            array.AddRange(items);
        }

        public void DeleteItem(int index)
        {
            array.RemoveAt(index);
        }

        public T[] GetItems()
        {
            return array.ToArray();
        }

        public static CollectionType<T> fillCollectionFromJSON(string path, CollectionType<T> collection)
        {
            using (StreamReader fs = new StreamReader(path))
            {
                string json = fs.ReadToEnd();
                List<T> items = JsonConvert.DeserializeObject<List<T>>(json);
                collection.AddItems(items.ToArray());
            }
            return collection;
        }

        public static void writeInJSON(string path, CollectionType<T> collection)
        {
            using (StreamWriter w = new StreamWriter(path, true))
            {
                string json = JsonConvert.SerializeObject(collection.array);
                w.Write(json);
            }
        }
    }
}
