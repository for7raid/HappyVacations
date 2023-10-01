using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using HappyVacations.Models;

namespace HappyVacations.Repos
{
    public class YDBRepository : IRepository
    {
        private readonly AmazonDynamoDBConfig clientConfig;
        private readonly AmazonDynamoDBClient client;
        private readonly DynamoDBContext context;

        public YDBRepository() {

            clientConfig = new AmazonDynamoDBConfig();
            clientConfig.ServiceURL = "https://docapi.serverless.yandexcloud.net/ru-central1/b1g6cr7j44q82g1q3hmc/etnlllp146mvdtat958n";
            client = new AmazonDynamoDBClient("YCAJEx14pOZBAG_lNwNM6dnd5", "YCPReH4EDy6ysBj0J691-14EOu4oVVrZBp8pKHR0", clientConfig);
            context = new DynamoDBContext(client);
        }
        public async Task<List<CalendarException>> GetCalendarExpeptions()
        {
            var conditions = new List<ScanCondition>();
            var allDocs = await context.ScanAsync<CalendarException>(conditions).GetRemainingAsync();
            return allDocs;
        }

        public async Task<List<Employee>> GetEmployees(string teamId)
        {
            var conditions = new List<ScanCondition>
            {
                new ScanCondition(nameof(Employee.TeamId), Amazon.DynamoDBv2.DocumentModel.ScanOperator.Equal, teamId)
            };
            var allDocs = await context.ScanAsync<Employee>(conditions).GetRemainingAsync();
            return allDocs;
        }

        public async Task<Team?> GetTeam(string id, string name)
        {
            var conditions = new List<ScanCondition>
            {
                new ScanCondition(nameof(Team.Id), Amazon.DynamoDBv2.DocumentModel.ScanOperator.Equal, id),
                new ScanCondition(nameof(Team.Name), Amazon.DynamoDBv2.DocumentModel.ScanOperator.Equal, name)
            };
            var allDocs = await context.ScanAsync<Team>(conditions).GetRemainingAsync();
            return allDocs.FirstOrDefault();
        }

        public async Task<List<Team>> GetTeamsList()
        {
            var conditions = new List<ScanCondition>();
            var allDocs = await context.ScanAsync<Team>(conditions).GetRemainingAsync();
            return allDocs;
        }

        public async Task RemoveCalendarException(CalendarException calendarException)
        {
            await context.DeleteAsync(calendarException);
        }

        public async Task SaveCalendarException(CalendarException calendarException)
        {
            await context.SaveAsync(calendarException);
        }

        public async Task SaveEmployee(Employee employee)
        {
            await context.SaveAsync(employee);
        }

        public async Task SaveTeam(Team team)
        {
            await context.SaveAsync(team);
        }
    }
}
