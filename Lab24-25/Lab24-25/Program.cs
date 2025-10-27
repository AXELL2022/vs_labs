using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;
using EducationalInstitutionLibrary;

namespace EducationalInstitutionApp
{
    class Program
    {
        // Список навчальних закладів
        static List<EducationalInstitution> institutions = new List<EducationalInstitution>();
        static string dataFile = "institutions.json";

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            // Завантажуємо дані з файлу при старті
            LoadFromFile();

            bool exit = false;

            while (!exit)
            {
                ShowMenu();
                Console.Write("\nВиберіть дію (1-5): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddInstitution();
                        break;
                    case "2":
                        DisplayInstitutions();
                        break;
                    case "3":
                        RemoveInstitution();
                        break;
                    case "4":
                        SearchInstitution();
                        break;
                    case "5":
                        exit = true;
                        SaveToFile();
                        Console.WriteLine("\nДо побачення!");
                        break;
                    default:
                        Console.WriteLine("\nНевірний вибір! Спробуйте ще раз.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
                    Console.ReadKey();
                }
            }
        }
        static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║          СИСТЕМА УПРАВЛІННЯ НАВЧАЛЬНИМИ ЗАКЛАДАМИ              ║");
            Console.WriteLine("╠════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║  1. Додати новий навчальний заклад                             ║");
            Console.WriteLine("║  2. Вивести список навчальних закладів                         ║");
            Console.WriteLine("║  3. Вилучити навчальний заклад                                 ║");
            Console.WriteLine("║  4. Пошук навчального закладу                                  ║");
            Console.WriteLine("║  5. Вихід із програми                                          ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════╝");
        }
        static void AddInstitution()
        {
            Console.Clear();
            Console.WriteLine("=== ДОДАВАННЯ НОВОГО НАВЧАЛЬНОГО ЗАКЛАДУ ===\n");

            Console.Write("Введіть назву: ");
            string name = Console.ReadLine();

            Console.Write("Введіть адресу: ");
            string address = Console.ReadLine();

            int foundationYear;
            while (true)
            {
                Console.Write("Введіть рік створення: ");
                if (int.TryParse(Console.ReadLine(), out foundationYear) && 
                    foundationYear >= 1800 && foundationYear <= DateTime.Today.Year)
                    break;
                Console.WriteLine("Невірний рік! Введіть значення від 1800 до поточного року.");
            }

            int studentCount;
            while (true)
            {
                Console.Write("Введіть кількість студентів: ");
                if (int.TryParse(Console.ReadLine(), out studentCount) && studentCount >= 0)
                    break;
                Console.WriteLine("Невірне значення! Введіть невід'ємне число.");
            }

            int specialtyCount;
            while (true)
            {
                Console.Write("Введіть кількість спеціальностей: ");
                if (int.TryParse(Console.ReadLine(), out specialtyCount) && specialtyCount >= 0)
                    break;
                Console.WriteLine("Невірне значення! Введіть невід'ємне число.");
            }

            EducationalInstitution institution = new EducationalInstitution(
                name, address, foundationYear, studentCount, specialtyCount);
            
            institutions.Add(institution);
            SaveToFile();

            Console.WriteLine("\n✓ Навчальний заклад успішно додано!");
        }
        static void DisplayInstitutions()
        {
            Console.Clear();
            Console.WriteLine("=== СПИСОК НАВЧАЛЬНИХ ЗАКЛАДІВ ===\n");

            if (institutions.Count == 0)
            {
                Console.WriteLine("Список порожній!");
                return;
            }

            Console.WriteLine($"{"Назва",-40} | {"Адреса",-30} | {"Рік",4} | {"Студ.",7} | {"Спец.",5}");
            Console.WriteLine(new string('=', 100));

            foreach (EducationalInstitution inst in institutions)
            {
                Console.WriteLine(inst.ToString());
            }

            Console.WriteLine(new string('=', 100));
            Console.WriteLine($"\nЗагальна кількість навчальних закладів: {institutions.Count}");
            
            // Обчислення суми студентів
            int totalStudents = institutions.Sum(i => i.StudentCount);
            Console.WriteLine($"Загальна кількість студентів: {totalStudents}");
            
            // Обчислення суми спеціальностей
            int totalSpecialties = institutions.Sum(i => i.SpecialtyCount);
            Console.WriteLine($"Загальна кількість спеціальностей: {totalSpecialties}");
        }
        static void RemoveInstitution()
        {
            Console.Clear();
            Console.WriteLine("=== ВИДАЛЕННЯ НАВЧАЛЬНОГО ЗАКЛАДУ ===\n");

            if (institutions.Count == 0)
            {
                Console.WriteLine("Список порожній!");
                return;
            }

            Console.WriteLine("Виберіть критерій для видалення:");
            Console.WriteLine("1. За назвою та адресою");
            Console.WriteLine("2. За роком створення");
            Console.WriteLine("3. Всі з кількістю студентів менше заданої");
            Console.Write("\nВаш вибір: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введіть назву: ");
                    string name = Console.ReadLine();
                    Console.Write("Введіть адресу: ");
                    string address = Console.ReadLine();
                    
                    EducationalInstitution toRemove = new EducationalInstitution(name, address, 2000, 0, 0);
                    bool removed = institutions.Remove(toRemove);
                    
                    if (removed)
                    {
                        Console.WriteLine("\n✓ Навчальний заклад видалено!");
                        SaveToFile();
                    }
                    else
                        Console.WriteLine("\n✗ Навчальний заклад не знайдено!");
                    break;

                case "2":
                    Console.Write("Введіть рік створення: ");
                    if (int.TryParse(Console.ReadLine(), out int year))
                    {
                        int count = institutions.RemoveAll(i => i.FoundationYear == year);
                        Console.WriteLine($"\n✓ Видалено закладів: {count}");
                        SaveToFile();
                    }
                    break;

                case "3":
                    Console.Write("Введіть мінімальну кількість студентів: ");
                    if (int.TryParse(Console.ReadLine(), out int minStudents))
                    {
                        int count = institutions.RemoveAll(i => i.StudentCount < minStudents);
                        Console.WriteLine($"\n✓ Видалено закладів: {count}");
                        SaveToFile();
                    }
                    break;

                default:
                    Console.WriteLine("Невірний вибір!");
                    break;
            }
        }
        static void SearchInstitution()
        {
            Console.Clear();
            Console.WriteLine("=== ПОШУК НАВЧАЛЬНОГО ЗАКЛАДУ ===\n");

            if (institutions.Count == 0)
            {
                Console.WriteLine("Список порожній!");
                return;
            }

            Console.WriteLine("Виберіть критерій пошуку:");
            Console.WriteLine("1. За назвою (часткове співпадіння)");
            Console.WriteLine("2. За роком створення");
            Console.WriteLine("3. За кількістю студентів (більше або дорівнює)");
            Console.WriteLine("4. За кількістю спеціальностей (більше або дорівнює)");
            Console.Write("\nВаш вибір: ");
            string choice = Console.ReadLine();

            List<EducationalInstitution> found = new List<EducationalInstitution>();

            switch (choice)
            {
                case "1":
                    Console.Write("Введіть назву (або частину): ");
                    string searchName = Console.ReadLine().ToLower();
                    found = institutions.Where(i => i.Name.ToLower().Contains(searchName)).ToList();
                    break;

                case "2":
                    Console.Write("Введіть рік створення: ");
                    if (int.TryParse(Console.ReadLine(), out int year))
                    {
                        found = institutions.Where(i => i.FoundationYear == year).ToList();
                    }
                    break;

                case "3":
                    Console.Write("Введіть мінімальну кількість студентів: ");
                    if (int.TryParse(Console.ReadLine(), out int minStudents))
                    {
                        found = institutions.Where(i => i.StudentCount >= minStudents).ToList();
                    }
                    break;

                case "4":
                    Console.Write("Введіть мінімальну кількість спеціальностей: ");
                    if (int.TryParse(Console.ReadLine(), out int minSpecialties))
                    {
                        found = institutions.Where(i => i.SpecialtyCount >= minSpecialties).ToList();
                    }
                    break;

                default:
                    Console.WriteLine("Невірний вибір!");
                    return;
            }

            Console.WriteLine($"\n=== РЕЗУЛЬТАТИ ПОШУКУ ({found.Count} знайдено) ===\n");

            if (found.Count > 0)
            {
                Console.WriteLine($"{"Назва",-40} | {"Адреса",-30} | {"Рік",4} | {"Студ.",7} | {"Спец.",5}");
                Console.WriteLine(new string('=', 100));
                foreach (var inst in found)
                {
                    Console.WriteLine(inst.ToString());
                }
            }
            else
            {
                Console.WriteLine("Нічого не знайдено!");
            }
        }
        static void SaveToFile()
        {
            try
            {
                var data = institutions.Select(i => new
                {
                    Name = i.Name,
                    Address = i.Address,
                    FoundationYear = i.FoundationYear,
                    StudentCount = i.StudentCount,
                    SpecialtyCount = i.SpecialtyCount
                }).ToList();

                string json = JsonSerializer.Serialize(data, new JsonSerializerOptions 
                { 
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                });
                
                File.WriteAllText(dataFile, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при збереженні файлу: {ex.Message}");
            }
        }
        static void LoadFromFile()
        {
            try
            {
                if (File.Exists(dataFile))
                {
                    string json = File.ReadAllText(dataFile);
                    var data = JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>>(json);

                    if (data != null)
                    {
                        foreach (var item in data)
                        {
                            var inst = new EducationalInstitution(
                                item["Name"].GetString(),
                                item["Address"].GetString(),
                                item["FoundationYear"].GetInt32(),
                                item["StudentCount"].GetInt32(),
                                item["SpecialtyCount"].GetInt32()
                            );
                            institutions.Add(inst);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при завантаженні файлу: {ex.Message}");
            }
        }
    }
}