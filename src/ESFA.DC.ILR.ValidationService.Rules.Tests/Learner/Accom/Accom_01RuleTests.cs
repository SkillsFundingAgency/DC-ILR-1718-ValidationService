using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Learner.Accom;
using ESFA.DC.ILR.ValidationService.Rules.Learner.PriorAttain;
using ESFA.DC.ILR.ValidationService.Rules.Query.Interface;
using FluentAssertions;
using Moq;
using System;
using System.Linq.Expressions;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Learner.Accom
{
    public class Accom_01RuleTests
    {
        [Fact]
        public void ConditionMet_True()
        {
            var rule = new Accom_01Rule(null);
            rule.ConditionMet(4).Should().BeTrue();
        }

        [Theory]
        [InlineData(null)]
        [InlineData(5)]
        public void ConditionMet_False(long? accomValue)
        {
            var rule = new Accom_01Rule(null);
            rule.ConditionMet(accomValue).Should().BeFalse();
        }

       

        [Fact]
        public void Validate_Error()
        {
            var learner = new MessageLearner
            {
                AccomSpecified = true,
                Accom= 11
            };

            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("Accom_01", null, null, null);


            var rule = new Accom_01Rule(validationErrorHandlerMock.Object);
            rule.Validate(learner);
            validationErrorHandlerMock.Verify(handle, Times.Once);
        }

        [Fact]
        public void Validate_NoError()
        {
            var learner = new MessageLearner
            {
                AccomSpecified = true,
                Accom = 5
            };

            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("Accom_01", null, null, null);


            var rule = new Accom_01Rule(validationErrorHandlerMock.Object);
            rule.Validate(learner);
            validationErrorHandlerMock.Verify(handle, Times.Never);
        }

    }
}
