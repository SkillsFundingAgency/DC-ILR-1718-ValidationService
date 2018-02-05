using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Learner.ULN;
using ESFA.DC.ILR.ValidationService.Rules.Query.Interface;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Learner.ULN
{
    public class ULN_02RuleTests
    {
        [Fact]
        public void Exclude_True()
        {
            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[] { }
            };

            var messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock = new Mock<IMessageLearnerLearningDeliveryLearningDeliveryFAMQueryService>();

            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasLearningDeliveryFAMCodeForType(learningDelivery.LearningDeliveryFAM, "SOF", "1")).Returns(true);

            var uln_02 = new ULN_02Rule(messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Object, null);

            uln_02.Exclude(learningDelivery).Should().BeTrue();
        }

        [Fact]
        public void Exclude_False()
        {
            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[] { }
            };

            var messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock = new Mock<IMessageLearnerLearningDeliveryLearningDeliveryFAMQueryService>();

            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasLearningDeliveryFAMCodeForType(learningDelivery.LearningDeliveryFAM, "SOF", "1")).Returns(false);

            var uln_02 = new ULN_02Rule(messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Object, null);

            uln_02.Exclude(learningDelivery).Should().BeFalse();
        }

        [Theory]
        [InlineData(99)]
        [InlineData(10)]
        public void ConditionMet_True(long fundModel)
        {
            var uln_02 = new ULN_02Rule(null, null);

            uln_02.ConditionMet(fundModel, 9999999999).Should().BeTrue();
        }

        [Fact]
        public void ConditionMet_False_Uln()
        {
            var uln_02 = new ULN_02Rule(null, null);

            uln_02.ConditionMet(10, 1).Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_False_FundModel()
        {
            var uln_02 = new ULN_02Rule(null, null);

            uln_02.ConditionMet(1, 9999999999).Should().BeFalse();
        }

        [Fact]
        public void Validate_NoErrors()
        {
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
            
            var messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock = new Mock<IMessageLearnerLearningDeliveryLearningDeliveryFAMQueryService>();

            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasLearningDeliveryFAMCodeForType(It.IsAny<IEnumerable<ILearningDeliveryFAM>>(), "SOF", "1")).Returns(false);

            var uln_02 = new ULN_02Rule(messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Object, null);

            uln_02.Validate(messageLearner);
        }

        [Fact]
        public void Validate_Errors()
        {
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


            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            var messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock = new Mock<IMessageLearnerLearningDeliveryLearningDeliveryFAMQueryService>();

            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasLearningDeliveryFAMCodeForType(It.IsAny<IEnumerable<ILearningDeliveryFAM>>(), "SOF", "1")).Returns(false);

            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("ULN_02", null, null, null);
            validationErrorHandlerMock.Setup(handle);

            var uln_02 = new ULN_02Rule(messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Object, validationErrorHandlerMock.Object);
            uln_02.Validate(messageLearner);

            validationErrorHandlerMock.Verify(handle, Times.Exactly(2));
        }
    }
}
