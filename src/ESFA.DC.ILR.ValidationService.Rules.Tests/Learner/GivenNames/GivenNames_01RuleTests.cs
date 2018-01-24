using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Learner.GivenNames;
using ESFA.DC.ILR.ValidationService.Rules.Query.Interface;
using FluentAssertions;
using Moq;
using System;
using System.Linq.Expressions;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Learner.GivenNames
{
    public class GivenNames_01RuleTests
    {
        private GivenNames_01Rule NewRule(IMessageLearnerLearningDeliveryLearningDeliveryFAMQueryService messageLearnerLearningDeliveryLearningDeliveryFAMQueryService = null, IValidationErrorHandler validationErrorHandler = null)
        {
            return new GivenNames_01Rule(messageLearnerLearningDeliveryLearningDeliveryFAMQueryService, validationErrorHandler);
        }

        [Fact]
        public void Exclude_True_FundModel10()
        {
            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                FundModel = 10
            };

            var rule = NewRule();

            rule.Exclude(learningDelivery).Should().BeTrue();
        }

        [Fact]
        public void Exclude_True_FundModel99()
        {
            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                FundModel = 99,
                LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[] { }
            };

            var messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock = new Mock<IMessageLearnerLearningDeliveryLearningDeliveryFAMQueryService>();

            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasLearningDeliveryFAMCodeForType(learningDelivery.LearningDeliveryFAM, "SOF", "108")).Returns(true);

            var rule = NewRule(messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Object);

            rule.Exclude(learningDelivery).Should().BeTrue();
        }

        [Fact]
        public void Exclude_False()
        {
            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                FundModel = 2
            };

            var rule = NewRule();

            rule.Exclude(learningDelivery).Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_True_Null()
        {
            var rule = NewRule();

            rule.ConditionMet(null).Should().BeTrue();
        }

        [Fact]
        public void ConditionMet_True_Whitespace()
        {
            var rule = NewRule();

            rule.ConditionMet("    ").Should().BeTrue();
        }

        [Fact]
        public void ConditionMet_False()
        {
            var rule = NewRule();

            rule.ConditionMet("Not Null or White Space").Should().BeFalse();
        }

        [Fact]
        public void Validate_Error()
        {
            var learner = new MessageLearner()
            {
                GivenNames = null
            };

            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();

            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("GivenNames_01", null, null, null);

            validationErrorHandlerMock.Setup(handle);

            var rule = NewRule(validationErrorHandler: validationErrorHandlerMock.Object);

            rule.Validate(learner);

            validationErrorHandlerMock.Verify(handle, Times.Once);
        }

        [Fact]
        public void Validate_NoErrors()
        {
            var learner = new MessageLearner()
            {
                GivenNames = "Not Null"
            };
            
            var rule = NewRule();

            rule.Validate(learner);            
        }

        [Fact]
        public void Validate_NoErrors_AllExcluded()
        {
            var learner = new MessageLearner()
            {
                FamilyName = null,
                LearningDelivery = new MessageLearnerLearningDelivery[]
                {
                    new MessageLearnerLearningDelivery()
                    {
                        FundModel = 10
                    }
                }
            };

            var rule = NewRule();

            rule.Validate(learner);
        }
    }
}
