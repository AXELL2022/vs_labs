using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Lab20_Task2_Part2
{
    class Student
    {
        public string LastName { get; set; }
        public double Rating { get; set; }
        
        public Student(string lastName, double rating)
        {
            LastName = lastName;
            Rating = rating;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "student.txt";
            
            Console.WriteLine("=== Програма пошуку студентів ===\n");
            
            while (true)
            {
                Console.WriteLine("┌─────────────────────────────────────┐");
                Console.WriteLine("│              Меню:                  │");
                Console.WriteLine("├─────────────────────────────────────┤");
                Console.WriteLine("│ 1. Додати студентів                 │");
                Console.WriteLine("│ 2. Показати всіх студентів          │");
                Console.WriteLine("│ 3. Знайти студента за прізвищем     │");
                Console.WriteLine("│ 0. Вихід                            │");
                Console.WriteLine("└─────────────────────────────────────┘");
                Console.Write("\nВиберіть опцію: ");
                
                string choice = Console.ReadLine();
                Console.WriteLine();
                
                switch (choice)
                {
                    case "1":
                        AddStudents(fileName);
                        break;
                    case "2":
                        DisplayStudents(fileName);
                        break;
                    case "3":
                        SearchStudent(fileName);
                        break;
                    case "0":
                        Console.WriteLine("До побачення!");
                        return;
                    default:
                        Console.WriteLine("✗ Невірний вибір!\n");
                        break;
                }
                
                Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        
        // Метод для додавання студентів
        static void AddStudents(string fileName)
        {
            try
            {
                Console.WriteLine("Додавання студентів");
                Console.WriteLine("═══════════════════");
                Console.WriteLine("(Введіть 'q' для завершення)\n");
                
                using (StreamWriter sw = new StreamWriter(fileName, true, Encoding.Default))
                {
                    while (true)
                    {
                        Console.Write("Прізвище: ");
                        string lastName = Console.ReadLine();
                        
                        if (lastName.ToLower() == "q") break;
                        
                        if (string.IsNullOrWhiteSpace(lastName))
                        {
                            Console.WriteLine("✗ Прізвище не може бути порожнім!\n");
                            continue;
                        }
                        
                        Console.Write("Рейтинг (0-100): ");
                        if (double.TryParse(Console.ReadLine(), out double rating))
                        {
                            if (rating >= 0 && rating <= 100)
                            {
                                sw.WriteLine($"{lastName} {rating}");
                                Console.WriteLine($"✓ Додано!\n");
                            }
                            else
                            {
                                Console.WriteLine("✗ Рейтинг 0-100!\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("✗ Невірний формат!\n");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Помилка: {e.Message}");
            }
        }
        
        // Метод для виведення всіх студентів
        static void DisplayStudents(string fileName)
        {
            try
            {
                List<Student> students = ReadStudents(fileName);
                
                if (students.Count == 0) return;
                
                Console.WriteLine("\n╔═══════════════════════════════════════════════╗");
                Console.WriteLine("║         Список студентів групи №1             ║");
                Console.WriteLine("╚═══════════════════════════════════════════════╝\n");
                
                Console.WriteLine("{0,-8} {1,-25} {2,10}", "№", "Прізвище", "Рейтинг");
                Console.WriteLine(new string('─', 45));
                
                for (int i = 0; i < students.Count; i++)
                {
                    Console.WriteLine("{0,-8} {1,-25} {2,10:F2}", 
                        i + 1, 
                        students[i].LastName, 
                        students[i].Rating);
                }
                
                Console.WriteLine(new string('─', 45));
                Console.WriteLine($"Всього: {students.Count} студентів");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Помилка: {e.Message}");
            }
        }
        
        // Метод для пошуку студента за прізвищем
        static void SearchStudent(string fileName)
        {
            try
            {
                List<Student> students = ReadStudents(fileName);
                
                if (students.Count == 0) return;
                
                Console.Write("Введіть прізвище для пошуку: ");
                string searchName = Console.ReadLine();
                
                if (string.IsNullOrWhiteSpace(searchName))
                {
                    Console.WriteLine("✗ Прізвище не може бути порожнім!");
                    return;
                }
                
                Console.WriteLine("\n╔═══════════════════════════════════════════════╗");
                Console.WriteLine("║            Результати пошуку                  ║");
                Console.WriteLine("╚═══════════════════════════════════════════════╝\n");
                
                bool found = false;
                
                for (int i = 0; i < students.Count; i++)
                {
                    // Порівнюємо прізвища без урахування регістру
                    if (students[i].LastName.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("✓ Студента знайдено!");
                        Console.WriteLine($"┌─────────────────────────────────────┐");
                        Console.WriteLine($"│ Порядковий номер у файлі: {i + 1,-9} │");
                        Console.WriteLine($"│ Прізвище: {students[i].LastName,-23} │");
                        Console.WriteLine($"│ Рейтинг: {students[i].Rating,-24:F2} │");
                        Console.WriteLine($"└─────────────────────────────────────┘");
                        found = true;
                        
                        // Якщо потрібно знайти всі входження
                        // можна видалити break
                        // break;
                    }
                }
                
                if (!found)
                {
                    Console.WriteLine($"✗ Студента з прізвищем '{searchName}' не знайдено у файлі.");
                    Console.WriteLine("\nПеревірте правильність написання прізвища.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Помилка: {e.Message}");
            }
        }
        
        // Допоміжний метод для читання студентів з файлу
        static List<Student> ReadStudents(string fileName)
        {
            List<Student> students = new List<Student>();
            
            if (!File.Exists(fileName))
            {
                Console.WriteLine("✗ Файл student.txt не знайдено!");
                Console.WriteLine("Спочатку додайте студентів у файл.");
                return students;
            }
            
            try
            {
                using (StreamReader sr = new StreamReader(fileName, Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(' ');
                        
                        if (parts.Length >= 2)
                        {
                            string lastName = parts[0];
                            
                            if (double.TryParse(parts[1], out double rating))
                            {
                                students.Add(new Student(lastName, rating));
                            }
                        }
                    }
                }
                
                if (students.Count == 0)
                {
                    Console.WriteLine("✗ Файл порожній або не містить коректних даних.");
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("✗ Файл не знайдено!");
            }
            catch (IOException e)
            {
                Console.WriteLine($"✗ Помилка читання: {e.Message}");
            }
            
            return students;
        }
    }
} 