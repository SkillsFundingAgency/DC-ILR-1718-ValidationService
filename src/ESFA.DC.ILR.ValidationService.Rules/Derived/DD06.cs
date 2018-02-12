﻿using System;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Rules.Derived.Interface;
using System.Linq;
using System.Collections.Generic;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.ValidationService.Rules.Derived
{
    public class DD06 : IDD06
    {
        public DateTime? Derive(IEnumerable<ILearningDelivery> learningDeliveries)
        {
            return learningDeliveries?
                    .Where(ld => ld.LearnStartDateNullable.HasValue)
                    .OrderBy(ld => ld.LearnStartDateNullable)
                    .FirstOrDefault()
                    .LearnStartDateNullable;
        }

        
    }
}