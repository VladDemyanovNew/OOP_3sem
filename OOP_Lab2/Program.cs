using System;

namespace OOP_Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Student st1 = new Student();
            Student st2 = new Student();
            Student.DisplayId();
            Person pers1 = new Person();
            pers1.Move();
            pers1.Say();
        }
    }

    class PI
    {
        //не допускает создание объектов
        private PI() { }
        public static double pi = Math.PI;
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
        public string Name => name;

        //Статический конструктор
        static Student()
        {
            counter = 0;
            Console.WriteLine("\tStatic constructor");
        }
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

        public static void DisplayId()
        {
            Console.WriteLine($"\tСоздано {counter} объектов.");
        }
    }
}
