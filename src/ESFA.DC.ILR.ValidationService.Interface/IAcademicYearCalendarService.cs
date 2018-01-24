using System;

namespace ESFA.DC.ILR.ValidationService.Interface
{
    public interface IAcademicYearCalendarService
    {
        DateTime LastFridayInJuneForDateInAcademicYear(DateTime dateTime);
    }
}
