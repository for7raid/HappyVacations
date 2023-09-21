namespace HappyVacations.Models
{
    public class CalendarException
    {
        public DateTime Date { get; set; }
        public CalendarExceptionType ExceptionType { get; set; } = CalendarExceptionType.Weekend;
        //public static explicit operator CalendarException(DateTime date) => new CalendarException { Date= date };
        public static implicit operator CalendarException(DateTime date) => new CalendarException { Date = date, ExceptionType = CalendarExceptionType.Weekend };
    }



    public enum CalendarExceptionType
    {
        Weekend = 0,
        Workday = 1
    }
}
