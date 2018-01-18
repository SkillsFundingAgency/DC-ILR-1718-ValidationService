﻿using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR.ValidationService.Interface
{
    public interface IValidationDataService
    {
        DateTime AcademicYearEnd { get; }
        DateTime AcademicYearJanuaryFirst { get; }
        DateTime AcademicYearStart { get; }
        IEnumerable<long> ApprenticeProgTypes { get; }
        DateTime ApprencticeProgAllowedStartDate { get; }
        DateTime ValidationStartDateTime { get; }
    }
}