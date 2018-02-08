using System;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Tests.Model
{
    public class TestLearningDeliveryFAM : ILearningDeliveryFAM
    {
        public string LearnDelFAMType { get; set; }

        public string LearnDelFAMCode { get; set; }

        public DateTime? LearnDelFAMDateFromNullable { get; set; }

        public DateTime? LearnDelFAMDateToNullable { get; set; }
    }
}
