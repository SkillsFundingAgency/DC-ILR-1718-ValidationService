using ESFA.DC.ILR.Model.Tests.Abstract;
using Xunit;

namespace ESFA.DC.ILR.Model.Tests
{
    public class MessageLearnerLearnerFAMTests : AbstractModelTests<MessageLearnerLearnerFAM>
    {
        [Fact]
        public void LearnFAMCodeNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.LearnFAMCode, Long(), l => l.LearnFAMCodeSpecified, l => l.LearnFAMCodeNullable);
        }

        [Fact]
        public void LearnFAMCodeNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.LearnFAMCode, Long(), l => l.LearnFAMCodeSpecified, l => l.LearnFAMCodeNullable);
        }
    }
}
