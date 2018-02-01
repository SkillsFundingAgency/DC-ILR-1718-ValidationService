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
    public class PriorAttain_07RuleTests
    {

       
        [Fact]
        public void RuleConditionMet_True()
        {
            var priorAttainValues = new List<int> { 4, 5, 10, 11, 12, 13,97,98 };
            var rule = new PriorAttain_07Rule(null);

            foreach (var item in priorAttainValues)
            {
                rule.ConditionMet(item,35,24,new DateTime(2016,8,01)).Should().BeTrue();
            }
        }

        [Fact]
        public void RuleConditionMet_False()
        {
            var priorAttainValues = new List<int> { 4, 5, 10, 11, 12, 13,97,98 };
            var rule = new PriorAttain_07Rule(null);

            foreach (var item in priorAttainValues)
            {
                rule.ConditionMet(item, 35, 10, new DateTime(2016, 8, 01)).Should().BeFalse();
            }
        }

        [Theory]
        [InlineData(null)]
        [InlineData(999)]
        public void PriorAttainConditionMet_False(long? priorAttain)
        {
            var rule = new PriorAttain_07Rule(null);
            rule.PriorAttainConditionMet(priorAttain).Should().BeFalse();

        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        [InlineData(13)]
        [InlineData(97)]
        [InlineData(98)]
        public void PriorAttainConditionMet_True(long? priorAttain)
        {
            var rule = new PriorAttain_07Rule(null);
            rule.PriorAttainConditionMet(priorAttain).Should().BeTrue();

        }


        [Theory]
        [InlineData(null)]
        [InlineData(999)]
        public void FundModelConditionMet_False(long? fundModel)
        {
            var rule = new PriorAttain_07Rule(null);
            rule.FundModelConditionMet(fundModel).Should().BeFalse();

        }

        [Theory]
        [InlineData(35)]
        public void FundModelConditionMet_True(long? fundModel)
        {
            var rule = new PriorAttain_07Rule(null);
            rule.FundModelConditionMet(fundModel).Should().BeTrue();

        }


        [Theory]
        [InlineData(null)]
        [InlineData(999)]
        public void ProgTypeConditionMet_False(long? progType)
        {
            var rule = new PriorAttain_07Rule(null);
            rule.ProgTypeConditionMet(progType).Should().BeFalse();

        }


        [Fact]
        public void ProgTypeConditionMet_True()
        {
            var rule = new PriorAttain_07Rule(null);
            rule.ProgTypeConditionMet(24).Should().BeTrue();

        }

        [Theory]
        [InlineData(null)]
        [InlineData("2015-07-31")]
        public void LearnStartDateConditionMet_False(string learnStartDateString)
        {
            var rule = new PriorAttain_07Rule(null);
            var learnStartDate = !string.IsNullOrEmpty(learnStartDateString) ? (DateTime?)DateTime.ParseExact(learnStartDateString, "yyyy-MM-dd",null) : null ;
            rule.LearnStartDateConditionMet(learnStartDate).Should().BeFalse();

        }


        [Fact]
        public void LearnStartDateConditionMet_True()
        {
            var rule = new PriorAttain_07Rule(null);
            rule.LearnStartDateConditionMet(new DateTime(2016,08,01)).Should().BeTrue();

        }



        [Fact]
        public void Validate_Error()
        {
            var learner = SetupLearner(5,new DateTime(2016,08,02));
            
            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("PriorAttain_07", null, null, null);


            var rule = new PriorAttain_07Rule(validationErrorHandlerMock.Object);
            rule.Validate(learner);
            validationErrorHandlerMock.Verify(handle, Times.Once);
        }

        [Fact]
        public void Validate_NoError()
        {
            MessageLearner learner = SetupLearner(999, new DateTime(2015,07,31));
            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("PriorAttain_07", null, null, null);

            var rule = new PriorAttain_07Rule(validationErrorHandlerMock.Object);
            rule.Validate(learner);
            validationErrorHandlerMock.Verify(handle, Times.Never);
        }

        private  MessageLearner SetupLearner(long priorAttain, DateTime learnStartDate)
        {
            var learner = new MessageLearner();
            learner.PriorAttainSpecified = true;
            learner.PriorAttain = priorAttain;

            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[] { },
                FundModel = 35,
                ProgType = 24,
                LearnStartDate=learnStartDate,
                LearnStartDateSpecified = true,
                FundModelSpecified = true,
                ProgTypeSpecified = true
            };
            learner.LearningDelivery = new MessageLearnerLearningDelivery[] { learningDelivery };
            return learner;
        }
    }
}
