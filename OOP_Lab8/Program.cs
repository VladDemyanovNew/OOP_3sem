using System;

namespace OOP_Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CollectionType<int> iCollection = new CollectionType<int>();
                iCollection.AddItems(new int[] { 1, 2, 3, 4 });
                Printer<int>.printBasic(iCollection.GetItems());
                CollectionType<int>.fillCollectionFromJSON(@"F:\HDD\OOP_3sem\OOP_3sem\OOP_Lab8\resources\iItems.json", iCollection);
                Printer<int>.printBasic(iCollection.GetItems());

                CollectionType<double> dCollection = new CollectionType<double>();
                dCollection.AddItems(new double[] { 1.1, 2.2, 3.3, 4.4 });
                Printer<double>.printBasic(dCollection.GetItems());

                CollectionType<Car> CarCollection = new CollectionType<Car>();
                Car[] cars = new Car[]
                {
                new Car("Mercedes"),
                new Car("BMW"),
                new Car("Volvo")
                };
                CarCollection.AddItems(cars);
                Printer<Car>.printCars(CarCollection.GetItems());
                CollectionType<Car>.fillCollectionFromJSON(@"F:\HDD\OOP_3sem\OOP_3sem\OOP_Lab8\resources\cars.json", CarCollection);
                Printer<Car>.printCars(CarCollection.GetItems());
                CollectionType<Car>.writeInJSON(@"F:\HDD\OOP_3sem\OOP_3sem\OOP_Lab8\resources\cars.json", CarCollection);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: { ex.Message}.");
            }
            finally
            {
                Console.WriteLine("Блок finally");
            }
        }
    }
}
