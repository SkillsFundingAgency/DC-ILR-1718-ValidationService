using System;
using ESFA.DC.ILR.ValidationService.Interface;

namespace ESFA.DC.ILR.ValidationService.Service.AcademicYearCalendarService
{
    public class AcademicYearCalendarService : IAcademicYearCalendarService
    {
        public DateTime LastFridayInJuneForDateInAcademicYear(DateTime dateTime)
        {
            if (dateTime.Month <= 8 && dateTime.Day <= 31)
            {
                return LastFridayInMonth(new DateTime(dateTime.Year, 6, 1));
            }

            return LastFridayInMonth(new DateTime(dateTime.Year + 1, 6, 1));
        }

        public DateTime LastFridayInMonth(DateTime dateTime)
        {
            var firstDayOfNextMonth = new DateTime(dateTime.Year, dateTime.Month, 1).AddMonths(1);

            int vector = (((int)firstDayOfNextMonth.DayOfWeek + 1) % 7) + 1;

            return firstDayOfNextMonth.AddDays(-vector);
        }
    }
}
