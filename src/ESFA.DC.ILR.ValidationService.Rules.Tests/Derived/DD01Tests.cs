using ESFA.DC.ILR.ValidationService.Rules.Derived;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Derived
{
    public class DD01Tests
    {
        [Fact]
        public void CalculateChecksum()
        {
            var dd = new DD01();

            dd.CalculateCheckSum(1000000043).Should().Be(7);
        }

        [Fact]
        public void Derive_UlnNotTenCharacters()
        {
            var dd = new DD01();

            dd.Derive(100000004).Should().Be("N");
        }

        [Fact]
        public void Derive_RemainderZero()
        {
            var dd = new DD01();

            dd.Derive(1000000063).Should().Be("N");
        }

        [Fact]
        public void Derive_Correct()
        {
            var dd = new DD01();

            dd.Derive(1000000043).Should().Be("3");
        }
    }
}
