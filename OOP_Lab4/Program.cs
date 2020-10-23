using System;


namespace OOP_Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car(1000, 270);
            Transformer transformer = new Transformer(3000, 120, 100);
            Human human = new Human(180);

            car.Engine = new CarControl(300);
            transformer.Engine = new TransformerControl(600);

            car.Engine.Start();
            car.Engine.Stop();

            transformer.Engine.Start();
            transformer.Engine.Stop();
            transformer.Say();

            human.Say();

            // Апкаст и полиморфизм
            Vehicle carTest = new Car(300, 300);
            Console.WriteLine($"Без virtual и override: {carTest.calculateRate()}");    // Без полиморфизма подтипов
            Console.WriteLine($"С virtual и override: {carTest.calculateRate2()}");     // С полиморфизмом подтипов

            Console.WriteLine(transformer.DoClone());

            // Способы преобразований
            Car test = new Car(1, 2);
            Vehicle vehicle = test as Vehicle;
            if (vehicle == null)
            {
                Console.WriteLine("Преобразование прошло неудачно");
            }
            else
            {
                Console.WriteLine(vehicle.DoClone());
            }

            Car t = new Car(2, 3);
            if (t is Vehicle)
            {
                Vehicle tt = (Vehicle)t;
                Console.WriteLine(tt.DoClone());
            }
            else
            {
                Console.WriteLine("Преобразование не допустимо");
            }

            // Переопределнный ToString()
            Console.WriteLine(car.ToString());
            Console.WriteLine(transformer.ToString());
            Console.WriteLine(human.ToString());

            // 7. класс  Printer c полиморфным методом 
            // IAmPrinting(SomeAbstractClassorInterface  someobj)
            Console.WriteLine("\n\tКласс  Printer c полиморфным методом:");
            Vehicle[] objects = new Vehicle[]
            {
                car,
                transformer,
            };
            Printer outputObjects = new Printer();
            foreach (var item in objects)
            {
                outputObjects.IAmPrinting(item);
            }
           
        }
    }
}
