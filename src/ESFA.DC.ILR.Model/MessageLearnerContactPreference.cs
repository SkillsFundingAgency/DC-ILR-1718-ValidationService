using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Model
{
    public partial class MessageLearnerContactPreference : IMessageLearnerContactPreference
    {
        public long? ContPrefCodeNullable
        {
            get { return contPrefCodeFieldSpecified ? (long?)contPrefCodeField : null; }
        }
    }
}
