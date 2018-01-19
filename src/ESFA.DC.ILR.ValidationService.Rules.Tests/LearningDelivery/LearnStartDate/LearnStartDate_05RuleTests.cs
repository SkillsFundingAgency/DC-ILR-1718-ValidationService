using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.LearningDelivery.LearnStartDate;
using FluentAssertions;
using Moq;
using System;
using System.Linq.Expressions;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.LearningDelivery.LearnStartDate
{
    public class LearnStartDate_05RuleTests
    {
        [Fact]
        public void ConditionMet_True()
        {
            var rule = new LearnStartDate_05Rule(null);

            rule.ConditionMet(new DateTime(2018, 1, 1), new DateTime(2017, 8, 1)).Should().BeTrue();
        }

        [Fact]
        public void ConditionMet_False_NullDateOfBirth()
        {
            var rule = new LearnStartDate_05Rule(null);

            rule.ConditionMet(null, new DateTime(2017, 8, 1)).Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_False_DateOfBirth()
        {
            var rule = new LearnStartDate_05Rule(null);

            rule.ConditionMet(new DateTime(1988, 2, 10), new DateTime(2017, 8, 1)).Should().BeFalse();
        }

        [Fact]
        public void Validate_NoErrors()
        {
            var learner = new MessageLearner()
            {
                DateOfBirth = new DateTime(1988, 2, 10),
                DateOfBirthSpecified = true,
                LearningDelivery = new MessageLearnerLearningDelivery[]
                {
                    new MessageLearnerLearningDelivery()
                    {
                        LearnStartDate = new DateTime(2015, 1, 1),
                    }
                }
            };

            var rule = new LearnStartDate_05Rule(null);

            rule.Validate(learner);
        }

        [Fact]
        public void Validate_Errors()
        {
            var learner = new MessageLearner()
            {
                DateOfBirth = new DateTime(2018, 1, 1),
                DateOfBirthSpecified = true,
                LearningDelivery = new MessageLearnerLearningDelivery[]
                {
                    new MessageLearnerLearningDelivery()
                    {
                        LearnStartDate = new DateTime(2005, 1, 1),
                    }
                }
            };

            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();

            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("LearnStartDate_05", null, null, null);

            validationErrorHandlerMock.Setup(handle);

            var rule = new LearnStartDate_05Rule(validationErrorHandlerMock.Object);

            rule.Validate(learner);

            validationErrorHandlerMock.Verify(handle, Times.Once);
        }
    }
}
