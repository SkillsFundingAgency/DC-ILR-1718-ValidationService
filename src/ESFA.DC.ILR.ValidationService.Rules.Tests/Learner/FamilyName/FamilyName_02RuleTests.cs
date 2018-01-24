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

            var rule = new FamilyName_02Rule(null, null);

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

            var messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock = new Mock<IMessageLearnerLearningDeliveryLearningDeliveryFAMQueryService>();

            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasLearningDeliveryFAMCodeForType(It.IsAny<IEnumerable<IMessageLearnerLearningDeliveryLearningDeliveryFAM>>(), "SOF", "108")).Returns(true);
            
            var rule = new FamilyName_02Rule(messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Object, null);

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

            var rule = new FamilyName_02Rule(null, null);

            rule.CrossLearningDeliveryConditionMet(learningDeliveries).Should().BeFalse();
        }
        
        [Fact]
        public void CrossLearningDeliveryConditionMet_False_Null()
        {
            var rule = new FamilyName_02Rule(null, null);

            rule.CrossLearningDeliveryConditionMet(null).Should().BeFalse();
        }

        [Theory]
        [InlineData(11, null)]
        [InlineData(1000, null)]
        [InlineData(11, "   ")]
        public void ConditionMet_True(long planLearnHours, string givenNames)
        {
            var rule = new FamilyName_02Rule(null, null);

            rule.ConditionMet(planLearnHours, givenNames).Should().BeTrue();
        }        

        [Fact]
        public void ConditionMet_False_PlanLearnHours()
        {
            var rule = new FamilyName_02Rule(null, null);

            rule.ConditionMet(3, null).Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_False_GivenNames()
        {
            var rule = new FamilyName_02Rule(null, null);

            rule.ConditionMet(11, "Geoff").Should().BeFalse();
        }

        [Fact]
        public void Validate_Error()
        {
            var learner = new MessageLearner()
            {
                PlanLearnHours = 11,
                PlanLearnHoursSpecified = true,
                GivenNames = null,
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

            var rule = new FamilyName_02Rule(null, validationErrorHandlerMock.Object);

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

            var rule = new FamilyName_02Rule(null, null);

            rule.Validate(learner);
        }
    }
}
