using ESFA.DC.ILR.Model.Tests.Abstract;
using Xunit;

namespace ESFA.DC.ILR.Model.Tests
{
    public class MessageLearnerLearningDeliveryAppFinRecordTests : AbstractModelTests<MessageLearnerLearningDeliveryAppFinRecord>
    {
        [Fact]
        public void AFinCodeNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.AFinCode, Long(), l => l.AFinCodeSpecified, l => l.AFinCodeNullable);
        }

        [Fact]
        public void AFinCodeNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.AFinCode, Long(), l => l.AFinCodeSpecified, l => l.AFinCodeNullable);
        }

       [Fact]
        public void AFinDateNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.AFinDate, DateTime(), l => l.AFinDateSpecified, l => l.AFinDateNullable);
        }

        [Fact]
        public void AFinDateNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.AFinDate, DateTime(), l => l.AFinDateSpecified, l => l.AFinDateNullable);
        }

        [Fact]
        public void AFinAmountNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.AFinAmount, Long(), l => l.AFinAmountSpecified, l => l.AFinAmountNullable);
        }

        [Fact]
        public void AFinAmountNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.AFinAmount, Long(), l => l.AFinAmountSpecified, l => l.AFinAmountNullable);
        }
    }
}
