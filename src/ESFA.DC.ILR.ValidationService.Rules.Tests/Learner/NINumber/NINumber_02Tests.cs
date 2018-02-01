using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Learner.NiNumber;
using ESFA.DC.ILR.ValidationService.Rules.Query.Interface;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Learner.NINumber
{

    public class NINumber_02Tests
    {
        [Theory]
        [InlineData(" ")]
        [InlineData(null)]
        public void ConditionMet_True(string niNumber)
        {
            
            var rule = new NINumber_02Rule(null,null);
            rule.ConditionMet(niNumber,true).Should().BeTrue();
        }

        [Fact]
        public void ConditionMet_False_NonNullNiNumber()
        {
            var rule = new NINumber_02Rule(null, null);
            rule.ConditionMet("NINUMBER", true).Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_False_NotApplicableFAM()
        {
            var rule = new NINumber_02Rule(null, null);
            rule.ConditionMet(null, false).Should().BeFalse();
        }

       

        [Theory]
        [InlineData(" ","ACT","2")]
        [InlineData(null, "ACT", "2")]
        [InlineData(null, "XYZ", "1")]
        [InlineData("AZ123456C", "ACT", "1")]
        public void Validate_NoErrors(string niNumber, string famCode, string famType)
        {

            var learner = new MessageLearner();
            learner.NINumber = niNumber;

            var learningDeliveries = new MessageLearnerLearningDelivery()
            {
                LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[] { }
            };
            learner.LearningDelivery = new MessageLearnerLearningDelivery[] { learningDeliveries};
            
            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("NINumber_02", null, null, null);

            var famQueryService = new Mock<IMessageLearnerLearningDeliveryLearningDeliveryFAMQueryService>();

            famQueryService.Setup(qs => qs.HasLearningDeliveryFAMCodeForType(
                                        It.IsAny<IEnumerable<IMessageLearnerLearningDeliveryLearningDeliveryFAM>>(), famType, famCode))
                                        .Returns(famType=="ACT" && famCode=="1");


            var rule = new NINumber_02Rule(validationErrorHandlerMock.Object,famQueryService.Object);

            rule.Validate(learner);
            validationErrorHandlerMock.Verify(handle, Times.Never);

        }

        [Theory]
        [InlineData(" ")]
        [InlineData(null)]
        public void Validate_Error(string niNumber)
        {
            var learner = new MessageLearner();
            learner.NINumber = niNumber;

            var learningDeliveries = new MessageLearnerLearningDelivery()
            {
                LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[] { }
            };
            learner.LearningDelivery = new MessageLearnerLearningDelivery[] { learningDeliveries };

            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("NINumber_02", null, null, null);

            var famQueryService = new Mock<IMessageLearnerLearningDeliveryLearningDeliveryFAMQueryService>();

            famQueryService.Setup(qs => qs.HasLearningDeliveryFAMCodeForType(
                                        It.IsAny<IEnumerable<IMessageLearnerLearningDeliveryLearningDeliveryFAM>>(), "ACT", "1"))
                                        .Returns(true);


            var rule = new NINumber_02Rule(validationErrorHandlerMock.Object, famQueryService.Object);

            rule.Validate(learner);
            validationErrorHandlerMock.Verify(handle, Times.Once);
        }
    }
}
