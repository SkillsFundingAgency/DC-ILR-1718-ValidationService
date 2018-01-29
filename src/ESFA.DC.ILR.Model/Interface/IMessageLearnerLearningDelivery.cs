using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR.Model.Interface
{
    public interface IMessageLearnerLearningDelivery
    {
        long? AimSeqNumberNullable { get; }
        long? AimTypeNullable { get; }
        long? FundModelNullable { get; }
        long? FworkCodeNullable { get; }
        DateTime? LearnStartDateNullable { get; }
        long? ProgTypeNullable { get; }
        long? PwayCodeNullable { get; }
        IReadOnlyCollection<IMessageLearnerLearningDeliveryLearningDeliveryFAM> LearningDeliveryFAMs { get; }
    }
}
