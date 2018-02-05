using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Model
{
    public partial class MessageLearnerLearnerFAM : ILearnerFAM
    {
        public long? LearnFAMCodeNullable
        {
            get { return learnFAMCodeFieldSpecified ? (long?)learnFAMCodeField : null; }
        }
    }
}
