using System;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Tests.Model
{
    public class AppFinRecord : IAppFinRecord
    {
        public string AFinType { get; set; }

        public long? AFinCodeNullable { get; set; }

        public DateTime? AFinDateNullable { get; set; }

        public long? AFinAmountNullable { get; set; }
    }
}
