using ESFA.DC.ILR.Model.Tests.Abstract;
using Xunit;

namespace ESFA.DC.ILR.Model.Tests
{
    public class MessageLearnerLearnerHELearnerHEFinancialSupportTests : AbstractModelTests<MessageLearnerLearnerHELearnerHEFinancialSupport>
    {
        [Fact]
        public void FINTYPENullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.FINTYPE, Long(), l => l.FINTYPESpecified, l => l.FINTYPENullable);
        }

        [Fact]
        public void FINTYPENullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.FINTYPE, Long(), l => l.FINTYPESpecified, l => l.FINTYPENullable);
        }

        [Fact]
        public void FINAMOUNTNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.FINAMOUNT, Long(), l => l.FINAMOUNTSpecified, l => l.FINAMOUNTNullable);
        }

        [Fact]
        public void FINAMOUNTNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.FINAMOUNT, Long(), l => l.FINAMOUNTSpecified, l => l.FINAMOUNTNullable);
        }
    }
}
