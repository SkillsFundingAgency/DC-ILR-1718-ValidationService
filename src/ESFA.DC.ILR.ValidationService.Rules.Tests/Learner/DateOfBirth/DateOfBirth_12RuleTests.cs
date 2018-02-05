using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Learner.DateOfBirth;
using ESFA.DC.ILR.ValidationService.Rules.Query.Interface;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Learner.DateOfBirth
{
    public class DateOfBirth_12RuleTests
    {
        private DateOfBirth_12Rule NewRule(IDateTimeQueryService dateTimeQueryService = null, ILearningDeliveryFAMQueryService messageLearnerLearningDeliveryLearningDeliveryFAMQueryService = null, IValidationErrorHandler validationErrorHandler = null)
        {
            return new DateOfBirth_12Rule(dateTimeQueryService, messageLearnerLearningDeliveryLearningDeliveryFAMQueryService, validationErrorHandler);
        }

        [Fact]
        public void ConditionMet_True()
        {
            var dateOfBirth = new DateTime(2000, 1, 1);
            var learnStartDate = new DateTime(2017, 6, 30);

            var dateTimeQueryServiceMock = new Mock<IDateTimeQueryService>();

            dateTimeQueryServiceMock.Setup(qs => qs.YearsBetween(dateOfBirth, learnStartDate)).Returns(18);

            var rule = NewRule(dateTimeQueryServiceMock.Object);

            rule.ConditionMet(10, dateOfBirth, learnStartDate, true).Should().BeTrue();
        }

        [Fact]
        public void ConditionMet_False_LearningDeliveryFAM()
        {
            var dateOfBirth = new DateTime(2000, 1, 1);
            var learnStartDate = new DateTime(2017, 6, 30);           

            var rule = NewRule();

            rule.ConditionMet(10, dateOfBirth, learnStartDate, false).Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_False_FundModel_Null()
        {
            var dateOfBirth = new DateTime(2000, 1, 1);
            var learnStartDate = new DateTime(2017, 6, 30);

            var rule = NewRule();

            rule.ConditionMet(null, dateOfBirth, learnStartDate, true).Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_False_FundModel_Different()
        {
            var dateOfBirth = new DateTime(2000, 1, 1);
            var learnStartDate = new DateTime(2017, 6, 30);

            var rule = NewRule();

            rule.ConditionMet(11, dateOfBirth, learnStartDate, true).Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_False_DateOfBirth_Null()
        {
            var learnStartDate = new DateTime(2017, 6, 30);

            var rule = NewRule();

            rule.ConditionMet(10, null, learnStartDate, true).Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_False_LearnStartDate_Null()
        {
            var dateOfBirth = new DateTime(2000, 1, 1);

            var rule = NewRule();

            rule.ConditionMet(10, dateOfBirth, null, true).Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_False_Age_19()
        {
            var dateOfBirth = new DateTime(2000, 1, 1);
            var learnStartDate = new DateTime(2017, 6, 30);

            var dateTimeQueryServiceMock = new Mock<IDateTimeQueryService>();

            dateTimeQueryServiceMock.Setup(qs => qs.YearsBetween(dateOfBirth, learnStartDate)).Returns(19);

            var rule = NewRule(dateTimeQueryServiceMock.Object);

            rule.ConditionMet(10, dateOfBirth, learnStartDate, true).Should().BeFalse();
        }

        [Fact]
        public void Validate_Error()
        {
            var dateOfBirth = new DateTime(2000, 1, 1);
            var learnStartDate = new DateTime(2017, 6, 30);
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
                        LearnStartDate = learnStartDate,
                        FundModelSpecified = true,
                        FundModel = 10,
                        LearningDeliveryFAM = learningDeliveryFAMs
                    }
                }
            };

            var dateTimeQueryServiceMock = new Mock<IDateTimeQueryService>();
            var messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock = new Mock<ILearningDeliveryFAMQueryService>();
            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            
            dateTimeQueryServiceMock.Setup(qs => qs.YearsBetween(dateOfBirth, learnStartDate)).Returns(18);
            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasAnyLearningDeliveryFAMCodesForType(learningDeliveryFAMs, "ASL", It.IsAny<IEnumerable<string>>())).Returns(true);

            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("DateOfBirth_12", null, null, null);

            validationErrorHandlerMock.Setup(handle);

            var rule = NewRule(dateTimeQueryServiceMock.Object, messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Object, validationErrorHandlerMock.Object);

            rule.Validate(learner);

            validationErrorHandlerMock.Verify(handle, Times.Once);
        }

        [Fact]
        public void Validate_NoErrors()
        {
            var dateOfBirth = new DateTime(2000, 1, 1);
            var learnStartDate = new DateTime(2017, 6, 30);
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
                        LearnStartDate = learnStartDate,
                        FundModelSpecified = true,
                        FundModel = 10,
                        LearningDeliveryFAM = learningDeliveryFAMs
                    }
                }
            };
            
            var messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock = new Mock<ILearningDeliveryFAMQueryService>();
            
            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasAnyLearningDeliveryFAMCodesForType(learningDeliveryFAMs, "ASL", It.IsAny<IEnumerable<string>>())).Returns(false);

            var rule = NewRule(messageLearnerLearningDeliveryLearningDeliveryFAMQueryService: messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Object);

            rule.Validate(learner);
        }
    }
}
