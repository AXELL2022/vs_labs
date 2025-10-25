using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Lab20_Task2
{
    // Клас для представлення студента
    class Student
    {
        public string Surname { get; set; }
        public double Rating { get; set; }

        public Student(string surname, double rating)
        {
            Surname = surname;
            Rating = rating;
        }

        public override string ToString()
        {
            return $"{Surname} {Rating}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            string filePath = "student.txt";
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════════════════╗");
                Console.WriteLine("║   Лабораторна робота №20 - Завдання 2 (student.txt)   ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════╝");
                Console.WriteLine("\n1. Додати студента у файл");
                Console.WriteLine("2. Вивести список студентів");
                Console.WriteLine("3. Знайти студента за прізвищем");
                Console.WriteLine("4. Очистити файл");
                Console.WriteLine("0. Вихід");
                Console.WriteLine("\nОберіть дію: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent(filePath);
                        break;
                    case "2":
                        DisplayStudents(filePath);
                        break;
                    case "3":
                        SearchStudent(filePath);
                        break;
                    case "4":
                        ClearFile(filePath);
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("\nНевірний вибір! Спробуйте ще раз.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // Додавання студента у файл
        static void AddStudent(string filePath)
        {
            try
            {
                Console.WriteLine("\n--- Додавання студента ---");

                Console.Write("Введіть прізвище студента: ");
                string surname = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(surname))
                {
                    Console.WriteLine("✗ Прізвище не може бути порожнім!");
                    Console.WriteLine("\nНатисніть будь-яку клавішу...");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Введіть рейтинг студента: ");
                if (!double.TryParse(Console.ReadLine(), out double rating))
                {
                    Console.WriteLine("✗ Невірний формат рейтингу!");
                    Console.WriteLine("\nНатисніть будь-яку клавішу...");
                    Console.ReadKey();
                    return;
                }

                if (rating < 0 || rating > 100)
                {
                    Console.WriteLine("✗ Рейтинг повинен бути в діапазоні 0-100!");
                    Console.WriteLine("\nНатисніть будь-яку клавішу...");
                    Console.ReadKey();
                    return;
                }

                Student student = new Student(surname, rating);

                using (StreamWriter sw = new StreamWriter(filePath, true, Encoding.UTF8))
                {
                    sw.WriteLine(student.ToString());
                }

                Console.WriteLine($"\n✓ Студент {surname} (рейтинг: {rating}) доданий у файл!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n✗ Помилка: {ex.Message}");
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу...");
            Console.ReadKey();
        }

        // Виведення списку студентів
        static void DisplayStudents(string filePath)
        {
            try
            {
                Console.WriteLine("\n╔════════════════════════════════════════════════════════╗");
                Console.WriteLine("║           СПИСОК СТУДЕНТІВ ГРУПИ №1                    ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════╝\n");

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("✗ Файл не існує! Спочатку додайте студентів.");
                    Console.WriteLine("\nНатисніть будь-яку клавішу...");
                    Console.ReadKey();
                    return;
                }

                List<Student> students = ReadStudentsFromFile(filePath);

                if (students.Count == 0)
                {
                    Console.WriteLine("✗ Список студентів порожній!");
                    Console.WriteLine("\nНатисніть будь-яку клавішу...");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("┌────┬─────────────────────────┬─────────────┐");
                Console.WriteLine("│ №  │      Прізвище           │   Рейтинг   │");
                Console.WriteLine("├────┼─────────────────────────┼─────────────┤");

                for (int i = 0; i < students.Count; i++)
                {
                    Console.WriteLine($"│ {i + 1,2} │ {students[i].Surname,-23} │ {students[i].Rating,11:F2} │");
                }

                Console.WriteLine("└────┴─────────────────────────┴─────────────┘");
                Console.WriteLine($"\nВсього студентів: {students.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n✗ Помилка: {ex.Message}");
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу...");
            Console.ReadKey();
        }

        // Пошук студента за прізвищем
        static void SearchStudent(string filePath)
        {
            try
            {
                Console.WriteLine("\n--- Пошук студента ---");

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("✗ Файл не існує!");
                    Console.WriteLine("\nНатисніть будь-яку клавішу...");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Введіть прізвище для пошуку: ");
                string searchSurname = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(searchSurname))
                {
                    Console.WriteLine("✗ Прізвище не може бути порожнім!");
                    Console.WriteLine("\nНатисніть будь-яку клавішу...");
                    Console.ReadKey();
                    return;
                }

                List<Student> students = ReadStudentsFromFile(filePath);

                if (students.Count == 0)
                {
                    Console.WriteLine("✗ Список студентів порожній!");
                    Console.WriteLine("\nНатисніть будь-яку клавішу...");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("\nРезультати пошуку:");
                bool found = false;

                for (int i = 0; i < students.Count; i++)
                {
                    if (students[i].Surname.Equals(searchSurname, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"\n✓ Студент знайдений!");
                        Console.WriteLine($"  Порядковий номер: {i + 1}");
                        Console.WriteLine($"  Прізвище: {students[i].Surname}");
                        Console.WriteLine($"  Рейтинг: {students[i].Rating:F2}");
                        found = true;
                    }
                }

                if (!found)
                {
                    Console.WriteLine($"\n✗ Студента з прізвищем '{searchSurname}' не знайдено у файлі.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n✗ Помилка: {ex.Message}");
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу...");
            Console.ReadKey();
        }

        // Читання студентів з файлу
        static List<Student> ReadStudentsFromFile(string filePath)
        {
            List<Student> students = new List<Student>();

            try
            {
                using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            string[] parts = line.Split(' ');
                            if (parts.Length >= 2)
                            {
                                string surname = parts[0].Trim();
                                if (double.TryParse(parts[1].Trim(), out double rating))
                                {
                                    students.Add(new Student(surname, rating));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка читання файлу: {ex.Message}");
            }

            return students;
        }

        // Очищення файлу
        static void ClearFile(string filePath)
        {
            try
            {
                File.WriteAllText(filePath, string.Empty);
                Console.WriteLine("\n✓ Файл успішно очищено!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n✗ Помилка: {ex.Message}");
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу...");
            Console.ReadKey();
        }
    }
}