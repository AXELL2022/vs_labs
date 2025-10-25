using System;

namespace Lab16_17_Variant25
{
    /// Клас для представлення навчального закладу
    public class EducationalInstitution
    {
        // Приватні поля класу
        private string name;
        private string address;
        private int foundationYear;
        private int studentCount;
        private int specialtyCount;

        #region Конструктори
        
        /// Конструктор за замовчуванням (без параметрів)
        public EducationalInstitution()
        {
            name = "Невідомий заклад";
            address = "Невідома адреса";
            foundationYear = DateTime.Now.Year;
            studentCount = 0;
            specialtyCount = 1; // Мінімум одна спеціальність
        }
        
        /// Конструктор з параметрами
        public EducationalInstitution(string name, string address, int foundationYear, 
            int studentCount, int specialtyCount)
        {
            this.name = name;
            this.address = address;
            this.foundationYear = foundationYear;
            this.studentCount = studentCount > 0 ? studentCount : 0;
            this.specialtyCount = specialtyCount > 0 ? specialtyCount : 1;
        }
        
        /// Конструктор з частковими параметрами
        public EducationalInstitution(string name, int studentCount, int specialtyCount)
        {
            this.name = name;
            this.address = "Не вказано";
            this.foundationYear = DateTime.Now.Year;
            this.studentCount = studentCount > 0 ? studentCount : 0;
            this.specialtyCount = specialtyCount > 0 ? specialtyCount : 1;
        }

        #endregion

        #region Властивості
        
        /// Властивість для доступу до назви закладу
        public string Name
        {
            get { return name; }
            set 
            { 
                if (!string.IsNullOrWhiteSpace(value))
                    name = value;
                else
                    throw new ArgumentException("Назва не може бути порожньою");
            }
        }
        
        /// Властивість для доступу до адреси
        public string Address
        {
            get { return address; }
            set 
            { 
                if (!string.IsNullOrWhiteSpace(value))
                    address = value;
                else
                    throw new ArgumentException("Адреса не може бути порожньою");
            }
        }
        
        /// Властивість для доступу до року заснування
        public int FoundationYear
        {
            get { return foundationYear; }
            set 
            { 
                if (value > 1800 && value <= DateTime.Now.Year)
                    foundationYear = value;
                else
                    throw new ArgumentException("Некоректний рік заснування");
            }
        }
        
        /// Властивість для доступу до кількості студентів
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
        
        /// Властивість для доступу до кількості спеціальностей
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

        #endregion

        #region Методи
        
        /// Обов'язковий метод: Обчислення середнього арифметичного значення 
        /// кількості студентів для спеціальності
        public double CalculateAverageStudentsPerSpecialty()
        {
            if (specialtyCount == 0)
                return 0;
            
            return (double)studentCount / specialtyCount;
        }
        
        /// Метод для обчислення віку закладу
        public int GetAge()
        {
            return DateTime.Now.Year - foundationYear;
        }
        
        /// Метод для визначення типу закладу за кількістю студентів
        public string GetInstitutionType()
        {
            if (studentCount < 500)
                return "Малий навчальний заклад";
            else if (studentCount < 2000)
                return "Середній навчальний заклад";
            else if (studentCount < 10000)
                return "Великий навчальний заклад";
            else
                return "Дуже великий навчальний заклад";
        }
        
        /// Метод для виведення інформації про об'єкт
        public void DisplayInfo()
        {
            Console.WriteLine("========================================");
            Console.WriteLine($"Назва закладу: {name}");
            Console.WriteLine($"Адреса: {address}");
            Console.WriteLine($"Рік заснування: {foundationYear} (вік: {GetAge()} років)");
            Console.WriteLine($"Кількість студентів: {studentCount}");
            Console.WriteLine($"Кількість спеціальностей: {specialtyCount}");
            Console.WriteLine($"Середня кількість студентів на спеціальність: {CalculateAverageStudentsPerSpecialty():F2}");
            Console.WriteLine($"Тип закладу: {GetInstitutionType()}");
            Console.WriteLine("========================================");
        }
        
        /// Перевизначення методу ToString()
        public override string ToString()
        {
            return $"{name} (Студентів: {studentCount}, Спеціальностей: {specialtyCount})";
        }

        #endregion

        #region Перевантаження операторів
        
        /// Перевантаження оператора == для порівняння двох закладів
        public static bool operator ==(EducationalInstitution inst1, EducationalInstitution inst2)
        {
            if (ReferenceEquals(inst1, inst2))
                return true;
            
            if (ReferenceEquals(inst1, null) || ReferenceEquals(inst2, null))
                return false;
            
            return inst1.name == inst2.name && inst1.address == inst2.address;
        }
        
        /// Перевантаження оператора != для порівняння двох закладів
        public static bool operator !=(EducationalInstitution inst1, EducationalInstitution inst2)
        {
            return !(inst1 == inst2);
        }
        
        /// Перевантаження оператора < для порівняння за кількістю студентів
        public static bool operator <(EducationalInstitution inst1, EducationalInstitution inst2)
        {
            if (ReferenceEquals(inst1, null) || ReferenceEquals(inst2, null))
                return false;
            
            return inst1.studentCount < inst2.studentCount;
        }
        
        /// Перевантаження оператора > для порівняння за кількістю студентів
        public static bool operator >(EducationalInstitution inst1, EducationalInstitution inst2)
        {
            if (ReferenceEquals(inst1, null) || ReferenceEquals(inst2, null))
                return false;
            
            return inst1.studentCount > inst2.studentCount;
        }
        
        /// Перевантаження оператора + для об'єднання двох закладів
        public static EducationalInstitution operator +(EducationalInstitution inst1, EducationalInstitution inst2)
        {
            if (ReferenceEquals(inst1, null) || ReferenceEquals(inst2, null))
                return null;
            
            return new EducationalInstitution(
                $"{inst1.name} + {inst2.name}",
                inst1.address,
                Math.Min(inst1.foundationYear, inst2.foundationYear),
                inst1.studentCount + inst2.studentCount,
                inst1.specialtyCount + inst2.specialtyCount
            );
        }
        
        /// Перевизначення методу Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            
            EducationalInstitution other = (EducationalInstitution)obj;
            return this == other;
        }
        
        /// Перевизначення методу GetHashCode
        public override int GetHashCode()
        {
            return (name?.GetHashCode() ?? 0) ^ (address?.GetHashCode() ?? 0);
        }

        #endregion
    }
}