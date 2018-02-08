using System.Collections.Generic;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Model
{
    public partial class MessageLearnerDestinationandProgression : ILearnerDestinationAndProgression
    {
        public long? ULNNullable
        {
            get { return uLNFieldSpecified ? (long?)uLNField : null; }
        }


        public IReadOnlyCollection<IDPOutcome> DPOutcomes
        {
            get { return dPOutcomeField; }
        }
    }
}
