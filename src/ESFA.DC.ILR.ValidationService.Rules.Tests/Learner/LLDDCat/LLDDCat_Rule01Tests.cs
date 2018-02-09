using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.Tests.Model;
using ESFA.DC.ILR.ValidationService.ExternalData.LLDDCat.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Learner.LLDDCat;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Learner.LLDDCat
{
    public class LLDDCat_Rule01Tests
    {
        private LLDDCat_01Rule NewRule(IValidationErrorHandler validationErrorHandler = null, ILlddCatDataService llddCatDataService = null)
        {
            return new LLDDCat_01Rule(validationErrorHandler, llddCatDataService);
        }

        [Theory]
        [InlineData(18)]
        [InlineData(100)]
        [InlineData(0)]
        public void ConditionMet_True(long? category)
        {
            var lldCatServiceMock = new Mock<ILlddCatDataService>();
            lldCatServiceMock.Setup(x => x.CategoryExists(category)).Returns(false);
            var rule = NewRule(null, lldCatServiceMock.Object);

            rule.ConditionMet(category).Should().BeTrue();
        }

        [Fact]
        public void ConditionMet_False()
        {
            var lldCatServiceMock = new Mock<ILlddCatDataService>();
            lldCatServiceMock.Setup(x => x.CategoryExists(It.IsAny<long?>())).Returns(true);

            var rule = NewRule(null, lldCatServiceMock.Object);
            foreach (var num in Enumerable.Range(1, 17).Concat(Enumerable.Range(93, 7)))
            {
                rule.ConditionMet(num).Should().BeFalse();
            }
        }

        [Fact]
        public void ConditionMet_Null_False()
        {
            var rule = NewRule();
            rule.ConditionMet(null).Should().BeFalse();
        }

        [Fact]
        public void Validate_True()
        {
            var learner = new TestLearner()
            {
                LLDDAndHealthProblems = new List<ILLDDAndHealthProblem>()
                {
                    new TestLLDDAndHealthProblem()
                    {
                        LLDDCatNullable = 1
                    }
                }
            };

            var lldCatServiceMock = new Mock<ILlddCatDataService>();
            lldCatServiceMock.Setup(x => x.CategoryExists(1)).Returns(true);

            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("LLDDCat_01", null, null, null);

            var rule = NewRule(validationErrorHandlerMock.Object, lldCatServiceMock.Object);
            rule.Validate(learner);
            validationErrorHandlerMock.Verify(handle, Times.Never);
        }

        [Fact]
        public void Validate_False()
        {
            var learner = new TestLearner()
            {
                LLDDAndHealthProblems = new List<ILLDDAndHealthProblem>()
                {
                    new TestLLDDAndHealthProblem()
                    {
                        LLDDCatNullable = 20
                    }
                }
            };

            var lldCatServiceMock = new Mock<ILlddCatDataService>();
            lldCatServiceMock.Setup(x => x.CategoryExists(20)).Returns(false);

            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("LLDDCat_01", null, null, null);

            var rule = NewRule(validationErrorHandlerMock.Object, lldCatServiceMock.Object);
            rule.Validate(learner);
            validationErrorHandlerMock.Verify(handle, Times.Once);
        }
    }
}