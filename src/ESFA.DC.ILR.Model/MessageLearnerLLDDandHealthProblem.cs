using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Model
{
    public partial class MessageLearnerLLDDandHealthProblem : ILLDDAndHealthProblem
    {
        public long? LLDDCatNullable
        {
            get { return lLDDCatFieldSpecified ? (long?)lLDDCatField : null; }
        }

        public long? PrimaryLLDDNullable
        {
            get { return primaryLLDDFieldSpecified ? (long?)primaryLLDDField : null; }
        }
    }
}
