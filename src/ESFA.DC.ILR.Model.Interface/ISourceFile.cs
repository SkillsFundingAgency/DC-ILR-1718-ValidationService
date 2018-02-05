using System;

namespace ESFA.DC.ILR.Model.Interface
{
    public interface ISourceFile
    {
        string SourceFileName { get; }
        DateTime FilePreparationDate { get; }
        string SoftwareSupplier { get; }
        string SoftwarePackage { get; }
        string Release { get; }
        string SerialNo { get; }
        DateTime? DateTimeNullable { get; }
    }
}
