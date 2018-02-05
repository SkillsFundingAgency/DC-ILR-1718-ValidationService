﻿using ESFA.DC.ILR.Model;
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
    public class ULN_07RuleTests
    {
        [Fact]
        public void Exclude_True_LDM()
        {
            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[] { }
            };

            var messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock = new Mock<ILearningDeliveryFAMQueryService>();

            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasLearningDeliveryFAMCodeForType(learningDelivery.LearningDeliveryFAM, "LDM", "034")).Returns(true);

            var rule = new ULN_07Rule(null, null, messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Object, null);

            rule.Exclude(learningDelivery).Should().BeTrue();
        }

        [Fact]
        public void Exclude_True_ACT()
        {
            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[] { }
            };

            var messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock = new Mock<ILearningDeliveryFAMQueryService>();

            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasLearningDeliveryFAMCodeForType(learningDelivery.LearningDeliveryFAM, "LDM", "034")).Returns(false);
            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasLearningDeliveryFAMCodeForType(learningDelivery.LearningDeliveryFAM, "ACT", "1")).Returns(true);

            var rule = new ULN_07Rule(null, null, messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Object, null);

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
            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasLearningDeliveryFAMCodeForType(learningDelivery.LearningDeliveryFAM, "ACT", "1")).Returns(false);
                        
            var rule = new ULN_07Rule(null, null, messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Object, null);

            rule.Exclude(learningDelivery).Should().BeFalse();
        }

        [Theory]
        [InlineData(25, false)]
        [InlineData(82, false)]
        [InlineData(35, false)]
        [InlineData(36, false)]
        [InlineData(81, false)]
        [InlineData(70, false)]
        [InlineData(99, true)]
        public void FundModelConditionMet_True(long fundModel, bool adlFamCodeOne)
        {
            var rule = new ULN_07Rule(null, null, null, null);

            rule.FundModelConditionMet(fundModel, adlFamCodeOne).Should().BeTrue();
        }

        [Fact]
        public void FundModelConditionMet_False()
        {
            var rule = new ULN_07Rule(null, null, null, null);

            rule.FundModelConditionMet(1, false).Should().BeFalse();
        }

        [Fact]
        public void FilePreparationDateMet_True()
        {
            var rule = new ULN_07Rule(null, null, null, null);

            rule.FilePreparationDateConditionMet(new DateTime(2030, 1, 1), new DateTime(2018, 1, 1)).Should().BeTrue();
        }

        [Fact]
        public void FilePreparationDateMet_False()
        {
            var rule = new ULN_07Rule(null, null, null, null);

            rule.FilePreparationDateConditionMet(new DateTime(2010, 1, 1), new DateTime(2018, 1, 1)).Should().BeFalse();
        }

        [Fact]
        public void LearningDatesConditionMet_True_LearnPlanEndDate()
        {
            var rule = new ULN_07Rule(null, null, null, null);

            rule.LearningDatesConditionMet(new DateTime(2018, 1, 1), new DateTime(2018, 1, 6), null, new DateTime(2018, 12, 31)).Should().BeTrue();
        }

        [Fact]
        public void LearningDatesConditionMet_True_LearnStartDate()
        {
            var rule = new ULN_07Rule(null, null, null, null);

            rule.LearningDatesConditionMet(new DateTime(2018, 1, 1), new DateTime(2017, 1, 6), new DateTime(2018, 1, 6), new DateTime(2018, 6, 1)).Should().BeTrue();
        }

        [Fact]
        public void LearningDatesConditionMet_False()
        {
            var rule = new ULN_07Rule(null, null, null, null);

            rule.LearningDatesConditionMet(new DateTime(2018, 1, 1), new DateTime(2017, 1, 6), new DateTime(2017, 1, 6), new DateTime(2017, 12, 31)).Should().BeFalse();
        }

        [Fact]
        public void LearningDatesConditionMet_FilePreparationDate_False()
        {
            var rule = new ULN_07Rule(null, null, null, null);

            rule.LearningDatesConditionMet(new DateTime(2018, 1, 1), new DateTime(2018, 1, 6), new DateTime(2018, 1, 6), new DateTime(2017, 6, 1)).Should().BeFalse();
        }

        [Fact]
        public void UlnConditionMet_True()
        {
            var rule = new ULN_07Rule(null, null, null, null);

            rule.UlnConditionMet(9999999999).Should().BeTrue();
        }

        [Fact]
        public void UlnConditionMet_False()
        {
            var rule = new ULN_07Rule(null, null, null, null);

            rule.UlnConditionMet(1).Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_True()
        {
            var rule = new ULN_07Rule(null, null, null, null);

            rule.ConditionMet(25, true, 9999999999, new DateTime(2018, 1, 1), new DateTime(2018, 1, 1), new DateTime(2017, 6, 1), new DateTime(2017, 1, 7), new DateTime(2018, 1, 7)).Should().BeTrue();
        }

        [Fact]
        public void Validate_Errors()
        {
            var learner = new MessageLearner()
            {
                ULN = 9999999999,
                LearningDelivery = new MessageLearnerLearningDelivery[]
                {
                    new MessageLearnerLearningDelivery()
                    {
                        FundModel = 25,
                        LearnStartDate = new DateTime(2018, 1, 2),
                        LearnStartDateSpecified = true,
                        LearnPlanEndDate = new DateTime(2017, 1, 7),
                        LearnPlanEndDateSpecified = true,
                        LearnActEndDate = new DateTime(2018, 1, 7),
                        LearnActEndDateSpecified = true,
                    }
                }
            };

            var fileDataMock = new Mock<IFileDataService>();
            var validationDataMock = new Mock<IValidationDataService>();
            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            var messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock = new Mock<ILearningDeliveryFAMQueryService>();

            fileDataMock.SetupGet(fd => fd.FilePreparationDate).Returns(new DateTime(2018, 6, 1));
            validationDataMock.SetupGet(vd => vd.AcademicYearJanuaryFirst).Returns(new DateTime(2018, 1, 1));
            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasLearningDeliveryFAMCodeForType(It.IsAny<IEnumerable<ILearningDeliveryFAM>>(), "LDM", "034")).Returns(false);
            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasLearningDeliveryFAMCodeForType(It.IsAny<IEnumerable<ILearningDeliveryFAM>>(), "ACT", "1")).Returns(false);
            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasLearningDeliveryFAMCodeForType(It.IsAny<IEnumerable<ILearningDeliveryFAM>>(), "ADL", "1")).Returns(true);

            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("ULN_07", null, null, null);

            validationErrorHandlerMock.Setup(handle);

            var rule = new ULN_07Rule(fileDataMock.Object, validationDataMock.Object, messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Object, validationErrorHandlerMock.Object);

            rule.Validate(learner);

            validationErrorHandlerMock.Verify(handle, Times.Exactly(1));
        }

        [Fact]
        public void Validate_NoErrors_FundModel()
        {
            var learner = new MessageLearner()
            {
                ULN = 9999999999,
                LearningDelivery = new MessageLearnerLearningDelivery[]
                {
                    new MessageLearnerLearningDelivery()
                    {
                        FundModel = 100,
                        LearnStartDate = new DateTime(2018, 1, 2),
                        LearnStartDateSpecified = true,
                        LearnPlanEndDate = new DateTime(2017, 1, 7),
                        LearnPlanEndDateSpecified = true,
                        LearnActEndDate = new DateTime(2018, 1, 7),
                        LearnActEndDateSpecified = true,
                    }
                }
            };

            var fileDataMock = new Mock<IFileDataService>();
            var validationDataMock = new Mock<IValidationDataService>();
            var messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock = new Mock<ILearningDeliveryFAMQueryService>();

            fileDataMock.SetupGet(fd => fd.FilePreparationDate).Returns(new DateTime(2018, 1, 1));
            validationDataMock.SetupGet(vd => vd.AcademicYearJanuaryFirst).Returns(new DateTime(2018, 1, 1));
            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasLearningDeliveryFAMCodeForType(It.IsAny<IEnumerable<ILearningDeliveryFAM>>(), "LDM", "034")).Returns(false);
            messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Setup(qs => qs.HasLearningDeliveryFAMCodeForType(It.IsAny<IEnumerable<ILearningDeliveryFAM>>(), "ACT", "1")).Returns(false);

            var rule = new ULN_07Rule(fileDataMock.Object, validationDataMock.Object, messageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceMock.Object, null);

            rule.Validate(learner);
        }
    }
}
