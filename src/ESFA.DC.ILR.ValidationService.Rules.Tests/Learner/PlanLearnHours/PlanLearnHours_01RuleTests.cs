using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Learner.PlanLearnHours;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Rules.Derived.Interface;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Learner.PlanLearnHours
{
    public class PlanLearnHours_01RuleTests : PlanLearnHoursTestsBase
    {
        [Fact]
        public void ConditionMet_True()
        {
            var rule = new PlanLearnHours_01Rule(null,null);
            rule.ConditionMet(null).Should().BeTrue();
        }
        

        [Fact]
        public void ConditionMet_False()
        {
            var rule = new PlanLearnHours_01Rule(null,null);
            rule.ConditionMet(10).Should().BeFalse();
        }

        [Fact]
        public void ExcludeConditionMet_AllAimsClosed_True()
        {
            var rule = new PlanLearnHours_01Rule(null,null);
            var learningDelivers = new List<MessageLearnerLearningDelivery>()
            {
                new MessageLearnerLearningDelivery()
                {
                    LearnActEndDate = DateTime.Now,
                    LearnActEndDateSpecified = true
                },
                new MessageLearnerLearningDelivery()
                {
                    LearnActEndDate = DateTime.Now,
                    LearnActEndDateSpecified = true
                }
            };

            rule.HasAllLearningAimsClosedExcludeConditionMet(learningDelivers).Should().BeTrue();
        }

        [Fact]
        public void ExcludeConditionMet_All_AimsClosed_False()
        {
            var rule = new PlanLearnHours_01Rule(null, null);
            var learningDelivers = new List<MessageLearnerLearningDelivery>()
            {
                new MessageLearnerLearningDelivery()
                {
                    LearnActEndDateSpecified = false
                },
                new MessageLearnerLearningDelivery()
                {
                    LearnActEndDate = DateTime.Now,
                    LearnActEndDateSpecified = true
                }
            };

            rule.HasAllLearningAimsClosedExcludeConditionMet(learningDelivers).Should().BeFalse();
        }

        [Theory]
        [InlineData(70,null)]
        [InlineData(null, 2)]
        public void ExcludeConditionMet_True(long? fundModel, long? progType)
        {
            var learningDelivery = SetupLearningDelivery(fundModel, progType);
            var dd07Mock = new Mock<IDD07>();
            dd07Mock.Setup(dd => dd.Derive(progType)).Returns("Y");

            var rule = new PlanLearnHours_01Rule(null, dd07Mock.Object);
            rule.Exclude(learningDelivery).Should().BeTrue();
        }

        [Theory]
        [InlineData(10, null)]
        [InlineData(null, 12)]
        public void ExcludeConditionMet_False(long? fundModel, long? progType)
        {
            var learningDelivery = SetupLearningDelivery(fundModel, progType);
            var dd07Mock = new Mock<IDD07>();
            dd07Mock.Setup(dd => dd.Derive(progType)).Returns("N");
            var rule = new PlanLearnHours_01Rule(null, dd07Mock.Object);
            rule.Exclude(learningDelivery).Should().BeFalse();
        }


        [Fact]
        public void ExcludeConditionDD07_False()
        {
            var rule = new PlanLearnHours_01Rule(null, null);
            rule.HasLearningDeliveryDd07ExcludeConditionMet("").Should().BeFalse();
        }

        [Fact]
        public void ExcludeConditionDD07_True()
        {
            var rule = new PlanLearnHours_01Rule(null,null);
            rule.HasLearningDeliveryDd07ExcludeConditionMet("Y").Should().BeTrue();
        }


        [Fact]
        public void ExcludeConditionFundModel_True()
        {
            var rule = new PlanLearnHours_01Rule(null, null);
            rule.HasLearningDeliveryFundModelExcludeConditionMet(70).Should().BeTrue();
        }

        [Fact]
        public void ExcludeConditionFundModel_False()
        {
            var rule = new PlanLearnHours_01Rule(null, null);
            rule.HasLearningDeliveryFundModelExcludeConditionMet(10).Should().BeFalse();
        }
        

        [Fact]
        public void Validate_Error()
        {
            var learner = SetupLearner(null,null,35);

            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("PlanLearnHours_01", null, null, null);

            var dd07Mock = new Mock<IDD07>();
            dd07Mock.Setup(dd => dd.Derive(It.IsAny<long>())).Returns("N");

            var rule = new PlanLearnHours_01Rule(validationErrorHandlerMock.Object,dd07Mock.Object);
            rule.Validate(learner);
            validationErrorHandlerMock.Verify(handle, Times.Once);
        }

        [Fact]
        public void Validate_NoError()
        {
            var learner = SetupLearner(1, null, 35);

            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("PlanLearnHours_01", null, null, null);

          
            var rule = new PlanLearnHours_01Rule(validationErrorHandlerMock.Object, null);
            rule.Validate(learner);
            validationErrorHandlerMock.Verify(handle, Times.Never);
        }


        private MessageLearnerLearningDelivery SetupLearningDelivery(long? fundModel, long? progType)
        {
            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                FundModelSpecified = fundModel.HasValue,
                FundModel = fundModel ?? 0,
                ProgType = progType ?? 0,
                ProgTypeSpecified = progType.HasValue
            };
            return learningDelivery;
        }
    }
}
