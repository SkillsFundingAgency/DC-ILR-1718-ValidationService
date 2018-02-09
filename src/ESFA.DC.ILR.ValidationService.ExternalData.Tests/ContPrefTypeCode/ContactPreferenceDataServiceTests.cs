using ESFA.DC.ILR.ValidationService.ExternalData.ContPrefType;
using ESFA.DC.ILR.ValidationService.ExternalData.ContPrefType.Interface;
using FluentAssertions;
using Moq;
using System;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.ExternalData.Tests.ContPrefTypeCode
{
    public class ContactPreferenceDataServiceTests
    {
        [Theory]
        [InlineData("PMC")]
        [InlineData("RUI")]
        public void TypeExists_True(string contactPreferrenceType)
        {
            var priorAttainReferenceDataService = new ContactPreferenceDataService();

            priorAttainReferenceDataService.TypeExists(contactPreferrenceType).Should().BeTrue();
        }

        [Theory]
        [InlineData("FFFF")]
        [InlineData("XYZ")]
        [InlineData(null)]
        [InlineData("")]
        public void TypeExists_False(string contactPreferrenceType)
        {
            var priorAttainReferenceDataService = new ContactPreferenceDataService();

            priorAttainReferenceDataService.TypeExists(contactPreferrenceType).Should().BeFalse();
        }

        [Theory]
        [InlineData("PMC", 1)]
        [InlineData("PMC", 2)]
        [InlineData("PMC", 3)]
        [InlineData("RUI", 1)]
        [InlineData("RUI", 2)]
        [InlineData("RUI", 3)]
        [InlineData("RUI", 4)]
        [InlineData("RUI", 5)]
        public void TypeForCodeExists_True(string contactPreferrenceType, long? code)
        {
            var priorAttainReferenceDataService = new ContactPreferenceDataService();

            priorAttainReferenceDataService.TypeForCodeExist(contactPreferrenceType, code, new DateTime(2010, 10, 10)).Should().BeTrue();
        }

        [Theory]
        [InlineData("PMC", 10)]
        [InlineData("RUI", 50)]
        public void TypeForCodeExists_False(string contactPreferrenceType, long? code)
        {
            var priorAttainReferenceDataService = new ContactPreferenceDataService();

            priorAttainReferenceDataService.TypeForCodeExist(contactPreferrenceType, code, new DateTime(2010, 10, 10)).Should().BeFalse();
        }

        [Theory]
        [InlineData("PMC", 1, "2099-12-31")]
        [InlineData("PMC", 2, "2099-12-31")]
        [InlineData("PMC", 3, "2099-12-31")]
        [InlineData("RUI", 1, "2099-12-31")]
        [InlineData("RUI", 2, "2099-12-31")]
        [InlineData("RUI", 3, "2013-07-31")]
        [InlineData("RUI", 4, "2099-12-31")]
        [InlineData("RUI", 5, "2099-12-31")]
        public void TypeForCodeExists_DateTime_True(string contactPreferrenceType, long? code, string datetime)
        {
            var priorAttainReferenceDataService = new ContactPreferenceDataService();
            var validToDate = DateTime.ParseExact(datetime, "yyyy-MM-dd", null);

            priorAttainReferenceDataService.TypeForCodeExist(contactPreferrenceType,  code , validToDate).Should().BeTrue();
        }

        [Theory]
        [InlineData("PMC", 1, "2100-01-01")]
        [InlineData("PMC", 2, "2100-01-01")]
        [InlineData("PMC", 3, "2100-01-01")]
        [InlineData("RUI", 1, "2100-01-01")]
        [InlineData("RUI", 2, "2100-01-01")]
        [InlineData("RUI", 3, "2013-08-01")]
        [InlineData("RUI", 4, "2100-01-01")]
        [InlineData("RUI", 5, "2100-01-01")]
        public void TypeForCodeExists_DateTime_False(string contactPreferrenceType, long? code, string datetime)
        {
            var priorAttainReferenceDataService = new ContactPreferenceDataService();
            var validToDate = DateTime.ParseExact(datetime, "yyyy-MM-dd", null);

            priorAttainReferenceDataService.TypeForCodeExist(contactPreferrenceType, code , validToDate).Should().BeFalse();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void CodeExists_True(long? code)
        {
            var priorAttainReferenceDataService = new ContactPreferenceDataService();

            priorAttainReferenceDataService.CodeExists(code).Should().BeTrue();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(6)]
        [InlineData(null)]
        public void CodeExists_False(long? code)
        {
            var priorAttainReferenceDataService = new ContactPreferenceDataService();

            priorAttainReferenceDataService.CodeExists(code).Should().BeFalse();
        }

        [Theory]
        [InlineData("PMC")]
        [InlineData("RUI")]
        public void TypeExists_True_Mock(string contactPreferrenceType)
        {
            var priorAttainReferenceDataService = new Mock<IContactPreferenceDataService>();
            priorAttainReferenceDataService.Setup(x => x.TypeExists(contactPreferrenceType)).Returns(true);

            priorAttainReferenceDataService.Object.TypeExists(contactPreferrenceType).Should().BeTrue();
        }

        [Theory]
        [InlineData("FFFF")]
        [InlineData("XYZ")]
        public void TypeExists_False_Mock(string contactPreferrenceType)
        {
            var priorAttainReferenceDataService = new Mock<IContactPreferenceDataService>();
            priorAttainReferenceDataService.Setup(x => x.TypeExists(contactPreferrenceType)).Returns(false);

            priorAttainReferenceDataService.Object.TypeExists(contactPreferrenceType).Should().BeFalse();
        }

        [Theory]
        [InlineData("PMC", 1, "2099-12-31")]
        [InlineData("RUI", 1, "2099-12-31")]
        [InlineData("RUI", 3, "2013-07-31")]
        public void TypeForCodeExists_DateTime_True_Mock(string contactPreferrenceType, long? code, string datetime)
        {
            var validToDate = DateTime.ParseExact(datetime, "yyyy-MM-dd", null);
            var priorAttainReferenceDataService = new Mock<IContactPreferenceDataService>();
            priorAttainReferenceDataService.Setup(x => x.TypeForCodeExist(contactPreferrenceType,code , validToDate)).Returns(true);

            priorAttainReferenceDataService.Object.TypeForCodeExist(contactPreferrenceType, code , validToDate).Should().BeTrue();
        }

        [Theory]
        [InlineData("PMC", 1, "2100-01-01")]
        [InlineData("RUI", 1, "2100-01-01")]
        [InlineData("RUI", 3, "2013-08-01")]
        public void TypeForCodeExists_DateTime_False_Mock(string contactPreferrenceType, long? code, string datetime)
        {
            var validToDate = DateTime.ParseExact(datetime, "yyyy-MM-dd", null);
            var priorAttainReferenceDataService = new Mock<IContactPreferenceDataService>();
            priorAttainReferenceDataService.Setup(x => x.TypeForCodeExist(contactPreferrenceType, code , validToDate)).Returns(false);

            priorAttainReferenceDataService.Object.TypeForCodeExist(contactPreferrenceType, code , validToDate).Should().BeFalse();
        }
    }
}