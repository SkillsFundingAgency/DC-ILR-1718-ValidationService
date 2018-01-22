using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Learner.ULN;
using FluentAssertions;
using Moq;
using System;
using System.Linq.Expressions;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Learner.ULN
{
    public class ULN_12RuleTests
    {
        [Fact]
        public void ConditionMet_True_NullULN()
        {
            var rule = new ULN_12Rule(null);

            rule.ConditionMet(true, null).Should().BeTrue();
        }

        [Fact]
        public void ConditionMet_True_TemporaryULN()
        {
            var rule = new ULN_12Rule(null);

            rule.ConditionMet(true, 9999999999).Should().BeTrue();
        }

        [Fact]
        public void ConditionMet_False_FAM()
        {
            var rule = new ULN_12Rule(null);

            rule.ConditionMet(false, 1).Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_False_ULN()
        {
            var rule = new ULN_12Rule(null);

            rule.ConditionMet(true, 1);
        }

        [Fact]
        public void Validate_NoError()
        {
            var learner = new MessageLearner()
            {
                ULN = 1,
                LearningDelivery = new MessageLearnerLearningDelivery[] { }                
            };

            var rule = new ULN_12Rule(null);

            rule.Validate(learner);
        }

        [Fact]
        public void Validate_Error()
        {
            {
                var learner = new MessageLearner()
                {
                    ULNSpecified = false,
                    LearningDelivery = new MessageLearnerLearningDelivery[]
                    {
                        new MessageLearnerLearningDelivery()
                        {
                            LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[]
                            {
                                new MessageLearnerLearningDeliveryLearningDeliveryFAM()
                                {
                                    LearnDelFAMType = "ACT",
                                    LearnDelFAMCode = "1"
                                }
                            }
                        }
                    }
                };

                var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();

                Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("ULN_12", null, null, null);

                validationErrorHandlerMock.Setup(handle);

                var rule = new ULN_12Rule(validationErrorHandlerMock.Object);

                rule.Validate(learner);

                validationErrorHandlerMock.Verify(handle, Times.Once);
            }
        }
    }
}
