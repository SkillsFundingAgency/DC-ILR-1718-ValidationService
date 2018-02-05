using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Learner.DateOfBirth;
using ESFA.DC.ILR.ValidationService.Rules.Query.Interface;
using FluentAssertions;
using Moq;
using System;
using System.Linq.Expressions;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Learner.DateOfBirth
{
    public class DateOfBirth_20RuleTests
    {
        private DateOfBirth_20Rule NewRule(IValidationDataService validationDataService = null, IDateTimeQueryService dateTimeQueryService = null, ILearningDeliveryFAMQueryService messageLearnerLearningDeliveryLearningDeliveryFAMQueryService = null, IValidationErrorHandler validationErrorHandler = null)
        {
            return new DateOfBirth_20Rule(validationDataService, dateTimeQueryService, messageLearnerLearningDeliveryLearningDeliveryFAMQueryService, validationErrorHandler);
        }

        [Fact]
        public void Exclude_True()
        {
            var rule = NewRule();

            rule.Exclude(24).Should().BeTrue();
        }

        [Theory]
        [InlineData(23)]
        [InlineData(25)]
        [InlineData(null)]
        public void Exclude_False(long? progType)
        {
            var rule = NewRule();

            rule.Exclude(progType).Should().BeFalse();
        }

        [Theory]
        [InlineData(25)]
        [InlineData(82)]
        public void ConditionMet_True(long? fundModel)
        {
            var dateOfBirth = new DateTime(1990, 1, 1);
            var academicYearAugustThirtyFirst = new DateTime(2017, 8, 31);
            
            var dateTimeQueryServiceMock = new Mock<IDateTimeQueryService>();
            
            dateTimeQueryServiceMock.Setup(qs => qs.YearsBetween(dateOfBirth, academicYearAugustThirtyFirst)).Returns(18);

            var rule = NewRule(dateTimeQueryService: dateTimeQueryServiceMock.Object);

            rule.ConditionMet(fundModel, dateOfBirth, academicYearAugustThirtyFirst, false).Should().BeTrue();
        }

        [Fact]
        public void ConditionMet_False_FundModel_Null()
        {
            var dateOfBirth = new DateTime(1990, 1, 1);
            var academicYearAugustThirtyFirst = new DateTime(2017, 8, 31);
                        
            var rule = NewRule();

            rule.ConditionMet(null, dateOfBirth, academicYearAugustThirtyFirst, false).Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_False_FundModel_Mismatch()
        {
            var dateOfBirth = new DateTime(1990, 1, 1);
            var academicYearAugustThirtyFirst = new DateTime(2017, 8, 31);

            var rule = NewRule();

            rule.ConditionMet(26, dateOfBirth, academicYearAugustThirtyFirst, false).Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_False_DateOfBirth_Null()
        {
            var dateOfBirth = new DateTime(1990, 1, 1);
            var academicYearAugustThirtyFirst = new DateTime(2017, 8, 31);

            var rule = NewRule();

            rule.ConditionMet(25, null, academicYearAugustThirtyFirst, false).Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_False_DateOfBirth_19()
        {
            var dateOfBirth = new DateTime(1990, 1, 1);
            var academicYearAugustThirtyFirst = new DateTime(2017, 8, 31);

            var dateTimeQueryServiceMock = new Mock<IDateTimeQueryService>();

            dateTimeQueryServiceMock.Setup(qs => qs.YearsBetween(dateOfBirth, academicYearAugustThirtyFirst)).Returns(19);

            var rule = NewRule(dateTimeQueryService: dateTimeQueryServiceMock.Object);

            rule.ConditionMet(25, dateOfBirth, academicYearAugustThirtyFirst, false).Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_False_Fam_SOF107()
        {
            var dateOfBirth = new DateTime(1990, 1, 1);
            var academicYearAugustThirtyFirst = new DateTime(2017, 8, 31);

            var dateTimeQueryServiceMock = new Mock<IDateTimeQueryService>();

            dateTimeQueryServiceMock.Setup(qs => qs.YearsBetween(dateOfBirth, academicYearAugustThirtyFirst)).Returns(18);

            var rule = NewRule(dateTimeQueryService: dateTimeQueryServiceMock.Object);

            rule.ConditionMet(25, dateOfBirth, academicYearAugustThirtyFirst, true).Should().BeFalse();
        }

        [Fact]
        public void Validate_Error()
        {
            var dateOfBirth = new DateTime(2000, 1, 1);
            var academicYearAugustThirtyFirst = new DateTime(2017, 8, 31);
            var learningDeliveryFAMs = new MessageLearnerLearningDeliveryLearningDeliveryFAM[] { };

            var learner = new MessageLearner()
            {
                DateOfBirthSpecified = true,
                DateOfBirth = dateOfBirth,
                LearningDelivery = new MessageLearnerLearningDelivery[]
                {
                    new MessageLearnerLearningDelivery()
                    {
                        LearnStartDateSpecified = true,
                        LearnStartDate = academicYearAugustThirtyFirst,
                        FundModelSpecified = true,
                        FundModel = 25,
                        LearningDeliveryFAM = learningDeliveryFAMs
                    }
                }
            };

            var validationDataServiceMock = new Mock<IValidationDataService>();
            var dateTimeQueryServiceMock = new Mock<IDateTimeQueryService>();
            var messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock = new Mock<ILearningDeliveryFAMQueryService>();
            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();

            validationDataServiceMock.SetupGet(vds => vds.AcademicYearAugustThirtyFirst).Returns(academicYearAugustThirtyFirst);
            dateTimeQueryServiceMock.Setup(qs => qs.YearsBetween(dateOfBirth, academicYearAugustThirtyFirst)).Returns(17);
            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasLearningDeliveryFAMCodeForType(learningDeliveryFAMs, "SOF", "107")).Returns(false);

            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("DateOfBirth_20", null, null, null);

            validationErrorHandlerMock.Setup(handle);

            var rule = NewRule(validationDataServiceMock.Object, dateTimeQueryServiceMock.Object, messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Object, validationErrorHandlerMock.Object);

            rule.Validate(learner);

            validationErrorHandlerMock.Verify(handle, Times.Once);            
        }

        [Fact]
        public void Validate_NoErrors()
        {
            var dateOfBirth = new DateTime(2000, 1, 1);
            var academicYearStartDate = new DateTime(2017, 8, 31);
            var learningDeliveryFAMs = new MessageLearnerLearningDeliveryLearningDeliveryFAM[] { };

            var learner = new MessageLearner()
            {
                DateOfBirthSpecified = true,
                DateOfBirth = dateOfBirth,
                LearningDelivery = new MessageLearnerLearningDelivery[]
                {
                    new MessageLearnerLearningDelivery()
                    {
                        FundModelSpecified = true,
                        FundModel = 25,
                        LearningDeliveryFAM = learningDeliveryFAMs
                    }
                }
            };

            var validationDataServiceMock = new Mock<IValidationDataService>();
            var messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock = new Mock<ILearningDeliveryFAMQueryService>();

            validationDataServiceMock.SetupGet(vds => vds.AcademicYearAugustThirtyFirst).Returns(academicYearStartDate);
            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasLearningDeliveryFAMCodeForType(learningDeliveryFAMs, "SOF", "107")).Returns(true);

            var rule = NewRule(validationDataServiceMock.Object, messageLearnerLearningDeliveryLearningDeliveryFAMQueryService: messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Object);

            rule.Validate(learner);
        }
    }
}
