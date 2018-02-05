using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Model
{
    public partial class MessageLearnerContactPreference : IContactPreference
    {
        public long? ContPrefCodeNullable
        {
            get { return contPrefCodeFieldSpecified ? (long?)contPrefCodeField : null; }
        }
    }
}
