using HappyVacations.Models;

namespace HappyVacations.ViewModels
{
    public class EmployeeEditViewModel
    {
        public Employee Item { get; init; } = default!;
        public IEnumerable<string> Roles { get; init; }
    }
}
