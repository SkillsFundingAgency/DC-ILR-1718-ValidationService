using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR.Model.Interface
{
    public interface IMessageLearner
    {
        DateTime? DateOfBirthNullable { get; }

        string LearnRefNumber { get; }

        long? ULNNullable { get; }
        
        IReadOnlyCollection<IMessageLearnerLearningDelivery> LearningDeliveries { get; }
    }
}
