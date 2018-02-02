using System;

namespace ESFA.DC.ILR.Model.Interface
{
    public interface IMessageLearnerDestinationAndProgressionDPOutcome
    {
        string OutType { get; }
        long? OutCodeNullable { get; }
        DateTime? OutStartDateNullable { get; }
        DateTime? OutEndDateNullable { get; }
        DateTime? OutCollDateNullable { get; }
    }
}