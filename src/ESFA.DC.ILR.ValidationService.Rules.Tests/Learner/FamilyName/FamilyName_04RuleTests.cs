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
    public class FamilyName_04RuleTests
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

            var rule = new FamilyName_04Rule(null, null);

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

            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasLearningDeliveryFAMCodeForType(It.IsAny<IEnumerable<ILearningDeliveryFAM>>(), "SOF", "108")).Returns(true);
            
            var rule = new FamilyName_04Rule(messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Object, null);

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
                    LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[]
                    {
                        new MessageLearnerLearningDeliveryLearningDeliveryFAM()
                        {
                            LearnDelFAMCode = "SOF",
                            LearnDelFAMType = "108"
                        }
                    }
                }
            };

            var rule = new FamilyName_04Rule(null, null);

            rule.CrossLearningDeliveryConditionMet(learningDeliveries).Should().BeFalse();
        }
        
        [Fact]
        public void CrossLearningDeliveryConditionMet_False_Null()
        {
            var rule = new FamilyName_04Rule(null, null);

            rule.CrossLearningDeliveryConditionMet(null).Should().BeFalse();
        }

        [Theory]
        [InlineData(3, null)]
        [InlineData(0, null)]
        [InlineData(4, "   ")]
        public void ConditionMet_True(long planLearnHours, string familyName)
        {
            var rule = new FamilyName_04Rule(null, null);

            rule.ConditionMet(planLearnHours, 1, familyName).Should().BeTrue();
        }        

        [Fact]
        public void ConditionMet_False_PlanLearnHours()
        {
            var rule = new FamilyName_04Rule(null, null);

            rule.ConditionMet(11, 1, null).Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_False_Uln()
        {
            var rule = new FamilyName_04Rule(null, null);

            rule.ConditionMet(3, 9999999999, null);

        }

        [Fact]
        public void ConditionMet_False_FamilyName()
        {
            var rule = new FamilyName_04Rule(null, null);

            rule.ConditionMet(3, 1, "Geoff").Should().BeFalse();
        }

        [Fact]
        public void Validate_Error()
        {
            var learner = new MessageLearner()
            {
                PlanLearnHours = 3,
                PlanLearnHoursSpecified = true,
                FamilyName = null,
                ULN = 1,
                ULNSpecified = true,
                LearningDelivery = new MessageLearnerLearningDelivery[]
                {
                    new MessageLearnerLearningDelivery()
                    {
                        FundModel = 10
                    }
                }
            };

            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();

            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("FamilyName_04", null, null, null);

            validationErrorHandlerMock.Setup(handle);

            var rule = new FamilyName_04Rule(null, validationErrorHandlerMock.Object);

            rule.Validate(learner);

            validationErrorHandlerMock.Verify(handle, Times.Once);
        }

        [Fact]
        public void Validate_NoErrors()
        {
            var learner = new MessageLearner()
            {
                PlanLearnHours = 12
            };

            var rule = new FamilyName_04Rule(null, null);

            rule.Validate(learner);
        }
    }
}
