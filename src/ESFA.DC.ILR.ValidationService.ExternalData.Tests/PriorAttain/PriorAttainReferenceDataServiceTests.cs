using ESFA.DC.ILR.ValidationService.ExternalData.PriorAttain;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.ExternalData.Tests.PriorAttain
{
    public class PriorAttainReferenceDataServiceTests
    {
        [Theory]
        [InlineData(new long[] { 2, 3, 4, 5, 10, 11, 12, 13, 97, 98 })]
        public void Exists_True(long[] attainValues)
        {
            var priorAttainReferenceDataService = new PriorAttainReferenceDataService();

            foreach (var value in attainValues)
            {
                priorAttainReferenceDataService.Exists(value).Should().BeTrue();
            }
        }

        [Theory]
        [InlineData(new long[] { 22, 90, 100 })]
        public void Exists_False(long[] attainValues)
        {
            var priorAttainReferenceDataService = new PriorAttainReferenceDataService();

            foreach (var value in attainValues)
            {
                priorAttainReferenceDataService.Exists(value).Should().BeFalse();
            }
        }
    }
}
