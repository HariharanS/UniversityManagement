using System;
using System.Globalization;

namespace UniversityManagement.Domain.Helpers
{
    
    /// <summary>
    /// source 
    /// https://blogs.msdn.microsoft.com/shawnste/2006/01/24/iso-8601-week-of-year-format-in-microsoft-net/
    /// </summary>
    public static class DateTimeExtensions
    {
        private static readonly Calendar cal = CultureInfo.InvariantCulture.Calendar;
        public static int GetWeekOfYear(this DateTime date)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            var day = cal.GetDayOfWeek(date);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                date = date.AddDays(3);
            }
            // Return the week of our adjusted day
            return cal.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
    }
}