using SQLite;

namespace HRaport.Models
{
    public class Employee
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public DateTime? Birthdate { get; set; }
        public DateTime? EmploymentDate { get; set; }
        public int Rating { get; set; }
        public int YearSalary { get; set; }

        public string GetFullName() => $"{FirstName} {LastName}";

    }
}
