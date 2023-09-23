namespace HappyVacations.Models
{
    public class CalendarException
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime Date { get; set; }
        public CalendarExceptionType ExceptionType { get; set; } = CalendarExceptionType.Weekend;
        //public static explicit operator CalendarException(DateTime date) => new CalendarException { Date= date };
        public static implicit operator CalendarException(DateTime date) => new CalendarException { Date = date, ExceptionType = CalendarExceptionType.Weekend };

        public override bool Equals(object? obj)
        {
            return base.Equals(obj) || obj is CalendarException ce && ce.Date == Date;
        }
    }



    public enum CalendarExceptionType
    {
        Weekend = 0,
        Workday = 1
    }
}
