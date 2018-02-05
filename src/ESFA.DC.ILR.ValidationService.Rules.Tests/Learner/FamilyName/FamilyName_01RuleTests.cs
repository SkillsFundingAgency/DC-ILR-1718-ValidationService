using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Learner.GivenNames;
using ESFA.DC.ILR.ValidationService.Rules.Query.Interface;
using FluentAssertions;
using Moq;
using System;
using System.Linq.Expressions;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Learner.FamilyName
{
    public class FamilyName_01RuleTests
    {
        [Fact]
        public void Exclude_True_FundModel10()
        {
            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                FundModel = 10
            };

            var rule = new FamilyName_01Rule(null, null);

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

            var messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock = new Mock<ILearningDeliveryFAMQueryService>();

            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasLearningDeliveryFAMCodeForType(learningDelivery.LearningDeliveryFAM, "SOF", "108")).Returns(true);
            
            var rule = new FamilyName_01Rule(messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Object, null);

            rule.Exclude(learningDelivery).Should().BeTrue();
        }

        [Fact]
        public void Exclude_False()
        {
            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                FundModel = 2
            };

            var rule = new FamilyName_01Rule(null, null);

            rule.Exclude(learningDelivery).Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_True_Null()
        {
            var rule = new FamilyName_01Rule(null, null);

            rule.ConditionMet(null).Should().BeTrue();
        }

        [Fact]
        public void ConditionMet_True_Whitespace()
        {
            var rule = new FamilyName_01Rule(null, null);

            rule.ConditionMet("    ").Should().BeTrue();
        }

        [Fact]
        public void ConditionMet_False()
        {
            var rule = new FamilyName_01Rule(null, null);

            rule.ConditionMet("Not Null or White Space").Should().BeFalse();
        }

        [Fact]
        public void Validate_Error()
        {
            var learner = new MessageLearner()
            {
                FamilyName = null
            };

            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();

            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("FamilyName_01", null, null, null);

            validationErrorHandlerMock.Setup(handle);

            var rule = new FamilyName_01Rule(null, validationErrorHandlerMock.Object);

            rule.Validate(learner);

            validationErrorHandlerMock.Verify(handle, Times.Once);
        }

        [Fact]
        public void Validate_NoErrors()
        {
            var learner = new MessageLearner()
            {
                FamilyName = "Not Null"
            };
            
            var rule = new FamilyName_01Rule(null, null);

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
            
            var rule = new FamilyName_01Rule(null, null);

            rule.Validate(learner);
        }
    }
}
