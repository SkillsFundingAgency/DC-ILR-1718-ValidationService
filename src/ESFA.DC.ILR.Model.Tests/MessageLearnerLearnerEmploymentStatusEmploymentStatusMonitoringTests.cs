using ESFA.DC.ILR.Model.Tests.Abstract;
using Xunit;

namespace ESFA.DC.ILR.Model.Tests
{
    public class MessageLearnerLearnerEmploymentStatusEmploymentStatusMonitoringTests : AbstractModelTests<MessageLearnerLearnerEmploymentStatusEmploymentStatusMonitoring>
    {
        [Fact]
        public void ESMCodeNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.ESMCode, Long(), l => l.ESMCodeSpecified, l => l.ESMCodeNullable);
        }

        [Fact]
        public void ESMCodeNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.ESMCode, Long(), l => l.ESMCodeSpecified, l => l.ESMCodeNullable);
        }
    }
}
