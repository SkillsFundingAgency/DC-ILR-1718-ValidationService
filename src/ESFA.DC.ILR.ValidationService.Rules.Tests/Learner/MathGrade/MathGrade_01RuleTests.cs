using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Interface;
using FluentAssertions;
using Moq;
using System;
using System.Linq.Expressions;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Learner.MathGrade
{
    public class MathGrade_01RuleTests
    {
        [Theory]
        [InlineData(null,25)]
        [InlineData(null,82)]
        [InlineData(" ",82)]
        [InlineData("", 25)]
        public void ConditionMet_True(string mathGrade , long? fundModel)
        {
            var rule = new MathGrade_01Rule(null);
            rule.ConditionMet(mathGrade, fundModel).Should().BeTrue();
        }


        [Theory]
        [InlineData(null, 10)]
        [InlineData(10, 82)]
        [InlineData(10, 25)]
        public void ConditionMet_False(long? planEepHours, long? fundModel)
        {
            var rule = new MathGrade_01Rule(null);
            rule.ConditionMet("X", 82).Should().BeFalse();
        }


        [Theory]
        [InlineData(25)]
        [InlineData(82)]
        public void ConditionFundModel_True(long? fundModel)
        {
            var rule = new MathGrade_01Rule(null);
            rule.FundModelConditionMet(fundModel).Should().BeTrue();
        }

        [Theory]
        [InlineData(15)]
        [InlineData(null)]
        public void ConditionFundModel_False(long? fundModel)
        {
            var rule = new MathGrade_01Rule(null);
            rule.FundModelConditionMet(fundModel).Should().BeFalse();
        }

        [Fact]
        public void Validate_Error()
        {
            var learner = SetupLearner("");

            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("MathGrade_01", null, null, null);
            
            var rule = new MathGrade_01Rule(validationErrorHandlerMock.Object);
            rule.Validate(learner);
            validationErrorHandlerMock.Verify(handle, Times.Once);
        }

        [Fact]
        public void Validate_NoError()
        {
            var learner = SetupLearner("A");

            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("MathGrade_01", null, null, null);
            
            var rule = new MathGrade_01Rule(validationErrorHandlerMock.Object);
            rule.Validate(learner);
            validationErrorHandlerMock.Verify(handle, Times.Never);
        }

        private static MessageLearner SetupLearner(string mathGrade)
        {
            var learner = new MessageLearner
            {
                MathGrade = mathGrade,
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
