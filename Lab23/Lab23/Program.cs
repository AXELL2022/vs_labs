using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab23_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════════════════╗");
                Console.WriteLine("║   ЛАБОРАТОРНА РОБОТА №23 - КЛАСИ КОЛЕКЦІЙ             ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════╝");
                Console.WriteLine("\n1. Завдання 1: Робота зі списком чисел");
                Console.WriteLine("2. Завдання 2: Робота зі списком студентів");
                Console.WriteLine("3. Додатково: Робота зі стеком");
                Console.WriteLine("4. Додатково: Робота з чергою");
                Console.WriteLine("5. Додатково: Робота зі словником");
                Console.WriteLine("0. Вихід");
                Console.Write("\nВиберіть завдання: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Task1_NumbersList();
                        break;
                    case "2":
                        Task2_StudentsList();
                        break;
                    case "3":
                        Task3_Stack();
                        break;
                    case "4":
                        Task4_Queue();
                        break;
                    case "5":
                        Task5_Dictionary();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Невірний вибір!");
                        break;
                }
            }
        }

        // =============== ЗАВДАННЯ 1: РОБОТА ЗІ СПИСКОМ ЧИСЕЛ ===============
        static void Task1_NumbersList()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║   ЗАВДАННЯ 1: РОБОТА ЗІ СПИСКОМ ЧИСЕЛ                  ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝\n");

            // Створення списку
            List<int> numbers = new List<int>();

            // Додавання значень
            Console.WriteLine("Додавання значень до списку:");
            numbers.Add(45);
            numbers.Add(12);
            numbers.Add(78);
            numbers.Add(23);
            numbers.Add(89);
            numbers.Add(34);
            numbers.Add(67);
            numbers.Add(56);

            // Виведення вмісту списку
            Console.WriteLine("\nВміст списку:");
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            // Визначення максимального елемента
            int max = numbers.Max();
            Console.WriteLine($"\nМаксимальний елемент: {max}");

            // Середньоарифметичне значення
            double avg = numbers.Average();
            Console.WriteLine($"Середнє арифметичне: {avg:F2}");

            // Упорядкування списку
            numbers.Sort();
            Console.WriteLine("\nВідсортований список:");
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            // Виведення у зворотній послідовності
            numbers.Reverse();
            Console.WriteLine("\nСписок у зворотній послідовності:");
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            // Сума значень
            int sum = numbers.Sum();
            Console.WriteLine($"\nСума всіх значень: {sum}");

            // ========== ДОДАТКОВА ЧАСТИНА: РОБОТА З ФАЙЛОМ ==========
            Console.WriteLine("\n\n--- РОБОТА З ФАЙЛОМ ---");
            
            // Запис у файл
            string fileName = "listnum.txt";
            File.WriteAllLines(fileName, numbers.Select(n => n.ToString()));
            Console.WriteLine($"\nДані записано у файл {fileName}");

            // Читання з файлу та створення нового списку
            List<int> newNumbers = new List<int>();
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                int num = int.Parse(line);
                newNumbers.Add(num + 10); // Додаємо 10 до кожного значення
            }

            Console.WriteLine("\nНовий список (кожне значення +10):");
            foreach (int num in newNumbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            // ========== ПОШУК ЗАДАНОГО ЧИСЛА ==========
            Console.Write("\n\nВведіть число для пошуку: ");
            if (int.TryParse(Console.ReadLine(), out int searchNum))
            {
                numbers.Sort(); // Повертаємо сортування
                
                if (numbers.Contains(searchNum))
                {
                    int index = numbers.IndexOf(searchNum);
                    Console.WriteLine($"Число {searchNum} знайдено на позиції {index}");
                }
                else
                {
                    Console.WriteLine($"Число {searchNum} не знайдено у списку");
                }

                // Пошук чисел більших за задане
                var greaterNumbers = numbers.Where(n => n > searchNum).ToList();
                Console.WriteLine($"\nКількість чисел більших за {searchNum}: {greaterNumbers.Count}");
                if (greaterNumbers.Count > 0)
                {
                    Console.Write("Ці числа: ");
                    foreach (int num in greaterNumbers)
                    {
                        Console.Write(num + " ");
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine("\n\nНатисніть будь-яку клавішу для продовження...");
            Console.ReadKey();
        }

        // =============== ЗАВДАННЯ 2: РОБОТА ЗІ СПИСКОМ СТУДЕНТІВ ===============
        static void Task2_StudentsList()
        {
            List<string> students = new List<string>();
            bool back = false;

            while (!back)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════════════════╗");
                Console.WriteLine("║   ЗАВДАННЯ 2: РОБОТА ЗІ СПИСКОМ СТУДЕНТІВ             ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════╝\n");
                Console.WriteLine("1. Додати студента у список");
                Console.WriteLine("2. Вилучити студента із списку");
                Console.WriteLine("3. Відсортувати список студентів");
                Console.WriteLine("4. Вивести на екран список студентів");
                Console.WriteLine("5. Пошук студента у списку");
                Console.WriteLine("0. Повернутися до головного меню");
                Console.Write("\nВаш вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("\nВведіть прізвище студента: ");
                        string newStudent = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newStudent))
                        {
                            students.Add(newStudent);
                            Console.WriteLine($"Студента '{newStudent}' додано до списку");
                        }
                        else
                        {
                            Console.WriteLine("Прізвище не може бути порожнім!");
                        }
                        Console.WriteLine("\nНатисніть будь-яку клавішу...");
                        Console.ReadKey();
                        break;

                    case "2":
                        if (students.Count == 0)
                        {
                            Console.WriteLine("\nСписок порожній!");
                        }
                        else
                        {
                            Console.Write("\nВведіть прізвище студента для видалення: ");
                            string removeStudent = Console.ReadLine();
                            if (students.Remove(removeStudent))
                            {
                                Console.WriteLine($"Студента '{removeStudent}' вилучено зі списку");
                            }
                            else
                            {
                                Console.WriteLine($"Студента '{removeStudent}' не знайдено у списку");
                            }
                        }
                        Console.WriteLine("\nНатисніть будь-яку клавішу...");
                        Console.ReadKey();
                        break;

                    case "3":
                        if (students.Count == 0)
                        {
                            Console.WriteLine("\nСписок порожній!");
                        }
                        else
                        {
                            students.Sort();
                            Console.WriteLine("\nСписок відсортовано за алфавітом");
                        }
                        Console.WriteLine("\nНатисніть будь-яку клавішу...");
                        Console.ReadKey();
                        break;

                    case "4":
                        Console.WriteLine("\n--- СПИСОК СТУДЕНТІВ ---");
                        if (students.Count == 0)
                        {
                            Console.WriteLine("Список порожній!");
                        }
                        else
                        {
                            for (int i = 0; i < students.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {students[i]}");
                            }
                            Console.WriteLine($"\nВсього студентів: {students.Count}");
                        }
                        Console.WriteLine("\nНатисніть будь-яку клавішу...");
                        Console.ReadKey();
                        break;

                    case "5":
                        if (students.Count == 0)
                        {
                            Console.WriteLine("\nСписок порожній!");
                        }
                        else
                        {
                            Console.Write("\nВведіть прізвище для пошуку: ");
                            string searchStudent = Console.ReadLine();
                            int index = students.IndexOf(searchStudent);
                            
                            if (index >= 0)
                            {
                                Console.WriteLine($"\nСтудента '{searchStudent}' знайдено!");
                                Console.WriteLine($"Порядковий номер у списку: {index + 1}");
                            }
                            else
                            {
                                Console.WriteLine($"\nСтудента '{searchStudent}' відсутній у списку");
                            }
                        }
                        Console.WriteLine("\nНатисніть будь-яку клавішу...");
                        Console.ReadKey();
                        break;

                    case "0":
                        back = true;
                        break;

                    default:
                        Console.WriteLine("\nНевірний вибір!");
                        Console.WriteLine("Натисніть будь-яку клавішу...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // =============== ДОДАТКОВО: РОБОТА ЗІ СТЕКОМ ===============
        static void Task3_Stack()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║   ДОДАТКОВО: РОБОТА ЗІ СТЕКОМ (STACK)                 ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝\n");

            Stack<int> stack = new Stack<int>();

            Console.WriteLine("Стек - структура даних LIFO (Last In, First Out)");
            Console.WriteLine("Останній доданий елемент виходить першим\n");

            // Додавання елементів у стек (Push)
            Console.WriteLine("Додавання елементів у стек (Push):");
            int[] values = { 10, 20, 30, 40, 50 };
            foreach (int val in values)
            {
                stack.Push(val);
                Console.WriteLine($"  Додано: {val}");
            }

            Console.WriteLine($"\nКількість елементів у стеку: {stack.Count}");

            // Перегляд верхнього елемента (Peek)
            Console.WriteLine($"Верхній елемент стеку (Peek): {stack.Peek()}");

            // Виведення всіх елементів
            Console.WriteLine("\nВміст стеку (зверху вниз):");
            foreach (int val in stack)
            {
                Console.WriteLine($"  {val}");
            }

            // Видалення елементів (Pop)
            Console.WriteLine("\n\nВидалення елементів зі стеку (Pop):");
            while (stack.Count > 0)
            {
                int popped = stack.Pop();
                Console.WriteLine($"  Видалено: {popped}, залишилось у стеку: {stack.Count}");
            }

            Console.WriteLine("\nСтек порожній!");
            Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
            Console.ReadKey();
        }

        // =============== ДОДАТКОВО: РОБОТА З ЧЕРГОЮ ===============
        static void Task4_Queue()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║   ДОДАТКОВО: РОБОТА З ЧЕРГОЮ (QUEUE)                  ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝\n");

            Queue<string> queue = new Queue<string>();

            Console.WriteLine("Черга - структура даних FIFO (First In, First Out)");
            Console.WriteLine("Перший доданий елемент виходить першим\n");

            // Додавання елементів у чергу (Enqueue)
            Console.WriteLine("Додавання елементів у чергу (Enqueue):");
            string[] clients = { "Клієнт 1", "Клієнт 2", "Клієнт 3", "Клієнт 4", "Клієнт 5" };
            foreach (string client in clients)
            {
                queue.Enqueue(client);
                Console.WriteLine($"  Додано до черги: {client}");
            }

            Console.WriteLine($"\nКількість елементів у черзі: {queue.Count}");

            // Перегляд першого елемента (Peek)
            Console.WriteLine($"Перший у черзі (Peek): {queue.Peek()}");

            // Виведення всіх елементів
            Console.WriteLine("\nВміст черги (спереду назад):");
            foreach (string client in queue)
            {
                Console.WriteLine($"  {client}");
            }

            // Обслуговування клієнтів (Dequeue)
            Console.WriteLine("\n\nОбслуговування клієнтів (Dequeue):");
            while (queue.Count > 0)
            {
                string served = queue.Dequeue();
                Console.WriteLine($"  Обслуговано: {served}, залишилось у черзі: {queue.Count}");
            }

            Console.WriteLine("\nЧерга порожня!");
            Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
            Console.ReadKey();
        }

        // =============== ДОДАТКОВО: РОБОТА ЗІ СЛОВНИКОМ ===============
        static void Task5_Dictionary()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║   ДОДАТКОВО: РОБОТА ЗІ СЛОВНИКОМ (DICTIONARY)         ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝\n");

            // Створення словника студентів та їх оцінок
            Dictionary<string, int> studentGrades = new Dictionary<string, int>();

            Console.WriteLine("Словник - колекція пар 'ключ-значення'\n");

            // Додавання елементів
            Console.WriteLine("Додавання студентів та їх оцінок:");
            studentGrades.Add("Іваненко", 95);
            studentGrades.Add("Петренко", 87);
            studentGrades.Add("Сидоренко", 92);
            studentGrades.Add("Коваленко", 78);
            studentGrades.Add("Шевченко", 88);

            foreach (var student in studentGrades)
            {
                Console.WriteLine($"  {student.Key}: {student.Value} балів");
            }

            Console.WriteLine($"\nКількість записів у словнику: {studentGrades.Count}");

            // Пошук за ключем
            Console.Write("\nВведіть прізвище студента для пошуку оцінки: ");
            string searchName = Console.ReadLine();

            if (studentGrades.ContainsKey(searchName))
            {
                Console.WriteLine($"Оцінка студента {searchName}: {studentGrades[searchName]} балів");
            }
            else
            {
                Console.WriteLine($"Студента {searchName} не знайдено у словнику");
            }

            // Статистика
            Console.WriteLine("\n--- СТАТИСТИКА ---");
            Console.WriteLine($"Максимальна оцінка: {studentGrades.Values.Max()} балів");
            Console.WriteLine($"Мінімальна оцінка: {studentGrades.Values.Min()} балів");
            Console.WriteLine($"Середня оцінка: {studentGrades.Values.Average():F2} балів");

            // Виведення студентів з оцінкою вище середньої
            double avgGrade = studentGrades.Values.Average();
            Console.WriteLine($"\nСтуденти з оцінкою вище середньої ({avgGrade:F2}):");
            foreach (var student in studentGrades)
            {
                if (student.Value > avgGrade)
                {
                    Console.WriteLine($"  {student.Key}: {student.Value} балів");
                }
            }

            Console.WriteLine("\n\nНатисніть будь-яку клавішу для продовження...");
            Console.ReadKey();
        }
    }
}