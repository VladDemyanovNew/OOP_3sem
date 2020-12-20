using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace OOP_Lab14
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Binary
            Car car1 = new Car(3000, 350, "car1");
            CustomSerializer<Car>.SaveBinaryFormat(car1);
            Car car2 = CustomSerializer<Car>.LoadFromBinaryFile();
            Console.WriteLine(car2.ToString());
            //  Soap
            Car car3 = new Car(4000, 250, "car3");
            CustomSerializer<Car>.SoapWriteFile(car3);
            Car car4 = CustomSerializer<Car>.LoadFromSoapFile();
            Console.WriteLine(car4.ToString());
            //  JSON
            Car car5 = new Car(6000, 400, "car5");
            CustomSerializer<Car>.JSONWriteFile(car5);
            Car car6 = CustomSerializer<Car>.LoadFromJSONFile();
            Console.WriteLine(car6.ToString());
            //  XML
            Car car7 = new Car(9000, 200, "car7");
            Car car8 = new Car(12000, 500, "car8");
            Car car9 = new Car(9000, 650, "car9");
            CustomSerializer<Car>.XMLWriteFile(new Car[]{ car7, car8, car9});
            Car[] cars1 = CustomSerializer<Car>.LoadFromXMLFile();
            Console.WriteLine(cars1[0].ToString());
            //  Arr
            Car[] cars2 = new Car[] { car1, car3, car5, car7 };
            CustomSerializer<Car>.ArrWriteFile(cars2);
            Car[] cars3 = CustomSerializer<Car>.LoadArrFromFile();
            Console.WriteLine("Вывод массива: ");
            foreach (Car car in cars3)
            {
                Console.WriteLine(car.ToString());
            }

            //  XPath
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"./../../resources/XMLData.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            //  Выбор всех дочерних узлов
            Console.WriteLine("Выбор всех дочерних узлов");
            XmlNodeList childnodes = xRoot.SelectNodes("*");
            foreach (XmlNode n in childnodes)
                Console.WriteLine(n.OuterXml);
            //  Выбор всех узлов <Car> с <Weight> 9000
            Console.WriteLine("Выбор всех узлов <Car> с <Weight> 9000");
            childnodes = xRoot.SelectNodes("Car[Weight='9000']");
            foreach (XmlNode n in childnodes)
                Console.WriteLine(n.OuterXml);

            //  LINQ to XML

            XDocument xdoc = new XDocument(new XElement("humans",
                new XElement("human",
                     new XAttribute("name", "Vlad"),
                     new XElement("surname", "Demyanov"),
                     new XElement("age", 18)),
                new XElement("human",
                     new XAttribute("name", "Alex"),
                     new XElement("surname", "Smirnov"),
                     new XElement("age", 13)),
                new XElement("human",
                     new XAttribute("name", "Alex"),
                     new XElement("surname", "Mario"),
                     new XElement("age", 19)),
                new XElement("human",
                     new XAttribute("name", "Zac"),
                     new XElement("surname", "Anderson"),
                     new XElement("age", 21))
                ));
            xdoc.Save(@"./../../resources/XMLHumans.xml");

            var humans = xdoc.Element("humans")
                .Elements("human")
                .Where(h => Convert.ToInt32(h.Element("age").Value) >= 18)
                .Select(h => new Human
                {
                    Age = Convert.ToInt32(h.Element("age").Value),
                    Name = h.Attribute("name").Value,
                    Surname = h.Element("surname").Value
                });
            foreach (var human in humans)
            {
                Console.WriteLine($"\nName & Surname: {human.Name} {human.Surname}");
                Console.WriteLine($"Age: {human.Age}");
            }

            //XDocument xdoc = new XDocument();
            ////  Создание первого элемента
            //XElement human1 = new XElement("human");
            ////  Создание атрибутов
            //XAttribute human1NameAttr = new XAttribute("name", "Vlad");
            //XElement human1SurnameAttr = new XElement("surname", "Demyanov");
            //XElement human1AgeAttr = new XElement("age", 18);
            //human1.Add(human1NameAttr);
            //human1.Add(human1SurnameAttr);
            //human1.Add(human1AgeAttr);

            ////  Создание второго элемента
            //XElement human2 = new XElement("human");
            ////  Создание атрибутов
            //XAttribute human2NameAttr = new XAttribute("name", "Alex");
            //XElement human2SurnameAttr = new XElement("surname", "Smirnov");
            //XElement human2AgeAttr = new XElement("age", 13);
            //human2.Add(human2NameAttr);
            //human2.Add(human2SurnameAttr);
            //human2.Add(human2AgeAttr);

            ////  Создание корневого элемента
            //XElement humans = new XElement("humans");
            //humans.Add(human1);
            //humans.Add(human2);
            //xdoc.Add(humans);
            //xdoc.Save(@"./../../resources/XMLHumans.xml");
        }
    }
}
