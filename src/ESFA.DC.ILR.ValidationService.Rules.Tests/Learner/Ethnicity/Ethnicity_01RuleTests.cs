using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.Tests.Model;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Derived.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Learner.Ethnicity;
using ESFA.DC.ILR.ValidationService.Rules.Learner.PriorAttain;
using FluentAssertions;
using Moq;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Learner.Ethnicity
{
    public class Ethnicity_01RuleTests
    {
        private Ethnicity_01Rule NewRule(IValidationErrorHandler validationErrorHandler = null)
        {
            return new Ethnicity_01Rule(validationErrorHandler);
        }

        [Theory]
        [InlineData(100)]
        [InlineData(0)]
        public void ConditionMet_True(long? ethnicity)
        {
            var rule = new Ethnicity_01Rule(null);
            rule.ConditionMet(ethnicity).Should().BeTrue();
        }

        [Fact]
        public void ConditionMet_False()
        {
            var rule = new PriorAttain_01Rule(null, null);
            var validValues = new List<long?>() { 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 98, 99 };
            foreach (var validValue in validValues)
            {
                rule.ConditionMet(validValue).Should().BeFalse();
            }

        }

        [Fact]
        public void Validate_False()
        {
            var learner = new TestLearner()
            {
                EthnicityNullable = 10
            };
            
            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("Ethnicity_01", null, null, null);
            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();

            var rule = NewRule(validationErrorHandlerMock.Object);
            rule.Validate(learner);
            validationErrorHandlerMock.Verify(handle, Times.Once);
        }

        [Fact]
        public void Validate_True()
        {
            var learner = new TestLearner()
            {
                EthnicityNullable = 31
            };

            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("Ethnicity_01", null, null, null);
            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();

            var rule = NewRule(validationErrorHandlerMock.Object);
            rule.Validate(learner);
            validationErrorHandlerMock.Verify(handle, Times.Never);
        }
    }
}
