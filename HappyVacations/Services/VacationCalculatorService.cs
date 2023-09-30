using HappyVacations.Models;

namespace HappyVacations.Services
{
    public class VacationCalculatorService
    {

        static Dictionary<string, int> workDaysByMonth = new();

        const double salaryConst = 1000;
        const double holidayCost = salaryConst / 29.3;
        public VacationCalculatorService()
        {

        }
        public (bool HasError, string Message) Validate(Employee employee, VacationItem item, IEnumerable<CalendarException> CalendarExceptions)
        {
            if (item is not null && item.ItemType == VacationItemType.Regular)
            {
                var nextDate = item.Date.AddDays(1);
                var hasNextDate = employee.Items.Any(i => i.Date == nextDate & !i.Cancelled & i.ItemType == VacationItemType.Regular);
                var exception = CalendarExceptions.FirstOrDefault(e => e.Date == nextDate);

                var hasError = !hasNextDate && (
                    nextDate.DayOfWeek == DayOfWeek.Saturday ||
                    nextDate.DayOfWeek == DayOfWeek.Sunday ||
                    (exception is not null && exception.ExceptionType == CalendarExceptionType.Weekend)
                    );

                return (hasError, hasError ? "Отпуск не может закончится перед выходными или праздникам" : string.Empty);
            }

            return (false, string.Empty);

        }

        public double SalaryIndex(Employee employee, DateTime start, DateTime end, IEnumerable<CalendarException> CalendarExceptions)
        {
            var items = employee.Items.Where(i => i.Date >= start & i.Date <= end).ToList();
            var vacationsByMonth = items.GroupBy(i => i.Date.ToString("yyyy-MM")).ToDictionary(g => g.Key, g => g.Count(e => !e.Cancelled & e.ItemType == VacationItemType.Regular));

            var totalSalary = 0D;
            var workSalary = 0D;
            for (var month = start; month <= end; month = month.AddMonths(1))
            {


                if (!workDaysByMonth.ContainsKey(month.ToString("yyyy-MM")))
                {
                    FillWorkDayByMonth(month, CalendarExceptions);
                }

                var dayCost = salaryConst / workDaysByMonth[month.ToString("yyyy-MM")];

                var workDaysSalary = dayCost * GetWorkDaysInMonth(employee, month, CalendarExceptions);
                
                var holidaysSalary = holidayCost * (vacationsByMonth.ContainsKey(month.ToString("yyyy-MM")) ? vacationsByMonth[month.ToString("yyyy-MM")] : 0);
                
                var monthTotal = workDaysSalary + holidaysSalary;
                totalSalary += monthTotal;
                workSalary += salaryConst;
            }

            var salaryIndex = totalSalary / workSalary;

            return salaryIndex;
        }

        public int GetWorkDaysInPeriod(Employee employee, DateTime start, DateTime end, IEnumerable<CalendarException> CalendarExceptions)
        {
            var days = 0;

            for (var day = start; day <= end; day = day.AddDays(1))
            {

                var vacation = employee.Items.FirstOrDefault(i => !i.Cancelled & i.Date == day & i.ItemType == VacationItemType.Regular);

                var exception = CalendarExceptions.FirstOrDefault(e => e.Date == day);
                var isWorkDay = day.DayOfWeek != DayOfWeek.Sunday && day.DayOfWeek != DayOfWeek.Saturday && exception is null || ( exception is not null && exception.ExceptionType == CalendarExceptionType.Workday);

                if (vacation is null && isWorkDay)
                {
                    days++;
                }

                
            }

            return days;
        }

        public int GetWorkDaysInMonth(Employee employee, DateTime month, IEnumerable<CalendarException> CalendarExceptions) 
        {
            var end = month.AddMonths(1).AddDays(-1);
            return GetWorkDaysInPeriod(employee, month, end, CalendarExceptions);
        }

        private void FillWorkDayByMonth(DateTime month, IEnumerable<CalendarException> CalendarExceptions)
        {
            var days = 0;
            for (var day = month; day < month.AddMonths(1); day = day.AddDays(1))
            {
                var exception = CalendarExceptions.FirstOrDefault(e => e.Date == day);

                if (exception is not null)
                {
                    if (exception.ExceptionType == CalendarExceptionType.Workday)
                    {
                        days++;
                    }
                }
                else if (day.DayOfWeek != DayOfWeek.Sunday & day.DayOfWeek != DayOfWeek.Saturday)
                {
                    days++;
                }
            }

            workDaysByMonth[month.ToString("yyyy-MM")] = days;

        }

        public int TotalDays(Employee employee, DateTime start, DateTime end)
        {
            return employee.Items.Count(i => !i.Cancelled & i.ItemType == VacationItemType.Regular && i.Date >= start & i.Date <= end);
        }
    }
}
