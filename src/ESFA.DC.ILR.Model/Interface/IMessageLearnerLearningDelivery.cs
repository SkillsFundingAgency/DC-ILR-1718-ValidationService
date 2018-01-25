using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR.Model.Interface
{
    public interface IMessageLearnerLearningDelivery
    {
        long? AimSeqNumberNullable { get; }

        long? FundModelNullable { get; }

        DateTime? LearnStartDateNullable { get; }

        IReadOnlyCollection<IMessageLearnerLearningDeliveryLearningDeliveryFAM> LearningDeliveryFAMs { get; }
    }
}
