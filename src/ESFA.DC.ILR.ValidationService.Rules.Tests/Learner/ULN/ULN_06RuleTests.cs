﻿using ESFA.DC.ILR.Model;
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
    public class ULN_06RuleTests
    {
        [Theory]
        [InlineData("ACT", "1")]
        [InlineData("LDM", "034")]
        public void Exclude_True(string famType, string famCode)
        {
            var rule = new ULN_06Rule(null, null, null);

            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[]
                {
                    new MessageLearnerLearningDeliveryLearningDeliveryFAM()
                    {
                        LearnDelFAMType = famType,
                        LearnDelFAMCode = famCode
                    }
                }
            };

            rule.Exclude(learningDelivery).Should().BeTrue();
        }

        [Fact]
        public void Exclude_False_Null()
        {
            var rule = new ULN_06Rule(null, null, null);

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
            var rule = new ULN_06Rule(null, null, null);

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
        [InlineData(25, null)]
        [InlineData(82, null)]
        [InlineData(35, null)]
        [InlineData(36, null)]
        [InlineData(81, null)]
        [InlineData(70, null)]
        [InlineData(99, "1")]
        public void FundModelConditionMet_True(long fundModel, string adlFamCode)
        {
            var rule = new ULN_06Rule(null, null, null);

            rule.FundModelConditionMet(fundModel, adlFamCode).Should().BeTrue();
        }

        [Fact]
        public void FilePreparationDateMet_True()
        {
            var rule = new ULN_06Rule(null, null, null);

            rule.FilePreparationDateConditionMet(new DateTime(2030, 1, 1), new DateTime(2018, 1, 1)).Should().BeTrue();
        }

        [Fact]
        public void FilePreparationDateMet_False()
        {
            var rule = new ULN_06Rule(null, null, null);

            rule.FilePreparationDateConditionMet(new DateTime(2010, 1, 1), new DateTime(2018, 1, 1)).Should().BeFalse();
        }

        [Fact]
        public void LearningDatesConditionMet_True_LearnPlanEndDate()
        {
            var rule = new ULN_06Rule(null, null, null);

            rule.LearningDatesConditionMet(new DateTime(2018, 1, 1), new DateTime(2018, 1, 6), null, new DateTime(2017, 12, 31)).Should().BeTrue();
        }

        [Fact]
        public void LearningDatesConditionMet_True_LearnStartDate()
        {
            var rule = new ULN_06Rule(null, null, null);

            rule.LearningDatesConditionMet(new DateTime(2018, 1, 1), new DateTime(2017, 1, 6), new DateTime(2018, 1, 6), new DateTime(2017, 12, 31)).Should().BeTrue();
        }

        [Fact]
        public void LearningDatesConditionMet_False()
        {
            var rule = new ULN_06Rule(null, null, null);

            rule.LearningDatesConditionMet(new DateTime(2018, 1, 1), new DateTime(2017, 1, 6), new DateTime(2017, 1, 6), new DateTime(2017, 12, 31)).Should().BeFalse();
        }

        [Fact]
        public void LearningDatesConditionMet_FilePreparationDate_False()
        {
            var rule = new ULN_06Rule(null, null, null);

            rule.LearningDatesConditionMet(new DateTime(2018, 1, 1), new DateTime(2018, 1, 6), new DateTime(2018, 1, 6), new DateTime(2018, 6, 1)).Should().BeFalse();
        }

        [Fact]
        public void UlnConditionMet_True()
        {
            var rule = new ULN_06Rule(null, null, null);

            rule.UlnConditionMet(9999999999).Should().BeTrue();
        }

        [Fact]
        public void UlnConditionMet_False()
        {
            var rule = new ULN_06Rule(null, null, null);

            rule.UlnConditionMet(1).Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_True()
        {
            var rule = new ULN_06Rule(null, null, null);

            rule.ConditionMet(25, "1", 9999999999, new DateTime(2018, 1, 1), new DateTime(2018, 1, 1), new DateTime(2018, 1, 2), new DateTime(2017, 1, 7), new DateTime(2018, 1, 7)).Should().BeTrue();
        }

        [Fact]
        public void Validate_Errors()
        {
            var fileDataMock = new Mock<IFileDataService>();
            var validationDataMock = new Mock<IValidationDataService>();
            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            
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

            fileDataMock.SetupGet(fd => fd.FilePreparationDate).Returns(new DateTime(2018, 1, 1));
            validationDataMock.SetupGet(vd => vd.AcademicYearJanuaryFirst).Returns(new DateTime(2018, 1, 1));

            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("ULN_06", null, null, null);

            validationErrorHandlerMock.Setup(handle);

            var rule = new ULN_06Rule(fileDataMock.Object, validationDataMock.Object, validationErrorHandlerMock.Object);

            rule.Validate(learner);

            validationErrorHandlerMock.Verify(handle, Times.Exactly(1));
        }

        [Fact]
        public void Validate_NoErrors_FundModel()
        {
            var fileDataMock = new Mock<IFileDataService>();
            var validationDataMock = new Mock<IValidationDataService>();

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

            fileDataMock.SetupGet(fd => fd.FilePreparationDate).Returns(new DateTime(2018, 1, 1));
            validationDataMock.SetupGet(vd => vd.AcademicYearJanuaryFirst).Returns(new DateTime(2018, 1, 1));

            var rule = new ULN_06Rule(fileDataMock.Object, validationDataMock.Object, null);

            rule.Validate(learner);
        }
    }
}
