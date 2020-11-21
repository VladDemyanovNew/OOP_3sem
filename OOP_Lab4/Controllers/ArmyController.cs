using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

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
            return result;
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
            return result;
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

        public static Army fillArmyFromJSON(string path, Army army)
        {
            using (StreamReader fs = new StreamReader(path))
            {
                string json = fs.ReadToEnd();
                List<Transformer> items = JsonConvert.DeserializeObject<List<Transformer>>(json);
                army.Add(items.ToArray());
            }
            return army;
        }

    public static Army fillArmyFromTXT(string path, Army army)
        {
            using (StreamReader f = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                string[] str = new string[] { };
                int index = 0;
                
                while ((line = f.ReadLine()) != null)
                {
                    str = line.Split(' ');
                    if (str[0] == "Human")
                    {
                        Human human = new Human();
                        for (int i = 1; i < str.Length; i++)
                        {
                            switch (i)
                            {
                                case 1:
                                    human.IQ = Int32.Parse(str[i]);
                                    break;
                                case 2:
                                    human.Name = str[i];
                                    break;
                                case 3:
                                    human.Year = Int32.Parse(str[i]);
                                    break;
                            }
                        }
                        army.Add(human);
                    }
                    else if (str[0] == "Transformer")
                    {
                        Transformer transformer = new Transformer();
                        for (int i = 1; i < str.Length; i++)
                        {
                            switch (i)
                            {
                                case 1:
                                    transformer.IQ = Int32.Parse(str[i]);
                                    break;
                                case 2:
                                    transformer.Name = str[i];
                                    break;
                                case 3:
                                    transformer.Year = Int32.Parse(str[i]);
                                    break;
                                case 4:
                                    transformer.MaxSpeed = Int32.Parse(str[i]);
                                    break;
                                case 5:
                                    transformer.Weight = Int32.Parse(str[i]);
                                    break;
                                case 6:
                                    transformer.Power = Int32.Parse(str[i]);
                                    break;
                            }       
                        }
                        army.Add(transformer);
                    }
                    else
                    {
                        Console.WriteLine($"\tНе распознан объект. Строка №{index}.");
                    }
                    index++;
                }
            }
            return army;
        }
    }
}
