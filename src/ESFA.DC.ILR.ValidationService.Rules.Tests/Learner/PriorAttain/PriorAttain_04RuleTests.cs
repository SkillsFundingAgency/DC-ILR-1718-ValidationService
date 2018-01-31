using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Learner.PriorAttain;
using ESFA.DC.ILR.ValidationService.Rules.Query.Interface;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Learner.PriorAttain
{
    public class PriorAttain_04RuleTests
    {

       
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void RuleConditionMet_True(long? progType)
        {
            var priorAttainValues = new List<int> { 4, 5, 10, 11, 12, 13 };
            var rule = new PriorAttain_04Rule(null);

            foreach (var item in priorAttainValues)
            {
                rule.ConditionMet(item,35,progType).Should().BeTrue();
            }
        }

        [Theory]
        [InlineData(null,null,null)]
        [InlineData(null, 35, null)]
        [InlineData(null, 35, 2)]
        [InlineData(4, null, null)]
        [InlineData(4, null, 3)]
        [InlineData(4, 9999, 3)]
        public void RuleConditionMet_False(long? priorAttain, long? fundModel, long? progType)
        {
            var rule = new PriorAttain_04Rule(null);
            rule.ConditionMet(priorAttain,fundModel,progType).Should().BeFalse();
            
        }

        [Theory]
        [InlineData(null)]
        [InlineData(999)]
        public void PriorAttainConditionMet_False(long? priorAttain)
        {
            var rule = new PriorAttain_04Rule(null);
            rule.PriorAttainConditionMet(priorAttain).Should().BeFalse();

        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        [InlineData(13)]
        public void PriorAttainConditionMet_True(long? priorAttain)
        {
            var rule = new PriorAttain_04Rule(null);
            rule.PriorAttainConditionMet(priorAttain).Should().BeTrue();

        }


        [Theory]
        [InlineData(null)]
        [InlineData(999)]
        public void FundModelConditionMet_False(long? fundModel)
        {
            var rule = new PriorAttain_04Rule(null);
            rule.FundModelConditionMet(fundModel).Should().BeFalse();

        }

        [Theory]
        [InlineData(35)]
        public void FundModelConditionMet_True(long? fundModel)
        {
            var rule = new PriorAttain_04Rule(null);
            rule.FundModelConditionMet(fundModel).Should().BeTrue();

        }


        [Theory]
        [InlineData(null)]
        [InlineData(999)]
        public void ProgTypeConditionMet_False(long? progType)
        {
            var rule = new PriorAttain_04Rule(null);
            rule.ProgTypeConditionMet(progType).Should().BeFalse();

        }

        [Theory]
        [InlineData(3)]
        [InlineData(2)]
        public void ProgTypeConditionMet_True(long? progType)
        {
            var rule = new PriorAttain_04Rule(null);
            rule.ProgTypeConditionMet(progType).Should().BeTrue();

        }



        [Fact]
        public void Validate_Error()
        {
            var learner = SetupLearner(5);

            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("PriorAttain_04", null, null, null);

            var rule = new PriorAttain_04Rule(validationErrorHandlerMock.Object);
            rule.Validate(learner);
            validationErrorHandlerMock.Verify(handle, Times.Once);
        }

        [Fact]
        public void Validate_NoError()
        {
            MessageLearner learner = SetupLearner(999);
            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("PriorAttain_04", null, null, null);

            var rule = new PriorAttain_04Rule(validationErrorHandlerMock.Object);
            rule.Validate(learner);
            validationErrorHandlerMock.Verify(handle, Times.Never);
        }

        private  MessageLearner SetupLearner(long priorAttain)
        {
            var learner = new MessageLearner();
            learner.PriorAttainSpecified = true;
            learner.PriorAttain = priorAttain;

            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[] { },
                FundModel = 35,
                ProgType = 2,
                FundModelSpecified = true,
                ProgTypeSpecified = true
            };
            learner.LearningDelivery = new MessageLearnerLearningDelivery[] { learningDelivery };
            return learner;
        }
    }
}
