using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Derived.Interface;
using ESFA.DC.ILR.ValidationService.Rules.LearningDelivery.LearnStartDate;
using FluentAssertions;
using Moq;
using System;
using System.Linq.Expressions;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.LearningDelivery.LearnStartDate
{
    public class LearnStartDate_12RuleTests
    {
        [Fact]
        public void ConditionMet_True()
        {
            var rule = new LearnStartDate_12Rule(null, null, null);

            rule.ConditionMet(new DateTime(2018, 8, 1), new DateTime(2016, 7, 31), "Y").Should().BeTrue();
        }

        [Fact]
        public void ConditionMet_False_LearnStartDate_WithinYear()
        {
            var rule = new LearnStartDate_12Rule(null, null, null);

            rule.ConditionMet(new DateTime(2019, 1, 1), new DateTime(2018, 7, 31), "Y").Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_False_LearnStartDate_BeforeAcademicYearEnd()
        {
            var rule = new LearnStartDate_12Rule(null, null, null);

            rule.ConditionMet(new DateTime(2017, 1, 1), new DateTime(2018, 7, 31), "Y").Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_False_DD07()
        {
            var rule = new LearnStartDate_12Rule(null, null, null);

            rule.ConditionMet(new DateTime(2018, 8, 1), new DateTime(2016, 7, 31), "N").Should().BeFalse();
        }

        [Fact]
        public void Validate_NoErrors()
        {
            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                LearnStartDate = new DateTime(2017, 1, 1),
                ProgType = 1,
            };

            var learner = new MessageLearner()
            {
                LearningDelivery = new MessageLearnerLearningDelivery[]
                {
                    learningDelivery
                }
            };

            var validationDataServiceMock = new Mock<IValidationDataService>();
            var dd07Mock = new Mock<IDD07>();

            validationDataServiceMock.SetupGet(vd => vd.AcademicYearEnd).Returns(new DateTime(2017, 8, 1));
            dd07Mock.Setup(dd => dd.Derive(1)).Returns("Y");

            var rule = new LearnStartDate_12Rule(dd07Mock.Object, validationDataServiceMock.Object, null);

            rule.Validate(learner);
        }

        [Fact]
        public void Validate_Errors()
        {
            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                LearnStartDate = new DateTime(2020, 1, 1),
                ProgType = 1
            };

            var learner = new MessageLearner()
            {
                LearningDelivery = new MessageLearnerLearningDelivery[]
                {
                    learningDelivery,
                }
            };

            var validationDataServiceMock = new Mock<IValidationDataService>();
            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            var dd07Mock = new Mock<IDD07>();

            validationDataServiceMock.SetupGet(vd => vd.AcademicYearEnd).Returns(new DateTime(2018, 7, 31));
            dd07Mock.Setup(dd => dd.Derive(1)).Returns("Y");

            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("LearnStartDate_12", null, null, null);

            validationErrorHandlerMock.Setup(handle);

            var rule = new LearnStartDate_12Rule(dd07Mock.Object, validationDataServiceMock.Object, validationErrorHandlerMock.Object);

            rule.Validate(learner);

            validationErrorHandlerMock.Verify(handle, Times.Once);
        }
    }
}
