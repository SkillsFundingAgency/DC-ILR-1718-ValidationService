using System;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Rules.Derived.Interface;
using System.Linq;
using System.Collections.Generic;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.ValidationService.Rules.Derived
{
    public class DD04 : IDD04
    {
        public DateTime? Derive(IEnumerable<IMessageLearnerLearningDelivery> learningDeliveries, IMessageLearnerLearningDelivery learningDelivery)
        {
            return EarliestLearningDeliveryLearnStartDateFor(learningDeliveries, 1, learningDelivery.ProgTypeNullable, learningDelivery.FworkCodeNullable, learningDelivery.PwayCodeNullable);
        }

        public DateTime? EarliestLearningDeliveryLearnStartDateFor(IEnumerable<IMessageLearnerLearningDelivery> learningDeliveries, long? aimType, long? progType, long? fworkCode, long? pwayCode)
        {
            return learningDeliveries?
                .Where(ld => ld.LearnStartDateNullable.HasValue)
                .OrderBy(ld => ld.LearnStartDateNullable)
                .FirstOrDefault(
                    ld => 
                    ld.AimTypeNullable == aimType 
                    && ld.ProgTypeNullable == progType 
                    && ld.FworkCodeNullable == fworkCode 
                    && ld.PwayCodeNullable == pwayCode)?
                .LearnStartDateNullable;
        }
    }
}
