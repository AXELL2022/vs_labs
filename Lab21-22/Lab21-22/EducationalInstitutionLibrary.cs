using System;

namespace EducationalInstitutionLibrary
{
    /// <summary>
    /// Клас для представлення навчального закладу
    /// </summary>
    public class EducationalInstitution
    {
        // Поля класу
        private string name;
        private string address;
        private int yearFounded;
        private int studentCount;
        private int specialtyCount;

        // Властивості
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public int YearFounded
        {
            get { return yearFounded; }
            set 
            { 
                if (value >= 1800 && value <= DateTime.Now.Year)
                    yearFounded = value;
                else
                    throw new ArgumentException("Рік створення має бути між 1800 та поточним роком");
            }
        }

        public int StudentCount
        {
            get { return studentCount; }
            set 
            { 
                if (value >= 0)
                    studentCount = value;
                else
                    throw new ArgumentException("Кількість студентів не може бути від'ємною");
            }
        }

        public int SpecialtyCount
        {
            get { return specialtyCount; }
            set 
            { 
                if (value > 0)
                    specialtyCount = value;
                else
                    throw new ArgumentException("Кількість спеціальностей має бути більше 0");
            }
        }

        // Конструктор за замовчуванням
        public EducationalInstitution()
        {
            name = "";
            address = "";
            yearFounded = DateTime.Now.Year;
            studentCount = 0;
            specialtyCount = 1;
        }

        // Конструктор з параметрами
        public EducationalInstitution(string name, string address, int yearFounded, 
                                     int studentCount, int specialtyCount)
        {
            this.name = name;
            this.address = address;
            this.YearFounded = yearFounded;  // Використовуємо властивість для валідації
            this.StudentCount = studentCount;
            this.SpecialtyCount = specialtyCount;
        }

        // Конструктор копіювання
        public EducationalInstitution(EducationalInstitution other)
        {
            this.name = other.name;
            this.address = other.address;
            this.yearFounded = other.yearFounded;
            this.studentCount = other.studentCount;
            this.specialtyCount = other.specialtyCount;
        }

        // Метод для перетворення об'єкта в рядок для запису у файл
        public override string ToString()
        {
            return $"{name}|{address}|{yearFounded}|{studentCount}|{specialtyCount}";
        }

        // Метод для відображення інформації про об'єкт
        public string ToDisplayString()
        {
            return $"Назва: {name}\n" +
                   $"Адреса: {address}\n" +
                   $"Рік створення: {yearFounded}\n" +
                   $"Кількість студентів: {studentCount}\n" +
                   $"Кількість спеціальностей: {specialtyCount}";
        }

        // Метод для відображення короткої інформації
        public string ToShortString()
        {
            return $"{name} ({yearFounded} р.) - {studentCount} студентів";
        }

        // Статичний метод для створення об'єкта з рядка
        public static EducationalInstitution FromString(string data)
        {
            string[] parts = data.Split('|');
            
            if (parts.Length != 5)
                throw new FormatException("Невірний формат даних");

            return new EducationalInstitution(
                parts[0],
                parts[1],
                int.Parse(parts[2]),
                int.Parse(parts[3]),
                int.Parse(parts[4])
            );
        }

        // Метод для введення даних з консолі
        public void Input()
        {
            Console.Write("Введіть назву закладу: ");
            name = Console.ReadLine();

            Console.Write("Введіть адресу: ");
            address = Console.ReadLine();

            YearFounded = ReadIntWithValidation("Введіть рік створення: ", 1800, DateTime.Now.Year);
            StudentCount = ReadIntWithValidation("Введіть кількість студентів: ", 0, 100000);
            SpecialtyCount = ReadIntWithValidation("Введіть кількість спеціальностей: ", 1, 1000);
        }

        // Допоміжний метод для валідації введення цілих чисел
        private int ReadIntWithValidation(string prompt, int min, int max)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (int.TryParse(input, out value))
                {
                    if (value >= min && value <= max)
                    {
                        return value;
                    }
                    else
                    {
                        Console.WriteLine($"Значення має бути в діапазоні від {min} до {max}. Спробуйте ще раз.");
                    }
                }
                else
                {
                    Console.WriteLine("Помилка! Введіть коректне число.");
                }
            }
        }

        // Метод для виведення інформації на екран
        public void Display()
        {
            Console.WriteLine(ToDisplayString());
        }
    }
}
