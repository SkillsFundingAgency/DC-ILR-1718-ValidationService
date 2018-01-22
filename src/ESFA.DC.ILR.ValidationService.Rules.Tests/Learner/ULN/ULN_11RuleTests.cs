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
    public class ULN_11RuleTests
    {
        [Fact]
        public void Exclude_True()
        {
            var rule = new ULN_11Rule(null, null, null);

            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[]
                {
                    new MessageLearnerLearningDeliveryLearningDeliveryFAM()
                    {
                        LearnDelFAMType = "LDM",
                        LearnDelFAMCode = "034"
                    }
                }
            };

            rule.Exclude(learningDelivery).Should().BeTrue();
        }

        [Fact]
        public void Exclude_False_Null()
        {
            var rule = new ULN_11Rule(null, null, null);

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
            var rule = new ULN_11Rule(null, null, null);

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

        [Fact]
        public void FundModelConditionMet_True()
        {
            var rule = new ULN_11Rule(null, null, null);

            rule.FundModelConditionMet(99).Should().BeTrue();
        }

        [Fact]
        public void FundModelConditionMet_False()
        {
            var rule = new ULN_11Rule(null, null, null);

            rule.FundModelConditionMet(98).Should().BeFalse();
        }
        
        [Fact]
        public void FAMConditionMet_True()
        {
            var rule = new ULN_11Rule(null, null, null);

            rule.FAMConditionMet(true).Should().BeTrue();            
        }

        [Fact]
        public void FAMConditionMet_False()
        {
            var rule = new ULN_11Rule(null, null, null);

            rule.FAMConditionMet(false).Should().BeFalse();
        }

        [Fact]
        public void FilePreparationDateMet_True()
        {
            var rule = new ULN_11Rule(null, null, null);

            rule.FilePreparationDateConditionMet(new DateTime(2030, 1, 1), new DateTime(2018, 1, 1)).Should().BeTrue();
        }

        [Fact]
        public void FilePreparationDateMet_False()
        {
            var rule = new ULN_11Rule(null, null, null);

            rule.FilePreparationDateConditionMet(new DateTime(2010, 1, 1), new DateTime(2018, 1, 1)).Should().BeFalse();
        }

        [Fact]
        public void LearningDatesConditionMet_True_LearnPlanEndDate()
        {
            var rule = new ULN_11Rule(null, null, null);

            rule.LearningDatesConditionMet(new DateTime(2018, 1, 1), new DateTime(2018, 1, 6), null, new DateTime(2018, 6, 1)).Should().BeTrue();
        }

        [Fact]
        public void LearningDatesConditionMet_True_LearnStartDate()
        {
            var rule = new ULN_11Rule(null, null, null);

            rule.LearningDatesConditionMet(new DateTime(2018, 1, 1), new DateTime(2017, 1, 6), new DateTime(2018, 1, 6), new DateTime(2018, 6, 1)).Should().BeTrue();
        }

        [Fact]
        public void LearningDatesConditionMet_False()
        {
            var rule = new ULN_11Rule(null, null, null);

            rule.LearningDatesConditionMet(new DateTime(2018, 1, 1), new DateTime(2017, 1, 6), new DateTime(2017, 1, 6), new DateTime(2017, 12, 31)).Should().BeFalse();
        }

        [Fact]
        public void LearningDatesConditionMet_FilePreparationDate_False()
        {
            var rule = new ULN_11Rule(null, null, null);

            rule.LearningDatesConditionMet(new DateTime(2018, 1, 1), new DateTime(2018, 1, 6), new DateTime(2018, 1, 6), new DateTime(2018, 1, 1)).Should().BeFalse();
        }

        [Fact]
        public void UlnConditionMet_True()
        {
            var rule = new ULN_11Rule(null, null, null);

            rule.UlnConditionMet(9999999999).Should().BeTrue();
        }

        [Fact]
        public void UlnConditionMet_False()
        {
            var rule = new ULN_11Rule(null, null, null);

            rule.UlnConditionMet(1).Should().BeFalse();
        }

        [Fact]
        public void ConditionMet_True()
        {
            var rule = new ULN_11Rule(null, null, null);

            rule.ConditionMet(99, true, 9999999999, new DateTime(2018, 6, 1), new DateTime(2018, 1, 1), new DateTime(2018, 1, 2), new DateTime(2017, 1, 7), new DateTime(2018, 1, 7)).Should().BeTrue();
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
                        FundModel = 99,
                        LearnStartDate = new DateTime(2018, 1, 2),
                        LearnStartDateSpecified = true,
                        LearnPlanEndDate = new DateTime(2017, 1, 7),
                        LearnPlanEndDateSpecified = true,
                        LearnActEndDate = new DateTime(2018, 1, 7),
                        LearnActEndDateSpecified = true,
                        LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[]
                        {
                            new MessageLearnerLearningDeliveryLearningDeliveryFAM()
                            {
                                LearnDelFAMType = "SOF",
                                LearnDelFAMCode = "1"
                            }
                        }
                    }
                }
            };

            fileDataMock.SetupGet(fd => fd.FilePreparationDate).Returns(new DateTime(2018, 6, 1));
            validationDataMock.SetupGet(vd => vd.AcademicYearJanuaryFirst).Returns(new DateTime(2018, 1, 1));

            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("ULN_11", null, null, null);

            validationErrorHandlerMock.Setup(handle);

            var rule = new ULN_11Rule(fileDataMock.Object, validationDataMock.Object, validationErrorHandlerMock.Object);

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

            var rule = new ULN_11Rule(fileDataMock.Object, validationDataMock.Object, null);

            rule.Validate(learner);
        }
    }
}
