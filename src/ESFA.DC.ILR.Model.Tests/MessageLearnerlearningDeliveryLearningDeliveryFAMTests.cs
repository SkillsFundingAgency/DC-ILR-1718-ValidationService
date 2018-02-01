using ESFA.DC.ILR.Model.Tests.Abstract;
using Xunit;

namespace ESFA.DC.ILR.Model.Tests
{
    public class MessageLearnerLearningDeliveryLearningDeliveryFAMTests : AbstractModelTests<MessageLearnerLearningDeliveryLearningDeliveryFAM>
    {
        [Fact]
        public void LearnDelFAMDateFromNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.LearnDelFAMDateFrom, DateTime(), l => l.LearnDelFAMDateFromSpecified, l => l.LearnDelFAMDateFromNullable);
        }

        [Fact]
        public void LearnDelFAMDateFromNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.LearnDelFAMDateFrom, DateTime(), l => l.LearnDelFAMDateFromSpecified, l => l.LearnDelFAMDateFromNullable);
        }
        
        [Fact]
        public void LearnDelFAMDateToNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.LearnDelFAMDateTo, DateTime(), l => l.LearnDelFAMDateToSpecified, l => l.LearnDelFAMDateToNullable);
        }

        [Fact]
        public void LearnDelFAMDateToNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.LearnDelFAMDateTo, DateTime(), l => l.LearnDelFAMDateToSpecified, l => l.LearnDelFAMDateToNullable);
        }        
    }
}
