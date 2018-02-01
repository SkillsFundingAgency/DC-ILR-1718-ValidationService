using ESFA.DC.ILR.Model.Tests.Abstract;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.Model.Tests
{
    public class MessageLearnerLearnerHETests : AbstractModelTests<MessageLearnerLearnerHE>
    {
        [Fact]
        public void TTACCOMNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.TTACCOM, Long(), l => l.TTACCOMSpecified, l => l.TTACCOMNullable);
        }

        [Fact]
        public void TTACCOMNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.TTACCOM, Long(), l => l.TTACCOMSpecified, l => l.TTACCOMNullable);
        }
        
        [Fact]
        public void LearnerHEFinancialSupports()
        {
            var learnerHE = new MessageLearnerLearnerHE()
            {
                LearnerHEFinancialSupport = new MessageLearnerLearnerHELearnerHEFinancialSupport[]
                {
                    new MessageLearnerLearnerHELearnerHEFinancialSupport()
                }
            };

            learnerHE.LearnerHEFinancialSupports.Should().BeSameAs(learnerHE.LearnerHEFinancialSupport);
            learnerHE.LearnerHEFinancialSupports.Should().HaveCount(1);
        }        
    }
}
