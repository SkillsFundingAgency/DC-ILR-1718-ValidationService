using ESFA.DC.ILR.ValidationService.Interface;
using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR.ValidationService.Service.ValidationDataService
{
    public class ValidationDataService : IValidationDataService
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        private readonly DateTime _academicYearEnd = new DateTime(2018, 7, 31);
        private readonly DateTime _academicYearJanuaryFirst = new DateTime(2018, 1, 1);
        private readonly DateTime _academicYearStart = new DateTime(2017, 8, 1);
        private readonly IEnumerable<long> _apprenticeshipProgTypes = new HashSet<long>() { 2, 3, 20, 21, 2, 23, 25 };
        private readonly DateTime _apprenticeshipProgAllowedStartDate = new DateTime(2016, 08, 01);
        private readonly DateTime _validationStartDateTime;

        public ValidationDataService(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;

            _validationStartDateTime = _dateTimeProvider != null ? _dateTimeProvider.UtcNow : DateTime.UtcNow;
        }

        public DateTime AcademicYearEnd { get { return _academicYearEnd; } }
        
        public DateTime AcademicYearJanuaryFirst {  get { return _academicYearJanuaryFirst; } }

        public DateTime AcademicYearStart { get { return _academicYearStart; } }

        public IEnumerable<long> ApprenticeProgTypes { get { return _apprenticeshipProgTypes; } }

        public DateTime ApprencticeProgAllowedStartDate { get { return _apprenticeshipProgAllowedStartDate; } }

        public DateTime ValidationStartDateTime { get { return _validationStartDateTime; } }
    }
}
