using System;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Tests.Model
{
    public class TestSourceFile : ISourceFile
    {
        public string SourceFileName { get; set; }

        public DateTime FilePreparationDate { get; set; }

        public string SoftwareSupplier { get; set; }

        public string SoftwarePackage { get; set; }

        public string Release { get; set; }

        public string SerialNo { get; set; }

        public DateTime? DateTimeNullable { get; set; }
    }
}
