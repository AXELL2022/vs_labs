using System;
using System.IO;
using System.Text;

namespace Lab20_Task1_Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "mynum.txt";
            
            Console.WriteLine("=== Програма запису дробових чисел у файл ===");
            Console.WriteLine("Файл буде створено у режимі доповнення");
            Console.WriteLine("Введіть числа (введіть 'q' для завершення)\n");
            
            try
            {
                // Відкриваємо файл у режимі доповнення (append = true)
                using (StreamWriter sw = new StreamWriter(fileName, true, Encoding.Default))
                {
                    while (true)
                    {
                        Console.Write("Введіть дробове число: ");
                        string input = Console.ReadLine();
                        
                        // Перевірка на вихід
                        if (input.ToLower() == "q")
                        {
                            break;
                        }
                        
                        // Спроба конвертувати введене значення в число
                        if (double.TryParse(input, out double number))
                        {
                            // Записуємо число у файл
                            sw.WriteLine(number);
                            Console.WriteLine($"✓ Число {number} успішно додано у файл\n");
                        }
                        else
                        {
                            Console.WriteLine("✗ Помилка! Введіть коректне дробове число.\n");
                        }
                    }
                }
                
                Console.WriteLine($"\nРобота завершена. Всі числа збережено у файл '{fileName}'");
                Console.WriteLine("Файл створено у поточній директорії програми.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Помилка вводу/виводу: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Помилка: {e.Message}");
            }
            
            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}
