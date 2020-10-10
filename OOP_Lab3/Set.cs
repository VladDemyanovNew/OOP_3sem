using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab3
{
    class Set
    {
        //  Поля
        private List<string> array;
        private Owner owner;
        private Date date;

        //  Свойства
        public List<string> Arr
        {
            get
            {
                return array;
            }
            set
            {
                array = value;
            }
        }

        //  Конструкторы
        public Set()
        {
            array = new List<string>();
            this.owner = new Owner(0, "", "");
            this.date = new Date();
        }

        public Set(int id, string name, string organization)
        {
            array = new List<string>();
            this.owner = new Owner(id, name, organization);
            this.date = new Date();
        }

        //  Методы
        public string GetListItem(int index)
        {
            return array[index];
        }

        public List<string> GetList()
        {
            return array;
        }

        public void OutputList()
        {
            string result = "";
            foreach (string item in array)
            {
                result += item + " ";  
            }
            Console.WriteLine($"\t{result}");
        }

        public void OutputOwner()
        {
            this.owner.OutputOwner();
            this.date.OutputDate();
        }

        //  Перегрузки
        public static Set operator + (Set element, string item)
        {
            element.array.Add(item);
            return element;
        }

        public static Set operator +(Set element1, Set element2)
        {
            foreach (string item in element2.array)
            {
                element1.array.Add(item);
            }
            return element1;
        }

        public static Set operator *(Set element1, Set element2)
        {
            Set result = new Set();
            element1.array.Sort();
            element2.array.Sort();
            int index;
            foreach (string item in element2.array)
            {
                index = element1.array.BinarySearch(item);
                if (index >= 0)
                    result.array.Add(item);
            }
            return result;
        }

        public static explicit operator int (Set element)
        {
            return element.array.Count;
        }

        public static bool operator false (Set element)
        {
            return element.array.Count == 0;
        }

        public static bool operator true(Set element)
        {
            return element.array.Count > 0;
        }
    }
}
