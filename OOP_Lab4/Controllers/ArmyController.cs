using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab4
{
    class ArmyController
    {
        public static Army findElementByYear(Army army, int year)
        {
            Army result = new Army();
            foreach (ISentientBeing item in army.armyList)
            {
                if (item.Year == year)
                    result.Add(item);
            }
            if (result.armyList.Count == 0)
            {
                Console.WriteLine($"\tСписок пуст.");
                return null;
            }
            else
            {
                return result;
            }
        }

        public static Army findTransformersByPower(Army army, int power)
        {
            Army result = new Army();
            foreach (ISentientBeing item in army.armyList)
            {
                if (item is Transformer && ((Transformer)item).Power == power)
                {
                    result.Add(item);
                }
            }
            if (result.armyList.Count == 0)
            {
                Console.WriteLine($"\tСписок пуст.");
                return null;
            }
            else
            {
                return result;
            }
        }

        public static int sizeOfArmy(Army army)
        {
            if (army.armyList.Count == 0)
            {
                Console.WriteLine($"\tСписок пуст.");
                return 0;
            }
            else
            {
                return army.armyList.Count;
            }
        }
    }
}
