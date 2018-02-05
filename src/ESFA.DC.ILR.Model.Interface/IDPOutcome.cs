using System;

namespace ESFA.DC.ILR.Model.Interface
{
    public interface IDPOutcome
    {
        string OutType { get; }
        long? OutCodeNullable { get; }
        DateTime? OutStartDateNullable { get; }
        DateTime? OutEndDateNullable { get; }
        DateTime? OutCollDateNullable { get; }
    }
}