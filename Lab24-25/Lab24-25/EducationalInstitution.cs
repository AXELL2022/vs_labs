using System;

namespace EducationalInstitutionLibrary
{
    public class EducationalInstitution : IEquatable<EducationalInstitution>
    {
        private string name;
        private string address;
        private int foundationYear;
        private int studentCount;
        private int specialtyCount;
        public EducationalInstitution()
        {
            name = "Невідомо";
            address = "Не вказано";
            foundationYear = 1900;
            studentCount = 0;
            specialtyCount = 0;
        }
        public EducationalInstitution(string name, string address, int foundationYear, 
                                     int studentCount, int specialtyCount)
        {
            this.name = name;
            this.address = address;
            this.foundationYear = foundationYear;
            this.studentCount = studentCount;
            this.specialtyCount = specialtyCount;
        }
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
        public int FoundationYear
        {
            get { return foundationYear; }
            set 
            { 
                if (value >= 1800 && value <= DateTime.Today.Year)
                    foundationYear = value; 
            }
        }
        public int StudentCount
        {
            get { return studentCount; }
            set 
            { 
                if (value >= 0)
                    studentCount = value; 
            }
        }
        public int SpecialtyCount
        {
            get { return specialtyCount; }
            set 
            { 
                if (value >= 0)
                    specialtyCount = value; 
            }
        }
        public override string ToString()
        {
            return $"{name,-40} | {address,-30} | {foundationYear,4} | {studentCount,7} | {specialtyCount,5}";
        }
        public bool Equals(EducationalInstitution other)
        {
            if (other == null) return false;
            return (this.name == other.name && this.address == other.address);
        }
        public void Show()
        {
            Console.WriteLine($"Назва: {name}");
            Console.WriteLine($"Адреса: {address}");
            Console.WriteLine($"Рік створення: {foundationYear}");
            Console.WriteLine($"Кількість студентів: {studentCount}");
            Console.WriteLine($"Кількість спеціальностей: {specialtyCount}");
        }
        public int GetAge()
        {
            return DateTime.Today.Year - foundationYear;
        }
    }
}