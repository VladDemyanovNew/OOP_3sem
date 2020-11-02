using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab4
{
    class Army
    {
        public List<ISentientBeing> armyList;

        public Army()
        {
            armyList = new List<ISentientBeing>();
        }

        // Индексатор
        public ISentientBeing this[int index]
        {
            get
            {
                if (index > armyList.Count || index < 0)
                {
                    Console.WriteLine($"\tВы ввели неправильный индексатор.");
                    return null;
                }
                else 
                {
                    return armyList[index];
                }
            }

            set
            {
                if (index > armyList.Count || index < 0)
                {
                    Console.WriteLine($"\tВы ввели неправильный индексатор.");
                }
                else
                {
                    armyList[index] = value;
                }
            }
        }

        // Методы 
        public void Delete(int index)
        {
            armyList.RemoveAt(index);
        }
        
        public void Add(params ISentientBeing[] items)
        {
            armyList.AddRange(items);
        }

        public void PrintList()
        {
            if (armyList.Count == 0)
            {
                Console.WriteLine($"\tСписок пуст.");
            }
            else
            {
                
                foreach (ISentientBeing item in armyList)
                {
                    Console.WriteLine($"Элемент №{armyList.IndexOf(item)} : {item.ToString()}");
                }
            }
        }
    }
}
