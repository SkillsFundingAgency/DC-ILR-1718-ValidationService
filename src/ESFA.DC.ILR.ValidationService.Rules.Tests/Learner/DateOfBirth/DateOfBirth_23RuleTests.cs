using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Learner.DateOfBirth;
using ESFA.DC.ILR.ValidationService.Rules.Query.Interface;
using FluentAssertions;
using Moq;
using System;
using System.Linq.Expressions;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Learner.DateOfBirth
{
    public class DateOfBirth_23RuleTests
    {
        private DateOfBirth_23Rule NewRule(ILearningDeliveryFAMQueryService messageLearnerLearningDeliveryLearningDeliveryFAMQueryService = null, IValidationErrorHandler validationErrorHandler = null)
        {
            return new DateOfBirth_23Rule(messageLearnerLearningDeliveryLearningDeliveryFAMQueryService, validationErrorHandler);
        }

        [Fact]
        public void Exclude_True()
        {
            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[] { }
            };
            
            var messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock = new Mock<ILearningDeliveryFAMQueryService>();

            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasLearningDeliveryFAMCodeForType(learningDelivery.LearningDeliveryFAM, "LDM", "034")).Returns(true);

            var rule = NewRule(messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Object);

            rule.Exclude(learningDelivery).Should().BeTrue();
        }

        [Fact]
        public void Exclude_False()
        {
            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[] { }
            };

            var messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock = new Mock<ILearningDeliveryFAMQueryService>();

            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasLearningDeliveryFAMCodeForType(learningDelivery.LearningDeliveryFAM, "LDM", "034")).Returns(false);

            var rule = NewRule(messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Object);

            rule.Exclude(learningDelivery).Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_True()
        {
            var rule = NewRule();

            rule.ConditionMet(null, 99, true).Should().BeTrue();
        }

        [Fact]
        public void ConditionMet_False_DateOfBirth_NotNull()
        {
            var rule = NewRule();

            rule.ConditionMet(new DateTime(2009, 1, 1), 99, true).Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_False_FundModel_Null()
        {
            var rule = NewRule();

            rule.ConditionMet(null, null, true).Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_False_FundModel_Mismatch()
        {
            var rule = NewRule();

            rule.ConditionMet(null, 98, true).Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_False_FAM()
        {
            var rule = NewRule();

            rule.ConditionMet(null, 99, false).Should().BeFalse();
        }

        [Fact]
        public void Validate_Error()
        {
            var learningDeliveryFAMs = new MessageLearnerLearningDeliveryLearningDeliveryFAM[] { };

            var learner = new MessageLearner()
            {
                DateOfBirthSpecified = false,
                LearningDelivery = new MessageLearnerLearningDelivery[]
                {
                    new MessageLearnerLearningDelivery()
                    {
                        FundModelSpecified = true,
                        FundModel = 99,
                        LearningDeliveryFAM = learningDeliveryFAMs
                    }
                }
            };

            var messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock = new Mock<ILearningDeliveryFAMQueryService>();
            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();

            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasLearningDeliveryFAMCodeForType(learningDeliveryFAMs, "LDM", "034")).Returns(false);
            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasLearningDeliveryFAMType(learningDeliveryFAMs, "ADL")).Returns(true);
            
            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("DateOfBirth_23", null, null, null);

            validationErrorHandlerMock.Setup(handle);

            var rule = NewRule(messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Object, validationErrorHandlerMock.Object);

            rule.Validate(learner);

            validationErrorHandlerMock.Verify(handle, Times.Once);
        }

        [Fact]
        public void Validate_NoErrors()
        {
            var learningDeliveryFAMs = new MessageLearnerLearningDeliveryLearningDeliveryFAM[] { };

            var learner = new MessageLearner()
            {
                DateOfBirthSpecified = true,
                DateOfBirth = new DateTime(1990, 1, 1),
                LearningDelivery = new MessageLearnerLearningDelivery[]
                {
                    new MessageLearnerLearningDelivery()
                    {
                        FundModelSpecified = true,
                        FundModel = 99,
                        LearningDeliveryFAM = learningDeliveryFAMs
                    }
                }
            };

            var messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock = new Mock<ILearningDeliveryFAMQueryService>();

            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasLearningDeliveryFAMCodeForType(learningDeliveryFAMs, "LDM", "034")).Returns(false);
            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasLearningDeliveryFAMType(learningDeliveryFAMs, "ADL")).Returns(true);

            var rule = NewRule(messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Object);

            rule.Validate(learner);
        }
    }
}
