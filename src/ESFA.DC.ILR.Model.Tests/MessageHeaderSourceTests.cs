using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.Model.Tests
{
    public class MessageHeaderSourceTests
    {
        [Fact]
        public void ProtectiveMarkingString()
        {
            var headerSource = new MessageHeaderSource()
            {
                ProtectiveMarking = MessageHeaderSourceProtectiveMarking.OFFICIALSENSITIVEPersonal
            };

            headerSource.ProtectiveMarkingString.Should().Be("OFFICIAL-SENSITIVE-Personal");
        }
    }
}
