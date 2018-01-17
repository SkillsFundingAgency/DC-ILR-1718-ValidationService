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
    public class ULN_02RuleTests
    {
        [Fact]
        public void Exclude_True()
        {
            var uln_02 = new ULN_02Rule(null);

            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[]
                {
                    new MessageLearnerLearningDeliveryLearningDeliveryFAM()
                    {
                        LearnDelFAMType = "SOF",
                        LearnDelFAMCode = "1"
                    }
                }
            };

            uln_02.Exclude(learningDelivery).Should().BeTrue();
        }

        [Fact]
        public void Exclude_False_Null()
        {
            var uln_02 = new ULN_02Rule(null);

            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[]
                {
                    new MessageLearnerLearningDeliveryLearningDeliveryFAM()
                    {
                        LearnDelFAMType = "No",
                        LearnDelFAMCode = "2"
                    }
                }
            };

            uln_02.Exclude(learningDelivery).Should().BeFalse();
        }

        [Fact]
        public void Exclude_False_NoMatch()
        {
            var uln_02 = new ULN_02Rule(null);

            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[]
                {
                    new MessageLearnerLearningDeliveryLearningDeliveryFAM()
                    {
                        LearnDelFAMType = "SOF",
                        LearnDelFAMCode = "2"
                    }
                }
            };

            uln_02.Exclude(learningDelivery).Should().BeFalse();
        }

        [Theory]
        [InlineData(99)]
        [InlineData(10)]
        public void ConditionMet_True(long fundModel)
        {
            var uln_02 = new ULN_02Rule(null);

            uln_02.ConditionMet(fundModel, 9999999999).Should().BeTrue();
        }

        [Fact]
        public void ConditionMet_False_Uln()
        {
            var uln_02 = new ULN_02Rule(null);

            uln_02.ConditionMet(10, 1).Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_False_FundModel()
        {
            var uln_02 = new ULN_02Rule(null);

            uln_02.ConditionMet(1, 9999999999).Should().BeFalse();
        }

        [Fact]
        public void Validate_NoErrors()
        {
            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();

            var uln_02 = new ULN_02Rule(validationErrorHandlerMock.Object);

            var messageLearner = new MessageLearner()
            {
                ULN = 1,
                LearningDelivery = new MessageLearnerLearningDelivery[]
                {
                    new MessageLearnerLearningDelivery()
                    {
                        FundModel = 2,
                    }
                }
            };

            uln_02.Validate(messageLearner);
        }

        [Fact]
        public void Validate_Errors()
        {
            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();

            var messageLearner = new MessageLearner()
            {
                ULN = 9999999999,
                LearningDelivery = new MessageLearnerLearningDelivery[]
                {
                    new MessageLearnerLearningDelivery()
                    {
                        FundModel = 10,
                    },
                    new MessageLearnerLearningDelivery()
                    {
                        FundModel = 99,
                    }
                }
            };

            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("ULN_02", null, null, null);

            validationErrorHandlerMock.Setup(handle);

            var uln_02 = new ULN_02Rule(validationErrorHandlerMock.Object);
            uln_02.Validate(messageLearner);

            validationErrorHandlerMock.Verify(handle, Times.Exactly(2));
        }
    }
}
