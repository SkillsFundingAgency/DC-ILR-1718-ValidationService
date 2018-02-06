using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Learner.EngGrade;
using FluentAssertions;
using Moq;
using System;
using System.Linq.Expressions;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Learner.EngGrade
{
    public class EngGrade_01RuleTests
    {
        [Theory]
        [InlineData(null,25)]
        [InlineData(null,82)]
        [InlineData(" ",82)]
        [InlineData("", 25)]
        public void ConditionMet_True(string engGrade , long? fundModel)
        {
            var rule = new EngGrade_01Rule(null);
            rule.ConditionMet(engGrade, fundModel).Should().BeTrue();
        }


        [Fact]
        public void ConditionMet_False()
        {
            var rule = new EngGrade_01Rule(null);
            rule.ConditionMet("X", 82).Should().BeFalse();
        }


        [Theory]
        [InlineData(25)]
        [InlineData(82)]
        public void ConditionFundModel_True(long? fundModel)
        {
            var rule = new EngGrade_01Rule(null);
            rule.FundModelConditionMet(fundModel).Should().BeTrue();
        }

        [Theory]
        [InlineData(15)]
        [InlineData(null)]
        public void ConditionFundModel_False(long? fundModel)
        {
            var rule = new EngGrade_01Rule(null);
            rule.FundModelConditionMet(fundModel).Should().BeFalse();
        }

        [Fact]
        public void Validate_Error()
        {
            var learner = SetupLearner("");

            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("EngGrade_01", null, null, null);
            
            var rule = new EngGrade_01Rule(validationErrorHandlerMock.Object);
            rule.Validate(learner);
            validationErrorHandlerMock.Verify(handle, Times.Once);
        }

        [Fact]
        public void Validate_NoError()
        {
            var learner = SetupLearner("A");

            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("EngGrade_01", null, null, null);
            
            var rule = new EngGrade_01Rule(validationErrorHandlerMock.Object);
            rule.Validate(learner);
            validationErrorHandlerMock.Verify(handle, Times.Never);
        }

        private static MessageLearner SetupLearner(string engGrade)
        {
            var learner = new MessageLearner
            {
                EngGrade = engGrade,
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




    }
}
