using ESFA.DC.ILR.Model.Tests.Abstract;
using FluentAssertions;
using System;
using Xunit;

namespace ESFA.DC.ILR.Model.Tests
{
    public class MessageLearnerLearningDeliveryTests : AbstractModelTests<MessageLearnerLearningDelivery>
    {
        [Fact]
        public void AchDateNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(ld => ld.AchDate, DateTime(), ld => ld.AchDateSpecified, ld => ld.AchDateNullable);
        }

        [Fact]
        public void AchDateNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(ld => ld.AchDate, DateTime(), ld => ld.AchDateSpecified, ld => ld.AchDateNullable);
        }

        [Fact]
        public void AddHoursNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(ld => ld.AddHours, Long(), ld => ld.AddHoursSpecified, ld => ld.AddHoursNullable);
        }

        [Fact]
        public void AddHoursNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(ld => ld.AddHours, Long(), ld => ld.AddHoursSpecified, ld => ld.AddHoursNullable);
        }

        [Fact]
        public void AimSeqNumberNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(ld => ld.AimSeqNumber, Long(), ld => ld.AimSeqNumberSpecified, ld => ld.AimSeqNumberNullable);
        }

        [Fact]
        public void AimSeqNumberNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(ld => ld.AimSeqNumber, Long(), ld => ld.AimSeqNumberSpecified, ld => ld.AimSeqNumberNullable);
        }

        [Fact]
        public void AimTypeNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(ld => ld.AimType, Long(), ld => ld.AimTypeSpecified, ld => ld.AimTypeNullable);
        }

        [Fact]
        public void AimTypeNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(ld => ld.AimType, Long(), ld => ld.AimTypeSpecified, ld => ld.AimTypeNullable);
        }

        [Fact]
        public void CompStatusNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(ld => ld.CompStatus, Long(), ld => ld.CompStatusSpecified, ld => ld.CompStatusNullable);
        }        

        [Fact]
        public void CompStatusNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(ld => ld.CompStatus, Long(), ld => ld.CompStatusSpecified, ld => ld.CompStatusNullable);
        }

        [Fact]
        public void EmpOutcomeNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(ld => ld.EmpOutcome, Long(), ld => ld.EmpOutcomeSpecified, ld => ld.EmpOutcomeNullable);
        }

        [Fact]
        public void EmpOutcomeNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(ld => ld.EmpOutcome, Long(), ld => ld.EmpOutcomeSpecified, ld => ld.EmpOutcomeNullable);
        }

        [Fact]
        public void FundModelNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(ld => ld.FundModel, Long(), ld => ld.FundModelSpecified, ld => ld.CompStatusNullable);
        }

        [Fact]
        public void FundModelNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(ld => ld.FundModel, Long(), ld => ld.FundModelSpecified, ld => ld.FundModelNullable);
        }

        [Fact]
        public void FworkCodeNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(ld => ld.FworkCode, Long(), ld => ld.FworkCodeSpecified, ld => ld.FworkCodeNullable);            
        }

        [Fact]
        public void FworkCodeNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(ld => ld.FworkCode, Long(), ld => ld.FworkCodeSpecified, ld => ld.FworkCodeNullable);
        }

        [Fact]
        public void LearnActEndDateNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(ld => ld.LearnActEndDate, DateTime(), ld => ld.LearnActEndDateSpecified, ld => ld.LearnActEndDateNullable);
        }

        [Fact]
        public void LearnActEndDateNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(ld => ld.LearnActEndDate, DateTime(), ld => ld.LearnActEndDateSpecified, ld => ld.LearnActEndDateNullable);
        }

        [Fact]
        public void LearnPlanEndDateNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(ld => ld.LearnPlanEndDate, DateTime(), ld => ld.LearnPlanEndDateSpecified, ld => ld.LearnPlanEndDateNullable);
        }

        [Fact]
        public void LearnPlanEndDateNullable_Specified_True()
        {
            TestNullableSpecifiedFalse(ld => ld.LearnPlanEndDate, DateTime(), ld => ld.LearnPlanEndDateSpecified, ld => ld.LearnPlanEndDateNullable);
        }

        [Fact]
        public void LearnStartDateNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(ld => ld.LearnStartDate, DateTime(), ld => ld.LearnStartDateSpecified, ld => ld.LearnStartDateNullable);       
        }

        [Fact]
        public void LearnStartDateNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(ld => ld.LearnStartDate, DateTime(), ld => ld.LearnStartDateSpecified, ld => ld.LearnStartDateNullable);
        }

        [Fact]
        public void OrigLearnStartDateNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(ld => ld.OrigLearnStartDate, DateTime(), ld => ld.OrigLearnStartDateSpecified, ld => ld.OrigLearnStartDateNullable);
        }

        [Fact]
        public void OrigLearnStartDateNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(ld => ld.OrigLearnStartDate, DateTime(), ld => ld.OrigLearnStartDateSpecified, ld => ld.OrigLearnStartDateNullable);
        }

        [Fact]
        public void OtherFundAdjNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(ld => ld.OtherFundAdj, Long(), ld => ld.OtherFundAdjSpecified, ld => ld.OtherFundAdjNullable);
        }

        [Fact]
        public void OtherFundAdjNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(ld => ld.OtherFundAdj, Long(), ld => ld.OtherFundAdjSpecified, ld => ld.OtherFundAdjNullable);
        }

        [Fact]
        public void OutcomeNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(ld => ld.Outcome, Long(), ld => ld.OutcomeSpecified, ld => ld.OutcomeNullable);
        }

        [Fact]
        public void OutcomeNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(ld => ld.Outcome, Long(), ld => ld.OutcomeSpecified, ld => ld.OutcomeNullable);
        }

        [Fact]
        public void PartnerUKPRNNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(ld => ld.PartnerUKPRN, Long(), ld => ld.PartnerUKPRNSpecified, ld => ld.PartnerUKPRNNullable);
        }

        [Fact]
        public void PartnerUKPRNNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(ld => ld.PartnerUKPRN, Long(), ld => ld.PartnerUKPRNSpecified, ld => ld.PartnerUKPRNNullable);
        }

        [Fact]
        public void PriorLearnFundAdjNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(ld => ld.PriorLearnFundAdj, Long(), ld => ld.PriorLearnFundAdjSpecified, ld => ld.PriorLearnFundAdjNullable);
        }

        [Fact]
        public void PriorLearnFundAdjNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(ld => ld.PriorLearnFundAdj, Long(), ld => ld.PriorLearnFundAdjSpecified, ld => ld.PriorLearnFundAdjNullable);
        }
        
        [Fact]
        public void ProgTypeNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(ld => ld.ProgType, Long(), ld => ld.ProgTypeSpecified, ld => ld.ProgTypeNullable);
        }

        [Fact]
        public void ProgTypeNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(ld => ld.ProgType, Long(), ld => ld.ProgTypeSpecified, ld => ld.ProgTypeNullable);
        }
        
        [Fact]
        public void PwayCodeNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(ld => ld.PwayCode, Long(), ld => ld.PwayCodeSpecified, ld => ld.PwayCodeNullable);
        }

        [Fact]
        public void PwayCodeNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(ld => ld.PwayCode, Long(), ld => ld.PwayCodeSpecified, ld => ld.PwayCodeNullable);
        }

        [Fact]
        public void StdCodeNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(ld => ld.StdCode, Long(), ld => ld.StdCodeSpecified, ld => ld.StdCodeNullable);
        }

        [Fact]
        public void StdCodeNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(ld => ld.StdCode, Long(), ld => ld.StdCodeSpecified, ld => ld.StdCodeNullable);
        }

        [Fact]
        public void WithdrawReasonNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(ld => ld.WithdrawReason, Long(), ld => ld.WithdrawReasonSpecified, ld => ld.WithdrawReasonNullable);
        }

        [Fact]
        public void WithdrawReasonNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(ld => ld.WithdrawReason, Long(), ld => ld.WithdrawReasonSpecified, ld => ld.WithdrawReasonNullable);
        }

        [Fact]
        public void AppFinRecords()
        {
            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                AppFinRecord = new MessageLearnerLearningDeliveryAppFinRecord[]
                {
                    new MessageLearnerLearningDeliveryAppFinRecord()
                }
            };

            learningDelivery.AppFinRecords.Should().BeSameAs(learningDelivery.AppFinRecord);
            learningDelivery.AppFinRecords.Should().HaveCount(1);
        }

        [Fact]
        public void LearningDeliveryFAMs()
        {
            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[]
                {
                    new MessageLearnerLearningDeliveryLearningDeliveryFAM()
                }
            };

            learningDelivery.LearningDeliveryFAMs.Should().BeSameAs(learningDelivery.LearningDeliveryFAM);
            learningDelivery.LearningDeliveryFAMs.Should().HaveCount(1);
        }
        
        [Fact]
        public void LearningDeliveryHEs()
        {
            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                LearningDeliveryHE = new MessageLearnerLearningDeliveryLearningDeliveryHE[]
                {
                    new MessageLearnerLearningDeliveryLearningDeliveryHE()
                }
            };

            learningDelivery.LearningDeliveryHEs.Should().BeSameAs(learningDelivery.LearningDeliveryHE);
            learningDelivery.LearningDeliveryHEs.Should().HaveCount(1);
        }
        
        [Fact]
        public void LearningDeliveryWorkPlacements()
        {
            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                LearningDeliveryWorkPlacement = new MessageLearnerLearningDeliveryLearningDeliveryWorkPlacement[]
                {
                    new MessageLearnerLearningDeliveryLearningDeliveryWorkPlacement()
                }
            };

            learningDelivery.LearningDeliveryWorkPlacements.Should().BeSameAs(learningDelivery.LearningDeliveryWorkPlacement);
            learningDelivery.LearningDeliveryWorkPlacements.Should().HaveCount(1);
        }
        
        [Fact]
        public void ProviderSpecDeliveryMonitorings()
        {
            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                ProviderSpecDeliveryMonitoring = new MessageLearnerLearningDeliveryProviderSpecDeliveryMonitoring[]
                {
                    new MessageLearnerLearningDeliveryProviderSpecDeliveryMonitoring()
                }
            };

            learningDelivery.ProviderSpecDeliveryMonitorings.Should().BeSameAs(learningDelivery.ProviderSpecDeliveryMonitoring);
            learningDelivery.ProviderSpecDeliveryMonitorings.Should().HaveCount(1);
        }        
    }
}
