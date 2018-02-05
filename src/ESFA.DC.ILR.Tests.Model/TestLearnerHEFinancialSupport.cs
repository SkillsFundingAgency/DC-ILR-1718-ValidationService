using ESFA.DC.ILR.Model.Interface;
using System;

namespace ESFA.DC.ILR.Tests.Model
{
    public class TestLearnerHEFinancialSupport : ILearnerHEFinancialSupport
    {
        public long? FINTYPENullable { get; set; }

        public long? FINAMOUNTNullable { get; set; }
    }
}
