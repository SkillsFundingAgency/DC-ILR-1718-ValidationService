using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.ExternalData.PriorAttain;
using ESFA.DC.ILR.ValidationService.ExternalData.PriorAttain.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Learner.PriorAttain;
using FluentAssertions;
using Moq;
using System;
using System.Linq.Expressions;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Learner.PriorAttain
{
    public class PriorAttain_03RuleTests
    {

        private readonly IPriorAttainReferenceDataService  _priorAttainReferenceService = new PriorAttainReferenceDataService();

        
        [Theory]
        [InlineData(100)]
        [InlineData(29)]
        [InlineData(90)]
        public void ConditionMet_True(long attainValue)
        {
            var rule = new PriorAttain_03Rule(null, _priorAttainReferenceService);
            rule.ConditionMet(attainValue).Should().BeTrue();
            
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        [InlineData(13)]
        [InlineData(97)]
        [InlineData(98)]
        public void ConditionMet_False(long attainValue)
        {
            var rule = new PriorAttain_03Rule(null, _priorAttainReferenceService);
           
            rule.ConditionMet(attainValue).Should().BeFalse();

        }

       

        [Fact]
        public void Validate_Error()
        {
            var learner = new MessageLearner
            {
                PriorAttainSpecified = true,
                PriorAttain = 100
            };

            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("PriorAttain_03", null, null, null);


            var rule = new PriorAttain_03Rule(validationErrorHandlerMock.Object, _priorAttainReferenceService);
            rule.Validate(learner);
            validationErrorHandlerMock.Verify(handle, Times.Once);
        }

        [Fact]
        public void Validate_NoError()
        {
            var learner = new MessageLearner
            {
                PriorAttainSpecified = true,
                PriorAttain = 11
            };

            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("PriorAttain_03", null, null, null);


            var rule = new PriorAttain_03Rule(validationErrorHandlerMock.Object, _priorAttainReferenceService);
            rule.Validate(learner);
            validationErrorHandlerMock.Verify(handle, Times.Never);
        }

    }
}
