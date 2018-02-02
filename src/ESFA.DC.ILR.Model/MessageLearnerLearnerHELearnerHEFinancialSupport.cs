using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Model
{
    public partial class MessageLearnerLearnerHELearnerHEFinancialSupport : IMessageLearnerLearnerHELearnerHEFinancialSupport
    {
        public long? FINTYPENullable
        {
            get { return fINTYPEFieldSpecified ? (long?)fINTYPEField : null; }
        }

        public long? FINAMOUNTNullable
        {
            get { return fINAMOUNTFieldSpecified ? (long?)fINAMOUNTField : null; }
        }
    }
}
