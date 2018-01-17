using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.ExternalData.FileDataService.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Learner.ULN;
using FluentAssertions;
using Moq;
using System;
using System.Linq.Expressions;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Learner.ULN
{
    public class ULN_03RuleTests
    {
        [Fact]
        public void Exclude_True()
        {
            var rule = new ULN_03Rule(null, null, null);

            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[]
                {
                    new MessageLearnerLearningDeliveryLearningDeliveryFAM()
                    {
                        LearnDelFAMType = "ACT",
                        LearnDelFAMCode = "1"
                    }
                }
            };

            rule.Exclude(learningDelivery).Should().BeTrue();
        }

        [Fact]
        public void Exclude_False_Null()
        {
            var rule = new ULN_03Rule(null, null, null);

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

            rule.Exclude(learningDelivery).Should().BeFalse();
        }

        [Fact]
        public void Exclude_False_NoMatch()
        {
            var rule = new ULN_03Rule(null, null, null);

            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[]
                {
                    new MessageLearnerLearningDeliveryLearningDeliveryFAM()
                    {
                        LearnDelFAMType = "ACT",
                        LearnDelFAMCode = "2"
                    }
                }
            };

            rule.Exclude(learningDelivery).Should().BeFalse();
        }

        [Theory]
        [InlineData(25)]
        [InlineData(82)]
        [InlineData(35)]
        [InlineData(36)]
        [InlineData(81)]
        [InlineData(70)]
        public void ConditionMet_True(long fundModel)
        {
            var rule = new ULN_03Rule(null, null, null);

            rule.ConditionMet(fundModel, 9999999999, new DateTime(1970, 1, 1), new DateTime(2018, 1, 1)).Should().BeTrue();
        }

        [Fact]
        public void ConditionMet_False_Uln()
        {
            var rule = new ULN_03Rule(null, null, null);

            rule.ConditionMet(25, 1, new DateTime(1970, 1, 1), new DateTime(2018, 1, 1)).Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_False_FundModel()
        {
            var rule = new ULN_03Rule(null, null, null);

            rule.ConditionMet(1, 9999999999, new DateTime(1970, 1, 1), new DateTime(2018, 1, 1)).Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_False_FilePreparationDate()
        {
            var rule = new ULN_03Rule(null, null, null);

            rule.ConditionMet(25, 9999999999, new DateTime(2030, 1, 1), new DateTime(2018, 1, 1)).Should().BeFalse();
        }

        [Fact]
        public void Validate_NoErrors()
        {
            var fileDataServiceMock = new Mock<IFileDataService>();
            var validationDataServiceMock = new Mock<IValidationDataService>();
            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();

            fileDataServiceMock.SetupGet(fd => fd.FilePreparationDate).Returns(new DateTime(1970, 1, 1));
            validationDataServiceMock.SetupGet(vd => vd.AcademicYearJanuaryFirst).Returns(new DateTime(2018, 1, 1));

            var rule = new ULN_03Rule(fileDataServiceMock.Object, validationDataServiceMock.Object, validationErrorHandlerMock.Object);

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

            rule.Validate(messageLearner);
        }

        [Fact]
        public void Validate_Errors()
        {
            var fileDataServiceMock = new Mock<IFileDataService>();
            var validationDataServiceMock = new Mock<IValidationDataService>();
            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();

            fileDataServiceMock.SetupGet(fd => fd.FilePreparationDate).Returns(new DateTime(1970, 1, 1));
            validationDataServiceMock.SetupGet(vd => vd.AcademicYearJanuaryFirst).Returns(new DateTime(2018, 1, 1));

            var messageLearner = new MessageLearner()
            {
                ULN = 9999999999,
                LearningDelivery = new MessageLearnerLearningDelivery[]
                {
                    new MessageLearnerLearningDelivery()
                    {
                        FundModel = 25,
                    },
                    new MessageLearnerLearningDelivery()
                    {
                        FundModel = 36,
                    }
                }
            };

            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("ULN_03", null, null, null);

            validationErrorHandlerMock.Setup(handle);

            var rule = new ULN_03Rule(fileDataServiceMock.Object, validationDataServiceMock.Object, validationErrorHandlerMock.Object);
            rule.Validate(messageLearner);

            validationErrorHandlerMock.Verify(handle, Times.Exactly(2));
        }
    }
}
