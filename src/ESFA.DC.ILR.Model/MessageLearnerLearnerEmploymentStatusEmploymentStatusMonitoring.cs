using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Model
{
    public partial class MessageLearnerLearnerEmploymentStatusEmploymentStatusMonitoring : IMessageLearnerLearnerEmploymentStatusEmploymentStatusMonitoring
    {
        public long? ESMCodeNullable
        {
            get { return eSMCodeFieldSpecified ? (long?)eSMCodeField : null; }
        }
    }
}
