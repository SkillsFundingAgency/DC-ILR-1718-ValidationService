using System;

namespace ESFA.DC.ILR.Model.Interface
{
    public interface ILearningDeliveryFAM
    {
        string LearnDelFAMType { get; }
        string LearnDelFAMCode { get; }
        DateTime? LearnDelFAMDateFromNullable { get; }
        DateTime? LearnDelFAMDateToNullable { get; }
    }
}
