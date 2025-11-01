using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab16_17_Variant25
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║   Лабораторна робота №16-17 - Варіант 25                    ║");
            Console.WriteLine("║   Тема: Робота з класом 'Навчальний заклад'                 ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝\n");

            // Створення об'єктів з використанням різних конструкторів
            Console.WriteLine("1. СТВОРЕННЯ ОБ'ЄКТІВ:");
            Console.WriteLine("─────────────────────────────────────────");

            // Об'єкт 1 - використання конструктора за замовчуванням
            Console.WriteLine("\n► Створення першого об'єкта (конструктор без параметрів):");
            EducationalInstitution institution1 = new EducationalInstitution();
            institution1.Name = "Київський політехнічний інститут";
            institution1.Address = "пр. Перемоги, 37, Київ";
            institution1.FoundationYear = 1898;
            institution1.StudentCount = 25000;
            institution1.SpecialtyCount = 120;
            institution1.DisplayInfo();

            // Об'єкт 2 - використання повного конструктора
            Console.WriteLine("\n► Створення другого об'єкта (конструктор з усіма параметрами):");
            EducationalInstitution institution2 = new EducationalInstitution(
                "Національний університет ім. Шевченка",
                "вул. Володимирська, 60, Київ",
                1834,
                32000,
                150
            );
            institution2.DisplayInfo();

            // Об'єкт 3 - використання часткового конструктора
            Console.WriteLine("\n► Створення третього об'єкта (конструктор з частковими параметрами):");
            EducationalInstitution institution3 = new EducationalInstitution(
                "Київська політехніка",
                5000,
                25
            );
            institution3.Address = "вул. Борщагівська, 126, Київ";
            institution3.FoundationYear = 1995;
            institution3.DisplayInfo();

            // Демонстрація перевантажених операторів
            Console.WriteLine("\n2. ДЕМОНСТРАЦІЯ ПЕРЕВАНТАЖЕНИХ ОПЕРАТОРІВ:");
            Console.WriteLine("─────────────────────────────────────────");

            // Оператор ==
            Console.WriteLine($"\n► Порівняння на рівність (==):");
            Console.WriteLine($"  {institution1.Name} == {institution2.Name}: {institution1 == institution2}");
            
            // Створюємо копію для демонстрації рівності
            EducationalInstitution institution1_copy = new EducationalInstitution();
            institution1_copy.Name = institution1.Name;
            institution1_copy.Address = institution1.Address;
            Console.WriteLine($"  {institution1.Name} == копія: {institution1 == institution1_copy}");

            // Оператори < та >
            Console.WriteLine($"\n► Порівняння за кількістю студентів (< та >):");
            Console.WriteLine($"  {institution1.Name} ({institution1.StudentCount} студ.) < " +
                            $"{institution2.Name} ({institution2.StudentCount} студ.): {institution1 < institution2}");
            Console.WriteLine($"  {institution2.Name} ({institution2.StudentCount} студ.) > " +
                            $"{institution3.Name} ({institution3.StudentCount} студ.): {institution2 > institution3}");

            // Оператор +
            Console.WriteLine($"\n► Об'єднання двох закладів (+):");
            EducationalInstitution mergedInstitution = institution1 + institution3;
            Console.WriteLine($"  Результат об'єднання:");
            mergedInstitution.DisplayInfo();

            // Масив об'єктів та пошук (для відмінної оцінки)
            Console.WriteLine("\n3. РОБОТА З МАСИВОМ ОБ'ЄКТІВ (для відмінної оцінки):");
            Console.WriteLine("─────────────────────────────────────────");

            // Створення масиву навчальних закладів
            EducationalInstitution[] institutions = new EducationalInstitution[]
            {
                institution1,
                institution2,
                institution3,
                new EducationalInstitution("Медичний університет", "вул. Зоологічна, 1", 1841, 8000, 35),
                new EducationalInstitution("Економічний університет", "пр. Перемоги, 54", 1906, 15000, 45),
                new EducationalInstitution("Педагогічний університет", "вул. Пирогова, 9", 1912, 12000, 40)
            };

            Console.WriteLine("\n► Всі заклади в масиві:");
            for (int i = 0; i < institutions.Length; i++)
            {
                Console.WriteLine($"  {i + 1}. {institutions[i]}");
            }

            // Пошук за характеристиками
            Console.WriteLine("\n► Пошук закладів за заданими критеріями:");
            
            // Пошук 1: За кількістю студентів
            Console.Write("\nВведіть мінімальну кількість студентів для пошуку: ");
            if (int.TryParse(Console.ReadLine(), out int minStudents))
            {
                var foundByStudents = institutions.Where(i => i.StudentCount >= minStudents).ToList();
                
                if (foundByStudents.Count > 0)
                {
                    Console.WriteLine($"Знайдено {foundByStudents.Count} заклад(ів) з кількістю студентів >= {minStudents}:");
                    foreach (var inst in foundByStudents)
                    {
                        Console.WriteLine($"  - {inst.Name}: {inst.StudentCount} студентів");
                    }
                }
                else
                {
                    Console.WriteLine("Заклади з такою кількістю студентів не знайдені.");
                }
            }

            // Пошук 2: За роком заснування
            Console.Write("\nВведіть максимальний рік заснування для пошуку: ");
            if (int.TryParse(Console.ReadLine(), out int maxYear))
            {
                var foundByYear = institutions.Where(i => i.FoundationYear <= maxYear).ToList();
                
                if (foundByYear.Count > 0)
                {
                    Console.WriteLine($"Знайдено {foundByYear.Count} заклад(ів) заснованих до {maxYear} року:");
                    foreach (var inst in foundByYear)
                    {
                        Console.WriteLine($"  - {inst.Name}: заснований у {inst.FoundationYear} році (вік: {inst.GetAge()} років)");
                    }
                }
                else
                {
                    Console.WriteLine("Заклади з таким роком заснування не знайдені.");
                }
            }

            // Пошук 3: За середньою кількістю студентів на спеціальність
            Console.Write("\nВведіть мінімальну середню кількість студентів на спеціальність: ");
            if (double.TryParse(Console.ReadLine(), out double minAverage))
            {
                var foundByAverage = institutions
                    .Where(i => i.CalculateAverageStudentsPerSpecialty() >= minAverage)
                    .OrderByDescending(i => i.CalculateAverageStudentsPerSpecialty())
                    .ToList();
                
                if (foundByAverage.Count > 0)
                {
                    Console.WriteLine($"Знайдено {foundByAverage.Count} заклад(ів) із середньою >= {minAverage:F2}:");
                    foreach (var inst in foundByAverage)
                    {
                        Console.WriteLine($"  - {inst.Name}: {inst.CalculateAverageStudentsPerSpecialty():F2} студ./спец.");
                    }
                }
                else
                {
                    Console.WriteLine("Заклади з такою середньою кількістю не знайдені.");
                }
            }

            // Статистика
            Console.WriteLine("\n4. ЗАГАЛЬНА СТАТИСТИКА:");
            Console.WriteLine("─────────────────────────────────────────");
            
            int totalStudents = institutions.Sum(i => i.StudentCount);
            int totalSpecialties = institutions.Sum(i => i.SpecialtyCount);
            double avgStudentsPerInstitution = institutions.Average(i => i.StudentCount);
            var oldestInstitution = institutions.OrderBy(i => i.FoundationYear).First();
            var largestInstitution = institutions.OrderByDescending(i => i.StudentCount).First();
            
            Console.WriteLine($"► Загальна кількість закладів: {institutions.Length}");
            Console.WriteLine($"► Загальна кількість студентів: {totalStudents:N0}");
            Console.WriteLine($"► Загальна кількість спеціальностей: {totalSpecialties}");
            Console.WriteLine($"► Середня кількість студентів на заклад: {avgStudentsPerInstitution:F2}");
            Console.WriteLine($"► Найстаріший заклад: {oldestInstitution.Name} ({oldestInstitution.FoundationYear} рік)");
            Console.WriteLine($"► Найбільший заклад: {largestInstitution.Name} ({largestInstitution.StudentCount:N0} студентів)");

            // Демонстрація додаткових методів
            Console.WriteLine("\n5. ДОДАТКОВІ МЕТОДИ:");
            Console.WriteLine("─────────────────────────────────────────");
            
            Console.WriteLine("\n► Класифікація закладів за типом:");
            foreach (var inst in institutions.Take(3)) // Показуємо тільки перші 3 для компактності
            {
                Console.WriteLine($"  {inst.Name}: {inst.GetInstitutionType()}");
            }

            Console.WriteLine("\n► Середня кількість студентів на спеціальність для кожного закладу:");
            foreach (var inst in institutions.OrderByDescending(i => i.CalculateAverageStudentsPerSpecialty()).Take(3))
            {
                Console.WriteLine($"  {inst.Name}: {inst.CalculateAverageStudentsPerSpecialty():F2} студентів/спеціальність");
            }

            Console.WriteLine("\n╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║   Програма успішно виконана!                                ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            
            Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }
    }
}