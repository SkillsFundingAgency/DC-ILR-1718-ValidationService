using System;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Rules.Derived.Interface;
using System.Linq;
using System.Collections.Generic;

namespace ESFA.DC.ILR.ValidationService.Rules.Derived
{
    public class DD04 : IDD04
    {
        public DateTime? Derive(IEnumerable<MessageLearnerLearningDelivery> learningDeliveries, MessageLearnerLearningDelivery learningDelivery)
        {
            return EarliestLearningDeliveryLearnStartDateFor(learningDeliveries, 1, learningDelivery.ProgType, learningDelivery.FworkCode, learningDelivery.PwayCode);
        }

        public DateTime? EarliestLearningDeliveryLearnStartDateFor(IEnumerable<MessageLearnerLearningDelivery> learningDeliveries, long aimType, long progType, long fworkCode, long pwayCode)
        {
            return learningDeliveries?
                .OrderBy(ld => ld.LearnStartDate)
                .FirstOrDefault(ld => ld.AimType == aimType && ld.ProgType == progType && ld.FworkCode == fworkCode && ld.PwayCode == pwayCode)?
                .LearnStartDate;
        }
    }
}
