using System.Collections.Generic;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Model
{
    public partial class MessageLearnerLearnerHE : IMessageLearnerLearnerHE
    {
        public long? TTACCOMNullable
        {
            get { return tTACCOMFieldSpecified ? (long?)tTACCOMField : null; }
        }

        public IReadOnlyCollection<IMessageLearnerLearnerHELearnerHEFinancialSupport> LearnerHEFinancialSupports
        {
            get { return learnerHEFinancialSupportField; }
        }
    }
}
