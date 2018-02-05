using System.Collections.Generic;

namespace ESFA.DC.ILR.Model.Interface
{
    public interface IMessageLearnerLearnerHE
    {
        string UCASPERID { get; }
        long? TTACCOMNullable { get; }
        IReadOnlyCollection<IMessageLearnerLearnerHELearnerHEFinancialSupport> LearnerHEFinancialSupports { get; }
    }
}
