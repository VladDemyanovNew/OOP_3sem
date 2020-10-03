using System;
using System.Runtime.CompilerServices;

namespace OOP_Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Student st1 = new Student();
            //Student st2 = new Student();
            //Student.DisplayId();
            //Person pers1 = new Person();
            //pers1.Move();
            //pers1.Say();
            //Human human1 = new Human();
            //human1.Name = "Vlad";
            //human1.Age = 18;
            //Console.WriteLine($"\t{human1.ToString()}");
            //Human human2 = new Human();
            //Human human3 = new Human();
            //Console.WriteLine($"\t{human2.Equals(human3)}");

            //Массив объектов
            Student[] students = Student.createStudents(5);
            Student.autoFill(ref students);
            Student.displayStudentsByFaculty(students, "faculty0");
        }
        
    }

    class PI
    {
        //не допускает создание объектов
        private PI() { }
        public static double pi = Math.PI;
    }
    public class Human
    {
        public string Name { get; set; }
        public int Age { get; set; } = 1;
        public override string ToString()
        {
            return "Type: " + base.ToString() + " " + Name + " " + Age;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            Human human = (Human)obj;
            return (this.Name == human.Name && this.Age == human.Age);
        }
        public override int GetHashCode()
        {
            int hash = 269;
            hash = string.IsNullOrEmpty(Name) ? 0 : Name.GetHashCode();
            hash = (hash * 47) + Age.GetHashCode();
            return hash;
        }
    }
    class Student
    {
        private static int counter;
        private string surname;
        private string name;
        public string midName { get; set; }
        public DateTime birthday { get; set; }
        public string address { get; }
        public string phoneNumber { get; set; }
        public string faculty { get; set; }
        public int course { get; set; }
        public int group { get; set; }
        public readonly string forRead = "\tТолько для чтения"; //также можно инициализировать в конструктуре
        public const string gender = "Male";
        public readonly int ID;
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        //Статический конструктор
        //static Student()
        //{
        //    counter = 0;
        //    Console.WriteLine("\tStatic constructor");
        //}
        public Student(string address)
        {
            this.address = address;
            counter++;
        }
        public Student(string address = "Minsk", string phoneNumber = "11111")
        {
            this.address = address;
            this.phoneNumber = phoneNumber;
            counter++;
        }

        public int getAge()
        {
            if (this.birthday == new DateTime())
            {
                Console.Write("\tВведите дату рождения: ");
                this.birthday = DateTime.ParseExact(Console.ReadLine(),
                    "yyyy/MM/dd",
                    System.Globalization.CultureInfo.InvariantCulture);
            }
            return DateTime.Now.Year - this.birthday.Year;
        }
        public static Student[] createStudents(int size)
        {
            Student[] students = new Student[size];
            for (int i = 0; i < students.Length; i++)
            {
                students[i] = new Student();
            }
            return students;
        }
        public static void autoFill(ref Student[] students)
        {
            for (int i = 0; i < students.Length; i++)
            {
                if (i <= students.Length / 2)
                    students[i].faculty = "faculty" + 0;
                else
                    students[i].faculty = "faculty" + i;
                students[i].Name = "studentName" + i;
                students[i].Surname = "studentSurname" + i;
            }
        }
        public static void displayStudentsByFaculty(Student[] students, string faculty)
        {
            foreach (Student student in students)
            {
                if (student.faculty == faculty)
                    Console.WriteLine($"\t{student.Surname} {student.Name} {student.faculty}");
            }
        }
        public static void DisplayId()
        {
            Console.WriteLine($"\tСоздано {counter} объектов.");
        }
    }
}
