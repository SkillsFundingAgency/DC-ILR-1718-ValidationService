using System;

namespace ESFA.DC.ILR.Model.Interface
{
    public interface ISource
    {
        string ProtectiveMarkingString { get; }
        int UKPRN { get; }
        string SoftwareSupplier { get; }
        string SoftwarePackage { get; }
        string Release { get; }
        string SerialNo { get; }
        DateTime DateTime { get; }
        string ReferenceData { get; }
        string ComponentSetVersion { get; }
    }
}
