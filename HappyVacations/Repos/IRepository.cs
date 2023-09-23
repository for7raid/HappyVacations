using HappyVacations.Models;

namespace HappyVacations.Repos
{
    public interface IRepository
    {
        Task<List<CalendarException>> GetCalendarExpeptions();
        Task<List<Employee>> GetEmployees(string teamId);
        Task<Team?> GetTeam(string id, string name);
        Task RemoveCalendarException(CalendarException calendarException);
        Task SaveCalendarException(CalendarException calendarException);
        Task SaveEmployee(Employee employee);
        Task SaveTeam(Team team);
    }
}