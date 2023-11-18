using System.ComponentModel.DataAnnotations;

namespace HappyVacations.Models
{
    public class Team
    {
        public string Id { get; set; }  = Guid.NewGuid().ToString();
        
        [Required]
        public string Name { get; set; } = default!;

        [Required]
        public string Title { get; set; } = default!;

        public int HoursPerSP { get; set; } = 8;

        public int Overheads { get; set; } = 20;

        public int OperatingExpenses { get; set; } = 45;
    }
}
