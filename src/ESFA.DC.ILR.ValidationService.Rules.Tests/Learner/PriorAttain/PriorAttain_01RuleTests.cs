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
    public class PriorAttain_01RuleTests
    {
        [Fact]
        public void ConditionMet_True()
        {
            var rule = new PriorAttain_01Rule(null, null);
            rule.ConditionMet(null).Should().BeTrue();
        }

        [Fact]
        public void ConditionMet_False()
        {
            var rule = new PriorAttain_01Rule(null, null);
            rule.ConditionMet(1).Should().BeFalse();
        }

        [Theory]
        [InlineData(100,"ACT","1")]
        [InlineData(50,"SOF","108")]
        [InlineData(99,"SOF","99")]
        [InlineData(99, "ACT", "108")]
        public void ExcludeCondition_False_FundModel(long? fundModel,string famType, string famCode)
        {

            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[] { },
                FundModel= fundModel ?? fundModel.Value,
                FundModelSpecified = fundModel.HasValue
            };

            var famQueryService = new Mock<ILearningDeliveryFAMQueryService>();

            famQueryService.Setup(qs => qs.HasLearningDeliveryFAMCodeForType(learningDelivery.LearningDeliveryFAM, famType, famCode)).Returns(false);

            var rule = new PriorAttain_01Rule(null, famQueryService.Object);
            rule.Exclude(learningDelivery).Should().BeFalse();
        }
        

        [Theory]
        [InlineData(10, "ACT", "1")]
        [InlineData(25, "ACT", "1")]
        [InlineData(82, "ACT", "1")]
        [InlineData(99, "SOF", "108")]
        public void ExcludeCondition_True(long? fundModel, string famType, string famCode)
        {

            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[] { },
                FundModel = fundModel ?? fundModel.Value,
                FundModelSpecified = fundModel.HasValue
            };

            var famQueryService = new Mock<ILearningDeliveryFAMQueryService>();

            famQueryService.Setup(qs => qs.HasLearningDeliveryFAMCodeForType(learningDelivery.LearningDeliveryFAM, famType, famCode)).Returns(famType=="SOF");

            var rule = new PriorAttain_01Rule(null, famQueryService.Object);
            rule.Exclude(learningDelivery).Should().BeTrue();
        }

        [Fact]
        public void Validate_Error()
        {
            var learner = new MessageLearner();
            learner.PriorAttainSpecified = false;
            learner.PriorAttain = 0;

            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[] { },
            };
            learner.LearningDelivery = new MessageLearnerLearningDelivery[] { learningDelivery };


            var famQueryService = new Mock<ILearningDeliveryFAMQueryService>();
            famQueryService.Setup(qs => qs.HasLearningDeliveryFAMCodeForType(learningDelivery.LearningDeliveryFAM, It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("PriorAttain_01", null, null, null);


            var rule = new PriorAttain_01Rule(validationErrorHandlerMock.Object, famQueryService.Object);
            rule.Validate(learner);
            validationErrorHandlerMock.Verify(handle, Times.Once);
        }

        [Fact]
        public void Validate_NoError()
        {
            var learner = new MessageLearner();
            learner.PriorAttainSpecified = true;
            learner.PriorAttain = 10;

            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[] { },
            };
            learner.LearningDelivery = new MessageLearnerLearningDelivery[] { learningDelivery };


            var famQueryService = new Mock<ILearningDeliveryFAMQueryService>();
            famQueryService.Setup(qs => qs.HasLearningDeliveryFAMCodeForType(learningDelivery.LearningDeliveryFAM, It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("PriorAttain_01", null, null, null);


            var rule = new PriorAttain_01Rule(validationErrorHandlerMock.Object, famQueryService.Object);
            rule.Validate(learner);
            validationErrorHandlerMock.Verify(handle, Times.Never);
        }

    }
}
