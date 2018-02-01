using ESFA.DC.ILR.Model.Tests.Abstract;
using Xunit;

namespace ESFA.DC.ILR.Model.Tests
{
    public class MessageLearnerLLDDandHealthProblemTests : AbstractModelTests<MessageLearnerLLDDandHealthProblem>
    {
        [Fact]
        public void LLDDCatNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.LLDDCat, Long(), l => l.LLDDCatSpecified, l => l.LLDDCatNullable);
        }

        [Fact]
        public void LLDDCatNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.LLDDCat, Long(), l => l.LLDDCatSpecified, l => l.LLDDCatNullable);
        }

        [Fact]
        public void PrimaryLLDDNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.LLDDCat, Long(), l => l.LLDDCatSpecified, l => l.LLDDCatNullable);
        }

        [Fact]
        public void PrimaryLLDDNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.PrimaryLLDD, Long(), l => l.PrimaryLLDDSpecified, l => l.PrimaryLLDDNullable);
        }
    }
}
