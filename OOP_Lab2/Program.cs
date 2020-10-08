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
        }
        
    }
    class PI //класс с закрытым конструктором
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
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public string faculty { get; set; }
        public int course { get; set; }
        public int group { get; set; }
        public const int SIZE = 99;
        public readonly int ID;                    //также можно инициализировать в конструктуре
        public static int Counter { get; }
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
        static Student()    //Статический конструктор
        {
            counter = 0;
            Console.WriteLine("\tStatic constructor");
        }
        public Student()
        {
            this.ID = this.GetHashCode();
            counter++;
        }
        public Student(string surname, string name, int group = 3)
        {
            this.Surname = surname;
            this.Name = name;
            this.group = group;
            this.ID = this.GetHashCode();
            counter++;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            Student student = (Student)obj;
            return this.GetHashCode() == student.GetHashCode();
        }
        public override int GetHashCode()
        {
            int hash = 269;
            System.Reflection.PropertyInfo[] properties = this.GetType().GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i].PropertyType == "asd".GetType())
                {
                    hash += string.IsNullOrEmpty(Convert.ToString(properties[i].GetValue(this, null))) ? 0 : properties[i].GetHashCode();
                }
                hash = hash * 47 + properties[i].GetHashCode();
            }
            return hash;
        }
        public override string ToString()
        {
            System.Reflection.PropertyInfo[] properties = this.GetType().GetProperties();
            string result = "Type: " + base.ToString();
            foreach (var value in properties)
            {
                result += " " + value.GetValue(this, null);
            }
           
            return result;
        }
        public int getAge()
        {
            if (this.birthday == new DateTime())
            {
                Console.Write("\tВведите дату рождения yyyy/MM/dd: ");
                string dateString = Console.ReadLine();
                DateTime userDate;
                var userCulture = System.Globalization.CultureInfo.InvariantCulture;
                if (DateTime.TryParse(dateString, userCulture.DateTimeFormat, System.Globalization.DateTimeStyles.None, out userDate))
                {
                    Console.WriteLine("\tValid date entered (long date format):" + userDate.ToLongDateString());
                    this.birthday = userDate;
                }    
                else
                    Console.WriteLine("\tВы ввели дату не в том формате!");
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
                {
                    students[i].faculty = "faculty" + 0;
                    students[i].group = 3;
                }   
                else
                {
                    students[i].faculty = "faculty" + i;
                    students[i].group = i;
                }     
                students[i].Name = "studentName" + i;
                students[i].Surname = "studentSurname" + i;       
            }
        }
        public static void displayStudentsByFaculty(Student[] students, string faculty)
        {
            Console.WriteLine($"\n\tВывод студенов факультета {faculty}");
            foreach (var student in students)
            {
                if (student.faculty == faculty)
                    Console.WriteLine($"\t{student.Surname} {student.Name} {student.faculty}");
            }
        }
        public static void displayStudentsByGroup(Student[] students, int group)
        {
            Console.WriteLine($"\n\tВывод студенов {group}-й группы");
            foreach (var student in students)
            {
                if (student.group == group)
                    Console.WriteLine($"\t{student.Surname} {student.Name} {student.group}");
            }
        }
        public static void DisplayId()
        {
            Console.WriteLine($"\n\tСоздано {counter} объектов.");
        }
    }
}
