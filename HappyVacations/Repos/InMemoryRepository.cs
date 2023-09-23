using HappyVacations.Models;

namespace HappyVacations.Repos
{
    public class InMemoryRepository : IRepository
    {
        static List<Team> Teams = new List<Team>
        {
            new Team{ Name = "adacta", Id = "sdf323asdf" }
        };

        static List<Employee> Employees { get; set; } = new List<Employee>
        {
            new Employee { Name = "Peppa", TeamId = "sdf323asdf", Items = new()
            {
                new VacationItem { Date = new(2023, 01, 10) },
                new VacationItem { Date = new(2023, 05, 11) },
                new VacationItem { Date = new(2023, 05, 12) },
                new VacationItem { Date = new(2023, 06, 01) },
                new VacationItem { Date = new(2023, 09, 19) },
                new VacationItem { Date = new(2023, 09, 20), ItemType = VacationItemType.NonPayed },
                new VacationItem { Date = new(2023, 09, 21), ItemType = VacationItemType.DonorDay },
                new VacationItem { Date = new(2023, 09, 22), Cancelled = true },
            } },

            new Employee { Name = "Rebecca", TeamId = "sdf323asdf", Role = "Аналитики", Items = new()
            {
                new VacationItem { Date = new(2023, 01, 14) },
                new VacationItem { Date = new(2023, 05, 1) },
                new VacationItem { Date = new(2023, 05, 12) },
                new VacationItem { Date = new(2023, 06, 11) },
                new VacationItem { Date = new(2023, 09, 19) },
                new VacationItem { Date = new(2023, 09, 20) },
                new VacationItem { Date = new(2023, 09, 21) },
                new VacationItem { Date = new(2023, 09, 22), Cancelled = true },
            } },
            new Employee { Name = "Suzy", TeamId = "sdf323asdf", Role = "Аналитики", Items = new()
            {
                new VacationItem { Date = new(2023, 01, 14) },
                new VacationItem { Date = new(2023, 05, 1) },
                new VacationItem { Date = new(2023, 05, 12) },
                new VacationItem { Date = new(2023, 06, 11) },
                new VacationItem { Date = new(2023, 09, 19) },
                new VacationItem { Date = new(2023, 09, 20) },
                new VacationItem { Date = new(2023, 09, 21) },
                new VacationItem { Date = new(2023, 09, 22), Cancelled = true },
            } }
        };

        static List<CalendarException> CalendarExceptions = new()
            {
                 new DateTime(2023,1,1),new DateTime(2023,1,2),new DateTime(2023,1,3),new DateTime(2023,1,4),new DateTime(2023,1,5),new DateTime(2023,1,6),new DateTime(2023,1,7),new DateTime(2023,1,8),
                  new DateTime(2023,2,23),new DateTime(2023,2,24),
                  new DateTime(2023,3,8),
                  new DateTime(2023,5,1),
                  new DateTime(2023,5,8),new DateTime(2023,5,9),
                  new DateTime(2023,6,12),
                  new DateTime(2023,11,6)
            };
        public InMemoryRepository() { }

        public Task SaveTeam(Team team)
        {
            Teams.Add(team);
            return Task.CompletedTask;
        }

        public Task<Team?> GetTeam(string id, string name)
        {
            return Task.FromResult(Teams.FirstOrDefault(t => t.Id == id && t.Name == name));
        }

        public Task<List<Employee>> GetEmployees(string teamId)
        {
            return Task.FromResult(Employees.Where(e => e.TeamId == teamId).ToList());
        }

        public Task SaveEmployee(Employee employee)
        {

            if (!Employees.Any(e => e.Id == employee.Id))
            {
                Employees.Add(employee);
            }

            return Task.CompletedTask;
        }

        public Task<List<CalendarException>> GetCalendarExpeptions()
        {

            return Task.FromResult(CalendarExceptions);
        }
        public Task SaveCalendarException(CalendarException calendarException)
        {

            if (!CalendarExceptions.Any(c => c.Date == calendarException.Date))
            {
                CalendarExceptions.Add(calendarException);
            }

            return Task.CompletedTask;
        }

        public Task RemoveCalendarException(CalendarException calendarException)
        {

            var item = CalendarExceptions.FirstOrDefault(c => c.Date == calendarException.Date);
            if (item is not null)
            {
                CalendarExceptions.Remove(item);
            }

            return Task.CompletedTask;
        }

    }
}
