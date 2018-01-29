using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.Model.Interface;
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
    public class DateOfBirth_02RuleTests
    {
        private DateOfBirth_02Rule NewRule(IMessageLearnerLearningDeliveryLearningDeliveryFAMQueryService messageLearnerLearningDeliveryLearningDeliveryFAMQueryService = null, IValidationErrorHandler validationErrorHandler = null)
        {
            return new DateOfBirth_02Rule(messageLearnerLearningDeliveryLearningDeliveryFAMQueryService, validationErrorHandler);
        }

        [Fact]
        public void Exclude_True()
        {
            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[] { }
            };

            var messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock = new Mock<IMessageLearnerLearningDeliveryLearningDeliveryFAMQueryService>();

            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasLearningDeliveryFAMType(learningDelivery.LearningDeliveryFAM, "ADL")).Returns(true);

            var rule = NewRule(messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Object);

            rule.Exclude(learningDelivery).Should().BeTrue();
        }

        [Fact]
        public void Exclude_False()
        {
            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[] { }
            };

            var messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock = new Mock<IMessageLearnerLearningDeliveryLearningDeliveryFAMQueryService>();

            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasLearningDeliveryFAMType(learningDelivery.LearningDeliveryFAM, "ADL")).Returns(false);

            var rule = NewRule(messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Object);

            rule.Exclude(learningDelivery).Should().BeFalse();
        }

        [Theory]
        [InlineData(10)]
        [InlineData(99)]
        public void ConditionMet_True(long fundModel)
        {
            var rule = NewRule();

            rule.ConditionMet(fundModel, null);
        }

        [Fact]
        public void ConditionMet_False_DateOfBirth()
        {
            var rule = NewRule();

            rule.ConditionMet(10, new DateTime(1988, 12, 25)).Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_False_FundModel_Null()
        {
            var rule = NewRule();

            rule.ConditionMet(null, new DateTime(1988, 12, 25)).Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_False_FundModel()
        {
            var rule = NewRule();

            rule.ConditionMet(1, new DateTime(1988, 12, 25)).Should().BeFalse();
        }

        [Fact]
        public void Validate_Error()
        {
            var learner = new MessageLearner()
            {
                DateOfBirthSpecified = false,
                LearningDelivery = new MessageLearnerLearningDelivery[]
                {
                    new MessageLearnerLearningDelivery()
                    {
                        FundModel = 10,
                        FundModelSpecified = true
                    }
                }
            };

            var messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock = new Mock<IMessageLearnerLearningDeliveryLearningDeliveryFAMQueryService>();
            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();

            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasLearningDeliveryFAMType(It.IsAny<IEnumerable<IMessageLearnerLearningDeliveryLearningDeliveryFAM>>(), "ADL")).Returns(false);

            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("DateOfBirth_02", null, null, null);

            validationErrorHandlerMock.Setup(handle);

            var rule = NewRule(messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Object, validationErrorHandlerMock.Object);

            rule.Validate(learner);

            validationErrorHandlerMock.Verify(handle, Times.Once);
        }

        [Fact]
        public void Validate_NoErrors()
        {
            var learner = new MessageLearner()
            {
                DateOfBirthSpecified = true,
                DateOfBirth = new DateTime(1988, 12, 25),
                LearningDelivery = new MessageLearnerLearningDelivery[]
                {
                    new MessageLearnerLearningDelivery()
                    {
                        FundModel = 10,
                        FundModelSpecified = true
                    }
                }
            };

            var messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock = new Mock<IMessageLearnerLearningDeliveryLearningDeliveryFAMQueryService>();

            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasLearningDeliveryFAMType(It.IsAny<IEnumerable<IMessageLearnerLearningDeliveryLearningDeliveryFAM>>(), "ADL")).Returns(false);
            
            var rule = NewRule(messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Object);

            rule.Validate(learner);            
        }
    }
}
