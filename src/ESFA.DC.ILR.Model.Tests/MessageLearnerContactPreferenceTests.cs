using ESFA.DC.ILR.Model.Tests.Abstract;
using Xunit;

namespace ESFA.DC.ILR.Model.Tests
{
    public class MessageLearnerContactPreferenceTests : AbstractModelTests<MessageLearnerContactPreference>
    {
        [Fact]
        public void ContPrefCodeNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.ContPrefCode, Long(), l => l.ContPrefCodeSpecified, l => l.ContPrefCodeNullable);
        }

        [Fact]
        public void ContPrefCodeNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.ContPrefCode, Long(), l => l.ContPrefCodeSpecified, l => l.ContPrefCodeNullable);
        }
    }
}
