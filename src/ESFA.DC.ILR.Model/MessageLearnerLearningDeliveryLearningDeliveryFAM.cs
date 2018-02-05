using System;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Model
{
    public partial class MessageLearnerLearningDeliveryLearningDeliveryFAM : ILearningDeliveryFAM
    {
        public DateTime? LearnDelFAMDateFromNullable
        {
            get { return learnDelFAMDateFromFieldSpecified ? (DateTime?)learnDelFAMDateFromField : null; }
        }

        public DateTime? LearnDelFAMDateToNullable
        {
            get { return learnDelFAMDateToFieldSpecified ? (DateTime?)learnDelFAMDateToField : null; }
        }
    }
}
