using System.Collections.Generic;

namespace ESFA.DC.ILR.Model.Interface
{
    public interface ILearnerHE
    {
        string UCASPERID { get; }
        long? TTACCOMNullable { get; }
        IReadOnlyCollection<ILearnerHEFinancialSupport> LearnerHEFinancialSupports { get; }
    }
}
