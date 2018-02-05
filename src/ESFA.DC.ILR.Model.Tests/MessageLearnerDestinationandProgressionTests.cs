using ESFA.DC.ILR.Model.Tests.Abstract;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.Model.Tests
{
    public class MessageLearnerDestinationandProgressionTests : AbstractModelTests<MessageLearnerDestinationandProgression>
    {
        [Fact]
        public void ULNNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.ULN, Long(), l => l.ULNSpecified, l => l.ULNNullable);
        }

        [Fact]
        public void ESMCodeNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.ULN, Long(), l => l.ULNSpecified, l => l.ULNNullable);
        }

        [Fact]
        public void DPOutcomes()
        {
            var learnerDestinationAndProgression = new MessageLearnerDestinationandProgression()
            {
                DPOutcome = new MessageLearnerDestinationandProgressionDPOutcome[]
                {
                    new MessageLearnerDestinationandProgressionDPOutcome()
                }
            };

            learnerDestinationAndProgression.DPOutcomes.Should().BeSameAs(learnerDestinationAndProgression.DPOutcome);
            learnerDestinationAndProgression.DPOutcomes.Should().HaveCount(1);
        }
    }
}
