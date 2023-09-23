using System.ComponentModel.DataAnnotations;

namespace HappyVacations.Models
{
    public class Team
    {
        public string Id { get; set; }  = Guid.NewGuid().ToString();
        
        [Required]
        public string Name { get; set; } = default!;
    }
}
