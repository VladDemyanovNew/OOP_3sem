using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OOP_Lab11
{
    class Program
    {
        static void Main(string[] args)
        {

            Exercise1();
            Exercise2();
            Exercise3();

        }

        static void Exercise1()
        {
            Console.WriteLine("\nЗадание №1\n");
            string[] year =
            {
              "June", "July", "May", "December",
              "January", "February", "March", "April",
              "August", "September", "October", "November"
            };
            int n = 5;
            var selectedMonthByLength = year.Where(t => t.Length == n);
            OutputExercise1(selectedMonthByLength, "1. Выбрать по длине строки: ");
            var selectedMonthBySeason = year.Where(t => t == "June" || t == "Jule" || t == "August" || t == "December" || t == "January" || t == "February");
            OutputExercise1(selectedMonthBySeason, "2. Выбрать зимние и летние: ");
            var sortedMonth = from t in year orderby t select t;
            OutputExercise1(sortedMonth, "3. Отсортировать в алфавитном парядке: ");
            int countedByU = (year.Where(t => t.Length >= 4 && t.Contains('u'))).Count();
            Console.WriteLine($"4. Подсчитать сколько элементов по условию: {countedByU}");

        }

        static void Exercise2()
        {
            Console.WriteLine("\nЗадание №2\n");
            List<Student> list = new List<Student>
            {
                new Student ("Зыков", "Ярослав", 19, 2, "ФИТ", "ПОИТ"),
                new Student ("Павленко", "Ян", 21, 3, "ЛХ", "Дровосек"),
                new Student ("Сидоров", "Лукиллиан", 18, 3, "ИЭФ", "Экономист"),
                new Student ("Захаров", "Устин", 23, 5, "ЛХ", "СПС"),
                new Student ("Моисеев", "Ярослав", 20, 1, "ФИТ", "ИСиТ"),
                new Student ("Сидоров", "Тимофей", 24, 2, "ФИТ", "ДЭиВИ"),
                new Student ("Шумило", "Юлий", 18, 1, "ИЭФ", "Менеджер"),
                new Student ("Куликов", "Жерар", 22, 4, "ФИТ", "ПОИТ"),
                new Student ("Бирюков", "Тимофей", 21, 3, "ЛХ", "Туризм"),
            };

            string specialty = "ПОИТ";
            int group = 3;
            string faculty = "ЛХ";
            string name = "Тимофей";
            var selectedBySpecialty = list.Where(s => s.Specialty == specialty).OrderBy(s => s.Name);
            OutputExercise2(selectedBySpecialty, "1. Выбрать по заданной специальность в алфавитном порядке: ");
            var selectedByGroupAndFaculty = list.Where(s => s.Group == group && s.Faculty == faculty);
            OutputExercise2(selectedByGroupAndFaculty, "2. Выбрать по заданной группе и факультету: ");
            Student selectedYoungest = list.OrderBy(n => n.Age).ToList()[0];
            Console.WriteLine($"3. Выбрать самого молодого: {selectedYoungest.Name}");
            int countGroup = list.Where(s => s.Group == group).Count();
            Console.WriteLine($"4. Количество студентов заданной группы: {countGroup}");
            Student selectedByName = list.Where(s => s.Name == name).First();
            Console.WriteLine($"5. Выбрать по первого по имени: {selectedByName.Name} {selectedByName.Surname}");

            Console.WriteLine("\nЗадание №3. Реализовать свой собственный запрос:\n");
            var result = (from student in list
                         where student.Age > 19
                         group student by student.Faculty into r
                         select new { Faculty = r.Key, Count = r.Count() }).OrderBy(faculty=> faculty.Faculty);
      
            foreach (var gr in result)
                Console.WriteLine($"{gr.Faculty} : {gr.Count}");
            Console.WriteLine();
        }

        static void Exercise3()
        {
            Console.WriteLine("\nЗадание №4. Придумать запрос с Join:\n");

            List<Student> students = new List<Student>
            {
                new Student ("Зыков", "Ярослав", 19, 2, "ФИТ", "ПОИТ"),
                new Student ("Павленко", "Ян", 21, 3, "ЛХ", "ДО"),
                new Student ("Сидоров", "Лукиллиан", 18, 3, "ИЭФ", "Экономист"),
                new Student ("Захаров", "Устин", 23, 5, "ЛХ", "СПС"),
                new Student ("Моисеев", "Ярослав", 20, 1, "ФИТ", "ИСиТ"),
                new Student ("Сидоров", "Тимофей", 24, 2, "ФИТ", "ДЭиВИ"),
                new Student ("Шумило", "Юлий", 18, 1, "ИЭФ", "Менеджер"),
                new Student ("Куликов", "Жерар", 22, 4, "ФИТ", "ПОИТ"),
                new Student ("Бирюков", "Тимофей", 21, 3, "ЛХ", "Туризм"),
            };

            List<Type> subjects = new List<Type>
            {
                new Type("Да", "ПОИТ"),
                new Type("Нет", "ИСиТ"),
                new Type("Нет", "Экономист"),
                new Type("Да", "ДЭиВИ"),
                new Type("Да", "Менеджер"),
                new Type("Нет", "Туризм"),
                new Type("Да", "ДО"),
                new Type("Да", "СПС")
            };

            var result = from student in students
                         join type in subjects on student.Specialty equals type.Specialty
                         select new { Surname = student.Surname, Specialty = student.Specialty, Quarantine = type.Quarantine };

            foreach (var stud in result)
                Console.WriteLine($"{stud.Surname} {stud.Specialty} Карантин: {stud.Quarantine}");
            Console.WriteLine();
        }

        static void OutputExercise1(IEnumerable arr, string info)
        {
            Console.Write(info);
            foreach (string s in arr)
                Console.Write($"{s} ");
            Console.WriteLine();
        }

        static void OutputExercise2(IEnumerable arr, string info)
        {
            Console.Write(info);
            foreach (Student s in arr)
                Console.Write($"{s.Name} ");
            Console.WriteLine();
        }

    }
}
