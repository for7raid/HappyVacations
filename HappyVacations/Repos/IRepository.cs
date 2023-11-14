using HappyVacations.Models;

namespace HappyVacations.Repos
{
    public interface IRepository
    {
        Task<List<CalendarException>> GetCalendarExpeptions();
        Task RemoveCalendarException(CalendarException calendarException);
        Task SaveCalendarException(CalendarException calendarException);

        Task<Team?> GetTeam(string id, string name);
        Task<List<Team>> GetTeamsList();
        Task SaveTeam(Team team);

        Task<List<Employee>> GetEmployees(string teamId);
        Task SaveEmployee(Employee employee);
    }
}