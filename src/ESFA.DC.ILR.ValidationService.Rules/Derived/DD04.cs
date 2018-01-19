using System;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Rules.Derived.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Extensions;

namespace ESFA.DC.ILR.ValidationService.Rules.Derived
{
    public class DD04 : IDD04
    {
        public DateTime? Derive(MessageLearner learner, MessageLearnerLearningDelivery learningDelivery)
        {
            return learner.EarliestLearningDeliveryLearnStartDateFor(1, learningDelivery.ProgType, learningDelivery.FworkCode, learningDelivery.PwayCode);
        }
    }
}
