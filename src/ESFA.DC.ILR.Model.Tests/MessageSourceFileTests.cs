using ESFA.DC.ILR.Model.Tests.Abstract;
using Xunit;

namespace ESFA.DC.ILR.Model.Tests
{
    public class MessageSourceFileTests : AbstractModelTests<MessageSourceFile>
    {
        [Fact]
        public void DateTimeNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.DateTime, DateTime(), l => l.DateTimeSpecified, l => l.DateTimeNullable);
        }

        [Fact]
        public void DateTimeNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.DateTime, DateTime(), l => l.DateTimeSpecified, l => l.DateTimeNullable);
        }
    }
}
