using FluentAssertions;
using System;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Service.Tests.DateTimeProvider
{
    public class DateTimeProviderTests
    {
        [Fact]
        public void UtcNow()
        {
            var dateTimeProvider = new Service.DateTimeProvider.DateTimeProvider();

            dateTimeProvider.UtcNow.Should().BeCloseTo(DateTime.UtcNow, 50);
        }
        
    }
}
