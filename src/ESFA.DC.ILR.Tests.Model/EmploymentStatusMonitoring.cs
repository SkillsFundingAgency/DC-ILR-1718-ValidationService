using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Tests.Model
{
    public class EmploymentStatusMonitoring : IEmploymentStatusMonitoring
    {
        public string ESMType { get; set; }

        public long? ESMCodeNullable { get; set; }
    }
}
