using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Derived.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Learner.ULN;
using FluentAssertions;
using Moq;
using System;
using System.Linq.Expressions;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Learner.ULN
{
    public class ULN_04RuleTests
    {
        [Fact]
        public void ConditionMet_True()
        {
            var rule = new ULN_04Rule(null, null);

            rule.ConditionMet(1000000043, "N").Should().BeTrue();
        }

        [Fact]
        public void ConditionMet_False()
        {
            var rule = new ULN_04Rule(null, null);

            rule.ConditionMet(1000000004, "4").Should().BeFalse();
        }

        [Fact]
        public void Validate_NoErrors()
        {
            var learner = new MessageLearner()
            {
                ULN = 1000000043,
            };

            var dd01Mock = new Mock<IDD01>();

            dd01Mock.Setup(dd => dd.Derive(1000000043)).Returns("Y");

            var rule = new ULN_04Rule(dd01Mock.Object, null);

            rule.Validate(learner);
        }

        [Fact]
        public void Validate_Error()
        {
            var learner = new MessageLearner()
            {
                ULN = 1000000042,
            };

            var dd01Mock = new Mock<IDD01>();

            dd01Mock.Setup(dd => dd.Derive(1000000042)).Returns("N");

            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();

            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("ULN_04", null, null, null);

            validationErrorHandlerMock.Setup(handle);

            var rule = new ULN_04Rule(dd01Mock.Object, validationErrorHandlerMock.Object);

            rule.Validate(learner);

            validationErrorHandlerMock.Verify(handle, Times.Exactly(1));
        }
    }
}
