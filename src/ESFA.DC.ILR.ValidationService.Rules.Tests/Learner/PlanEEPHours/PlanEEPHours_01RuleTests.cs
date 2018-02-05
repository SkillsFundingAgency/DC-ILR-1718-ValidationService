using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Derived.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Learner.PlanEEPHours;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Learner.PlanEEPHours
{
    public class PlanEEPHours_01RuleTests
    {
        [Theory]
        [InlineData(25)]
        [InlineData(82)]
        public void ConditionMet_True(long? fundModel)
        {
            var rule = new PlanEEPHours_01Rule(null, null);
         
            rule.ConditionMet(null,fundModel).Should().BeTrue();
        }


        [Theory]
        [InlineData(null,10)]
        [InlineData(10, 82)]
        [InlineData(10, 25)]
        public void ConditionMet_False(long? planEepHours, long? fundModel )
        {
            var rule = new PlanEEPHours_01Rule(null, null);

            rule.ConditionMet(10,82).Should().BeFalse();
        }

        [Fact]
        public void ExcludeConditionMet_AllAimsClosed_True()
        {
            var rule = new PlanEEPHours_01Rule(null, null);

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
            var rule = new PlanEEPHours_01Rule(null, null);

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
        [InlineData(70, null)]
        [InlineData(null, 2)]
        public void ExcludeConditionMet_True(long? fundModel, long? progType)
        {
            var learningDelivery = SetupLearningDelivery(fundModel, progType);

            var dd07Mock = new Mock<IDD07>();

            dd07Mock.Setup(dd => dd.Derive(progType)).Returns("Y");

            var rule = new PlanEEPHours_01Rule(null, dd07Mock.Object);
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

            var rule = new PlanEEPHours_01Rule(null, dd07Mock.Object);

            rule.Exclude(learningDelivery).Should().BeFalse();
        }

        [Fact]
        public void ExcludeConditionDD07_False()
        {
            var rule = new PlanEEPHours_01Rule(null, null);

            rule.HasLearningDeliveryDd07ExcludeConditionMet("").Should().BeFalse();
        }

        [Fact]
        public void ExcludeConditionDD07_True()
        {
            var rule = new PlanEEPHours_01Rule(null, null);

            rule.HasLearningDeliveryDd07ExcludeConditionMet("Y").Should().BeTrue();
        }

        [Fact]
        public void ExcludeConditionFundModel_True()
        {
            var rule = new PlanEEPHours_01Rule(null, null);

            rule.HasLearningDeliveryFundModelExcludeConditionMet(70).Should().BeTrue();
        }

        [Fact]
        public void ExcludeConditionFundModel_False()
        {
            var rule = new PlanEEPHours_01Rule(null, null);

            rule.HasLearningDeliveryFundModelExcludeConditionMet(10).Should().BeFalse();
        }

        [Fact]
        public void Validate_Error()
        {
            var learner = SetupLearner(null);

            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("PlanEEPHours_01", null, null, null);

            var dd07Mock = new Mock<IDD07>();
            dd07Mock.Setup(dd => dd.Derive(It.IsAny<long>())).Returns("N");

            var rule = new PlanEEPHours_01Rule(validationErrorHandlerMock.Object, dd07Mock.Object);

            rule.Validate(learner);

            validationErrorHandlerMock.Verify(handle, Times.Once);
        }

        [Fact]
        public void Validate_NoError()
        {
            var learner = SetupLearner(10);

            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("PlanEEPHours_01", null, null, null);

            var dd07Mock = new Mock<IDD07>();
            dd07Mock.Setup(dd => dd.Derive(It.IsAny<long>())).Returns("N");

            var rule = new PlanEEPHours_01Rule(validationErrorHandlerMock.Object, dd07Mock.Object);
            rule.Validate(learner);
            validationErrorHandlerMock.Verify(handle, Times.Never);
        }

        private static MessageLearner SetupLearner(long? planEEPHours)
        {
            var learner = new MessageLearner
            {
                PlanEEPHoursSpecified= planEEPHours.HasValue,
                PlanEEPHours = planEEPHours ?? 0,
                LearningDelivery = new[]
                {
                    new MessageLearnerLearningDelivery()
                    {
                        FundModel = 25,
                        FundModelSpecified = true
                    }
                }
            };

            return learner;
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
