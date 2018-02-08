using ESFA.DC.ILR.Model.Interface;
using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR.ValidationService.Rules.Derived.Interface
{
    public interface IDD04
    {
        DateTime? Derive(IEnumerable<ILearningDelivery> learningDeliveries, ILearningDelivery learningDelivery);
    }
}
