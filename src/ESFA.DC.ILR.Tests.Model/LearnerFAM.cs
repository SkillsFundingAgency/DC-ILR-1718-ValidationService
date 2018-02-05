using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Tests.Model
{
    public class LearnerFAM : ILearnerFAM
    {
        public string LearnFAMType { get; set; }

        public long? LearnFAMCodeNullable { get; set; }
    }
}
