using System;

namespace ESFA.DC.ILR.ValidationService.Rules.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime LastFridayInMonth(this DateTime dateTime)
        {
            var firstDayOfNextMonth = new DateTime(dateTime.Year, dateTime.Month, 1).AddMonths(1);
                        
            int vector = (((int)firstDayOfNextMonth.DayOfWeek + 1) % 7) + 1;

            return firstDayOfNextMonth.AddDays(-vector);
        }

        public static DateTime LastFridayInJuneForDateInAcademicYear(this DateTime dateTime)
        {
            if (dateTime.Month <= 8 && dateTime.Day <= 31)
            {
                return new DateTime(dateTime.Year, 6, 1).LastFridayInMonth();
            }

            return new DateTime(dateTime.Year + 1, 6, 1).LastFridayInMonth();
        }        
    }
}
