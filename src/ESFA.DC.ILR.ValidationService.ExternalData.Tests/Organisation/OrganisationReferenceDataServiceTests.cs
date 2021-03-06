﻿using ESFA.DC.ILR.ValidationService.ExternalData.Interface;
using ESFA.DC.ILR.ValidationService.ExternalData.Organisation;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.ExternalData.Tests.Organisation
{
    public class OrganisationReferenceDataServiceTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void UkprnExists_True(long ukprn)
        {
            var referenceDataCacheMock = new Mock<IReferenceDataCache>();

            referenceDataCacheMock.SetupGet(rdc => rdc.UKPRNs).Returns(new HashSet<long>() { 1, 2, 3, 4, 5, 6, 7 });

            var orgnanisationReferenceDataService = new OrganisationReferenceDataService(referenceDataCacheMock.Object);

            orgnanisationReferenceDataService.UkprnExists(ukprn).Should().BeTrue();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(8)]
        public void UkprnExists_False(long ukprn)
        {
            var referenceDataCacheMock = new Mock<IReferenceDataCache>();

            referenceDataCacheMock.SetupGet(rdc => rdc.UKPRNs).Returns(new HashSet<long>() { 1, 2, 3, 4, 5, 6, 7 });

            var orgnanisationReferenceDataService = new OrganisationReferenceDataService(referenceDataCacheMock.Object);

            orgnanisationReferenceDataService.UkprnExists(ukprn).Should().BeFalse();
        }
    }
}
