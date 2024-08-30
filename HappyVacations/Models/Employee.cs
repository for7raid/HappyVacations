using System.ComponentModel.DataAnnotations;

namespace HappyVacations.Models
{
    public class Employee
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string TeamId { get; set; }

        [Required (AllowEmptyStrings = false, ErrorMessage ="Заполните имя сотрудника")]
        public string Name { get; set; } = default!;
        public string? Role { get; set; }
        public HashSet<VacationItem> Items { get; set; } = new();

        public DateTime? HireDate { get; set; }
        public DateTime? FireDate { get; set; }
    }
}
