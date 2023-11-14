using System.ComponentModel.DataAnnotations;

namespace HappyVacations.Models
{
    public class Team
    {
        public string Id { get; set; }  = Guid.NewGuid().ToString();
        
        [Required]
        public string Name { get; set; } = default!;

        public int HoursPerSP { get; set; } = 8;

        public double Overheads { get; set; } = 0.2;

        public double OperatingExpenses { get; set; } = 0.45;
    }
}
