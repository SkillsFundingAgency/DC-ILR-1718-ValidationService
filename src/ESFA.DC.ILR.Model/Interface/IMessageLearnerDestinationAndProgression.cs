using System.Collections.Generic;

namespace ESFA.DC.ILR.Model.Interface
{
    public interface IMessageLearnerDestinationAndProgression
    {
        string LearnRefNumber { get; }
        long? ULNNullable { get; }
        IReadOnlyCollection<IMessageLearnerDestinationandProgressionDPOutcome> DPOutcomes { get; }
    }
}
