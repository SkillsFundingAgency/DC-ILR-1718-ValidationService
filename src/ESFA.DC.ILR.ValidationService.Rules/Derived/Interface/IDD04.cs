using ESFA.DC.ILR.Model;
using System;

namespace ESFA.DC.ILR.ValidationService.Rules.Derived.Interface
{
    public interface IDD04
    {
        DateTime? Derive(MessageLearner learner, MessageLearnerLearningDelivery learningDelivery);
    }
}
