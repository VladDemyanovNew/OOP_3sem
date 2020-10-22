using System;
using System.Runtime.CompilerServices;

namespace OOP_Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Person pers1 = new Person();                                        //partial class
            pers1.Move();
            pers1.Say();
            Console.WriteLine($"\tЗакрытый конструктор: {PI.pi}");
            Student[] students = Student.createStudents(5);                     //массив объектов
            Student.autoFill(ref students);
            Student.displayStudentsByFaculty(students, "faculty0");             //список студентов заданного факультета
            Student.displayStudentsByGroup(students, 3);                        //список учебной группы
            Student stud1 = new Student("Surname1", "Name1");
            Console.WriteLine($"\n\tВозраст {stud1.Name}: {stud1.getAge()}");   //вывод расчёта возраста студента
            Student.DisplayId();                                                //вывод количества созданных объектов Student
            Console.WriteLine($"\n\t#{stud1.ID}");
            Console.WriteLine($"\t{stud1.ToString()}");                         //override ToString
            Student ex1 = new Student();
            Student ex2 = new Student();
            Console.WriteLine($"\t#{ex1.GetHashCode()}");
            Console.WriteLine($"\t#{ex2.GetHashCode()}");
            Console.WriteLine($"\tСравнение: {ex1.Equals(ex2)}");

            var test = new { TestName = "test1", testId = 1 };                  //анонимный тип
            
        }
        
    }
    class PI //класс с закрытым конструктором
    {
        //не допускает создание объектов
        private PI() { }
        public static double pi = Math.PI;
    }
    
}
