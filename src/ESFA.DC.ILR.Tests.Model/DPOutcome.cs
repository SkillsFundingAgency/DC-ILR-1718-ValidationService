using System;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Tests.Model
{
    public class DPOutcome : IDPOutcome
    {
        public string OutType { get; set; }

        public long? OutCodeNullable { get; set; }

        public DateTime? OutStartDateNullable { get; set; }

        public DateTime? OutEndDateNullable { get; set; }

        public DateTime? OutCollDateNullable { get; set; }
    }
}
