using ESFA.DC.ILR.Model.Tests.Abstract;
using Xunit;

namespace ESFA.DC.ILR.Model.Tests
{
    public class MessageLearnerDestinationandProgressionDPOutcomeTests : AbstractModelTests<MessageLearnerDestinationandProgressionDPOutcome>
    {
        [Fact]
        public void OutCodeNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.OutCode, Long(), l => l.OutCodeSpecified, l => l.OutCodeNullable);
        }

        [Fact]
        public void OutCodeNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.OutCode, Long(), l => l.OutCodeSpecified, l => l.OutCodeNullable);
        }

        [Fact]
        public void OutStartDateNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.OutStartDate, DateTime(), l => l.OutStartDateSpecified, l => l.OutStartDateNullable);
        }

        [Fact]
        public void OutStartDateNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.OutStartDate, DateTime(), l => l.OutStartDateSpecified, l => l.OutStartDateNullable);
        }

        [Fact]
        public void OutStartEndNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.OutEndDate, DateTime(), l => l.OutEndDateSpecified, l => l.OutEndDateNullable);
        }

        [Fact]
        public void OutEndateNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.OutEndDate, DateTime(), l => l.OutEndDateSpecified, l => l.OutEndDateNullable);
        }

        [Fact]
        public void OutCollEndNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.OutCollDate, DateTime(), l => l.OutCollDateSpecified, l => l.OutCollDateNullable);
        }

        [Fact]
        public void OutCollDateNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.OutCollDate, DateTime(), l => l.OutCollDateSpecified, l => l.OutCollDateNullable);
        }
    }
}
