using HappyVacations.Models;
using Microsoft.JSInterop;

namespace HappyVacations.Repos
{
    public class FirestoreReporistory : IRepository
    {
        private readonly IJSRuntime _jS;

        public FirestoreReporistory(IJSRuntime JS)
        {
            _jS = JS;
        }
        public async Task<List<CalendarException>> GetCalendarExpeptions()
        {
            return await _jS.InvokeAsync<List<CalendarException>>("firestore.getCalendarExpeptions");
        }

        public async Task<List<Employee>> GetEmployees(string teamId)
        {
            return await _jS.InvokeAsync<List<Employee>>("firestore.getEmployees", teamId);
        }

        public async Task<Team?> GetTeam(string id, string name)
        {
            return await _jS.InvokeAsync<Team>("firestore.getTeam", id, name);
        }

        public async Task RemoveCalendarException(CalendarException calendarException)
        {
            await _jS.InvokeVoidAsync("firestore.removeCalendarExpeption", calendarException.Id);

        }

        public async Task SaveCalendarException(CalendarException calendarException)
        {
            await _jS.InvokeVoidAsync("firestore.saveCalendarExpeption", calendarException);
        }

        public async Task SaveEmployee(Employee employee)
        {
            await _jS.InvokeVoidAsync("firestore.saveEmployee", employee);
        }

        public async Task SaveTeam(Team team)
        {
            await _jS.InvokeVoidAsync("firestore.saveTeam", team);
        }
    }
}
