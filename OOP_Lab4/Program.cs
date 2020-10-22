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
        }
    }
}
