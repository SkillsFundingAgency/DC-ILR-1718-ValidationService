using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Learner.FamilyName;
using ESFA.DC.ILR.ValidationService.Rules.Query.Interface;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Learner.FamilyName
{
    public class FamilyName_02RuleTests
    {
        public FamilyName_02Rule NewRule(ILearningDeliveryFAMQueryService messageLearnerLearningDeliveryLearningDeliveryFAMQueryService = null, IValidationErrorHandler validationErrorHandler = null)
        {
            return new FamilyName_02Rule(messageLearnerLearningDeliveryLearningDeliveryFAMQueryService, validationErrorHandler);
        }

        [Fact]
        public void CrossLearningDeliveryConditionMet_True_FundModel10()
        {
            var learningDeliveries = new List<MessageLearnerLearningDelivery>()
            {
                new MessageLearnerLearningDelivery()
                {
                    FundModel = 10
                },
                new MessageLearnerLearningDelivery()
                {
                    FundModel = 10
                }
            };

            var rule = NewRule();

            rule.CrossLearningDeliveryConditionMet(learningDeliveries).Should().BeTrue();
        }

        [Fact]
        public void CrossLearningDeliveryConditionMet_True_FundModel99()
        {
            var learningDeliveries = new List<MessageLearnerLearningDelivery>()
            {
                new MessageLearnerLearningDelivery()
                {
                    FundModel = 99,
                    LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[] { }
                },
                new MessageLearnerLearningDelivery()
                {
                    FundModel = 99,
                    LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[] { }
                }
            };

            var learningDeliveryFAMQueryServiceMock = new Mock<ILearningDeliveryFAMQueryService>();

            learningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasLearningDeliveryFAMCodeForType(It.IsAny<IEnumerable<ILearningDeliveryFAM>>(), "SOF", "108")).Returns(true);
            
            var rule = NewRule(learningDeliveryFAMQueryServiceMock.Object);

            rule.CrossLearningDeliveryConditionMet(learningDeliveries).Should().BeTrue();
        }

        [Fact]
        public void CrossLearningDeliveryConditionMet_False()
        {
            var learningDeliveries = new List<MessageLearnerLearningDelivery>()
            {
                new MessageLearnerLearningDelivery()
                {
                    FundModel = 10
                },
                new MessageLearnerLearningDelivery()
                {
                    FundModel = 99,
                    LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[]{ }
                }
            };

            var rule = NewRule();

            rule.CrossLearningDeliveryConditionMet(learningDeliveries).Should().BeFalse();
        }
        
        [Fact]
        public void CrossLearningDeliveryConditionMet_False_Null()
        {
            var rule = NewRule();

            rule.CrossLearningDeliveryConditionMet(null).Should().BeFalse();
        }

        [Theory]
        [InlineData(11, null)]
        [InlineData(1000, null)]
        [InlineData(11, "   ")]
        public void ConditionMet_True(long planLearnHours, string familyName)
        {
            var rule = NewRule();

            rule.ConditionMet(planLearnHours, familyName).Should().BeTrue();
        }        

        [Fact]
        public void ConditionMet_False_PlanLearnHours()
        {
            var rule = NewRule();

            rule.ConditionMet(3, null).Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_False_FamilyName()
        {
            var rule = NewRule();

            rule.ConditionMet(11, "Geoff").Should().BeFalse();
        }

        [Fact]
        public void Validate_Error()
        {
            var learner = new MessageLearner()
            {
                PlanLearnHours = 11,
                PlanLearnHoursSpecified = true,
                FamilyName = null,
                LearningDelivery = new MessageLearnerLearningDelivery[]
                {
                    new MessageLearnerLearningDelivery()
                    {
                        FundModel = 10
                    }
                }
            };

            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();

            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("FamilyName_02", null, null, null);

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
                PlanLearnHours = 8
            };

            var rule = NewRule();

            rule.Validate(learner);
        }
    }
}
