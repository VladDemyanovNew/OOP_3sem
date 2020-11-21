using System;
using System.Diagnostics;

namespace OOP_Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
                Car car = new Car(1000, 270, Car.Color.Red);
                Transformer transformer = new Transformer(3000, 120, 100, 100, "transformer1", 2002);
                Transformer transformer1 = new Transformer(3000, 120, 100, 100, "transformer2", 2004);
                Transformer transformer2 = new Transformer(3000, 120, 100, 1000, "transformer3", 2008);
                Human human = new Human(180, 2002, "human1");
                Human human1 = new Human(180, 2008, "human2");

                car.Engine = new CarControl(300);
                transformer.Engine = new TransformerControl(600);

                car.Engine.Start();
                car.Engine.Stop();

                transformer.Engine.Start();
                transformer.Engine.Stop();
                transformer.Say();

                human.Say();

                // Апкаст и полиморфизм
                Vehicle carTest = new Car(300, 300, Car.Color.Red);
                Console.WriteLine($"Без virtual и override: {carTest.calculateRate()}");    // Без полиморфизма подтипов
                Console.WriteLine($"С virtual и override: {carTest.calculateRate2()}");     // С полиморфизмом подтипов

                Console.WriteLine(transformer.DoClone());

                // Способы преобразований
                Car test = new Car(1, 2, Car.Color.Red);
                Vehicle vehicle = test as Vehicle;
                if (vehicle == null)
                {
                    Console.WriteLine("Преобразование прошло неудачно");
                }
                else
                {
                    Console.WriteLine(vehicle.DoClone());
                }

                Car t = new Car(2, 3, Car.Color.Red);
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

                // Лабораторная работа №6
                Console.WriteLine($"\n\n-------Лабораторная работа №6-------");
                Army army = new Army();
                army.Add(human, transformer, transformer1, transformer2, human1);
                army.PrintList();

                Console.WriteLine($"\n\tВывод элементов по году.");
                Army result = ArmyController.findElementByYear(army, 2002);
                result.PrintList();

                Console.WriteLine($"\n\tВывод трансформеров по мощности.");
                result = ArmyController.findTransformersByPower(army, 100);
                result.PrintList();

                Console.WriteLine($"\n\tКолличество боевых единииц в армии: {ArmyController.sizeOfArmy(army)}");

                // Дополнительные задания
                Console.WriteLine($"\n\tСчитывающий данные из текстового файла в коллекцию.");
                army = ArmyController.fillArmyFromTXT(@"F:\HDD\OOP_3sem\OOP_3sem\OOP_Lab4\resources\Army.txt", army);
                army.PrintList();

                Console.WriteLine($"\n\tСчитывающий данные из JSON файла в коллекцию.");
                army = ArmyController.fillArmyFromJSON(@"F:\HDD\OOP_3sem\OOP_3sem\OOP_Lab4\resources\Army.json", army);
                army.PrintList();


                // Лабораторная работа №7 - Исключения
#if true
                Human human10 = new Human(180, -2008, "human2");    // неверные данные
#endif

#if false
                object obj = "str";
                int num = (int)obj;         // InvalidCastException
#endif

#if false
                int[] arr = new int[3];
                arr[5] = 12;                // IndexOutOfRangeException
#endif

#if false
                int x = 1;
                int y = x / 0;              // DivideByZeroException
#endif

#if false
                army.Delete(-1);            // макрос Assert
#endif

#if false
                int[] aa= null;
                Debug.Assert(aa !=null, "Values array cannot be null"); 
                
#endif

                Console.ReadKey();
            }
            catch (HeaderException ex)
            {
                Console.WriteLine($"Произошла ошибка: { ex.Message}; с кодом: {ex.ErrorCode}");
                Logger.FileLogger($"Произошла ошибка: { ex.Message}; с кодом: {ex.ErrorCode}", @"log.txt");
                ex.ExceptionHandler();
                
            }
            catch (Exception ex)
            {
                Logger.ConsoleLogger($"Произошла ошибка: { ex.Message}.");
            }
            finally
            {
                Console.WriteLine("Блок finally");
            }
        }
    }
}
