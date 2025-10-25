using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using EducationalInstitutionLibrary;  // Підключення бібліотеки класів

namespace EducationalInstitutionApp
{
    class Program
    {
        static string filePath = @"educational_institutions.txt";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            // Встановлення заголовку та розміру тільки для Windows
            try
            {
                Console.Title = "Лабораторна робота №21-22, Варіант 25";
                if (OperatingSystem.IsWindows())
                {
                    Console.SetWindowSize(100, 30);
                }
            }
            catch
            {
                // Ігноруємо помилки налаштування консолі на несумісних платформах
            }

            bool exit = false;
            while (!exit)
            {
                ShowMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateNewObject();
                        break;
                    case "2":
                        DisplayFileContent();
                        break;
                    case "3":
                        DisplayReport();
                        break;
                    case "4":
                        SearchObjects();
                        break;
                    case "5":
                        exit = true;
                        Console.WriteLine("\nДо побачення!");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nНевірний вибір! Спробуйте ще раз.");
                        Console.ResetColor();
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║          СИСТЕМА УПРАВЛІННЯ НАВЧАЛЬНИМИ ЗАКЛАДАМИ                  ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("1. Створити новий об'єкт та записати у файл");
            Console.WriteLine("2. Вивести вміст файлу");
            Console.WriteLine("3. Вивести звіт про всі навчальні заклади");
            Console.WriteLine("4. Пошук навчального закладу");
            Console.WriteLine("5. Вихід");
            Console.WriteLine();
            Console.Write("Оберіть дію (1-5): ");
        }

        static void CreateNewObject()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=== СТВОРЕННЯ НОВОГО НАВЧАЛЬНОГО ЗАКЛАДУ ===\n");
            Console.ResetColor();

            try
            {
                // Створюємо об'єкт класу з бібліотеки
                EducationalInstitution institution = new EducationalInstitution();
                
                // Вводимо дані
                institution.Input();

                // Записуємо у файл
                using (StreamWriter sw = new StreamWriter(filePath, true, Encoding.UTF8))
                {
                    sw.WriteLine(institution.ToString());
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n✓ Навчальний заклад успішно додано до файлу!");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n✗ Помилка при створенні об'єкта: {ex.Message}");
                Console.ResetColor();
            }
        }

        static void DisplayFileContent()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== ВМІСТ ФАЙЛУ ===\n");
            Console.ResetColor();

            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Файл не знайдено. Створіть спочатку об'єкти.");
                    return;
                }

                using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
                {
                    if (sr.EndOfStream)
                    {
                        Console.WriteLine("Файл порожній.");
                        return;
                    }

                    Console.WriteLine("Дані у файлі (формат: Назва|Адреса|Рік|Студенти|Спеціальності):");
                    Console.WriteLine(new string('-', 80));

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Помилка при читанні файлу: {ex.Message}");
                Console.ResetColor();
            }
        }

        static void DisplayReport()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                  ЗВІТ ПРО НАВЧАЛЬНІ ЗАКЛАДИ                        ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();

            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Файл не знайдено. Створіть спочатку об'єкти.");
                    return;
                }

                List<EducationalInstitution> institutions = new List<EducationalInstitution>();

                // Читаємо об'єкти з файлу
                using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        try
                        {
                            EducationalInstitution inst = EducationalInstitution.FromString(line);
                            institutions.Add(inst);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Помилка обробки рядка: {ex.Message}");
                        }
                    }
                }

                if (institutions.Count == 0)
                {
                    Console.WriteLine("У файлі немає даних.");
                    return;
                }

                int totalStudents = 0;

                // Виводимо інформацію про кожен заклад
                for (int i = 0; i < institutions.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\n{i + 1}. {institutions[i].Name}");
                    Console.ResetColor();
                    Console.WriteLine($"   Адреса: {institutions[i].Address}");
                    Console.WriteLine($"   Рік створення: {institutions[i].YearFounded}");
                    Console.WriteLine($"   Кількість студентів: {institutions[i].StudentCount}");
                    Console.WriteLine($"   Кількість спеціальностей: {institutions[i].SpecialtyCount}");

                    totalStudents += institutions[i].StudentCount;
                }

                // Підсумкова інформація
                Console.WriteLine();
                Console.WriteLine(new string('=', 70));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nПІДСУМКОВА ІНФОРМАЦІЯ:");
                Console.WriteLine($"Загальна кількість навчальних закладів: {institutions.Count}");
                Console.WriteLine($"Загальна кількість студентів: {totalStudents}");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Помилка при формуванні звіту: {ex.Message}");
                Console.ResetColor();
            }
        }

        static void SearchObjects()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("=== ПОШУК НАВЧАЛЬНОГО ЗАКЛАДУ ===\n");
            Console.ResetColor();

            Console.WriteLine("Оберіть критерій пошуку:");
            Console.WriteLine("1. За назвою (символьний пошук)");
            Console.WriteLine("2. За роком створення (числовий пошук)");
            Console.Write("\nВаш вибір (1 або 2): ");

            string searchChoice = Console.ReadLine();

            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("\nФайл не знайдено.");
                    return;
                }

                List<EducationalInstitution> institutions = new List<EducationalInstitution>();

                // Читаємо всі об'єкти з файлу
                using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        try
                        {
                            institutions.Add(EducationalInstitution.FromString(line));
                        }
                        catch { }
                    }
                }

                List<EducationalInstitution> results = new List<EducationalInstitution>();

                // Пошук за обраним критерієм
                if (searchChoice == "1")
                {
                    Console.Write("\nВведіть назву для пошуку (або частину назви): ");
                    string searchName = Console.ReadLine().ToLower();

                    foreach (var inst in institutions)
                    {
                        if (inst.Name.ToLower().Contains(searchName))
                        {
                            results.Add(inst);
                        }
                    }
                }
                else if (searchChoice == "2")
                {
                    Console.Write("\nВведіть рік створення для пошуку: ");
                    if (int.TryParse(Console.ReadLine(), out int searchYear))
                    {
                        foreach (var inst in institutions)
                        {
                            if (inst.YearFounded == searchYear)
                            {
                                results.Add(inst);
                            }
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Помилка! Введіть коректне число.");
                        Console.ResetColor();
                        return;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nНевірний вибір!");
                    Console.ResetColor();
                    return;
                }

                // Виведення результатів пошуку
                Console.WriteLine("\n" + new string('-', 70));

                if (results.Count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nЗнайдено результатів: {results.Count}\n");
                    Console.ResetColor();

                    for (int i = 0; i < results.Count; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\n--- Результат {i + 1} ---");
                        Console.ResetColor();
                        results[i].Display();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nНічого не знайдено за вашим запитом.");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nПомилка при пошуку: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}
