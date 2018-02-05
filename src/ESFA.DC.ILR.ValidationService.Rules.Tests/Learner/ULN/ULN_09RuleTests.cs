using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.ExternalData.FileDataService.Interface;
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
    public class ULN_09RuleTests
    {
        [Fact]
        public void ConditionMet_True()
        {
            var rule = new ULN_09Rule(null, null, null, null);

            rule.ConditionMet(true, new DateTime(2018, 2, 1), new DateTime(2018, 1, 1), 9999999999).Should().BeTrue();
        }

        [Fact]
        public void ConditionMet_False_FamTypeCode()
        {
            var rule = new ULN_09Rule(null, null, null, null);

            rule.ConditionMet(false, new DateTime(2018, 2, 1), new DateTime(2018, 1, 1), 9999999999).Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_False_Uln()
        {
            var rule = new ULN_09Rule(null, null, null, null);

            rule.ConditionMet(true, new DateTime(2018, 2, 1), new DateTime(2018, 1, 1), 999999999).Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_False_Dates()
        {
            var rule = new ULN_09Rule(null, null, null, null);

            rule.ConditionMet(true, new DateTime(2018, 1, 1), new DateTime(2018, 2, 1), 999999999).Should().BeFalse();
        }

        [Fact]
        public void Validate_NoErrors()
        {
            var learner = new MessageLearner()
            {
                ULN = 1,
                ULNSpecified = true,
                LearningDelivery = new MessageLearnerLearningDelivery[] { }
            };

            var fileDataServiceMock = new Mock<IFileDataService>();
            var validationDataServiceMock = new Mock<IValidationDataService>();
            var messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock = new Mock<ILearningDeliveryFAMQueryService>();

            fileDataServiceMock.SetupGet(fds => fds.FilePreparationDate).Returns(new DateTime(2017, 1, 1));
            validationDataServiceMock.SetupGet(vds => vds.AcademicYearJanuaryFirst).Returns(new DateTime(2017, 1, 1));
            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasLearningDeliveryFAMCodeForType(It.IsAny<IEnumerable<ILearningDeliveryFAM>>(), "LDM", "034")).Returns(false);

            var rule = new ULN_09Rule(fileDataServiceMock.Object, validationDataServiceMock.Object, messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Object, null);

            rule.Validate(learner);
        }

        [Fact]
        public void Validate_Error()
        {
            var learner = new MessageLearner()
            {
                ULN = 9999999999,
                ULNSpecified = true,
                LearningDelivery = new MessageLearnerLearningDelivery[]
                {
                    new MessageLearnerLearningDelivery()
                    {
                        LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[] { }
                    }
                }
            };

            var fileDataServiceMock = new Mock<IFileDataService>();
            var validationDataServiceMock = new Mock<IValidationDataService>();
            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            var messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock = new Mock<ILearningDeliveryFAMQueryService>();

            fileDataServiceMock.SetupGet(fds => fds.FilePreparationDate).Returns(new DateTime(2017, 1, 1));
            validationDataServiceMock.SetupGet(vds => vds.AcademicYearJanuaryFirst).Returns(new DateTime(2017, 1, 1));
            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasLearningDeliveryFAMCodeForType(It.IsAny<IEnumerable<ILearningDeliveryFAM>>(), "LDM", "034")).Returns(true);

            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("ULN_09", null, null, null);

            validationErrorHandlerMock.Setup(handle);

            var rule = new ULN_09Rule(fileDataServiceMock.Object, validationDataServiceMock.Object, messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Object, validationErrorHandlerMock.Object);

            rule.Validate(learner);

            validationErrorHandlerMock.Verify(handle, Times.Once);
        }
    }
}
