using ESFA.DC.ILR.Model.Tests.Abstract;
using FluentAssertions;
using System;
using Xunit;

namespace ESFA.DC.ILR.Model.Tests
{
    public class MessageLearnerTests : AbstractModelTests<MessageLearner>
    {
        [Fact]
        public void AccomNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.Accom, Long(), l => l.AccomSpecified, l => l.AccomNullable);
        }

        [Fact]
        public void AccomNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.Accom, Long(), l => l.AccomSpecified, l => l.AccomNullable);
        }

        [Fact]
        public void ALSCostNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.ALSCost, Long(), l => l.ALSCostSpecified, l => l.ALSCostNullable);
        }

        [Fact]
        public void ALSCostNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.ALSCost, Long(), l => l.ALSCostSpecified, l => l.ALSCostNullable);
        }
        
        [Fact]
        public void DateOfBirthNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.DateOfBirth, DateTime(), l => l.DateOfBirthSpecified, l => l.DateOfBirthNullable);
        }
            
        [Fact]
        public void DateOfBirthNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.DateOfBirth, DateTime(), l => l.DateOfBirthSpecified, l => l.DateOfBirthNullable);
        }

        [Fact]
        public void EthnicityNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.Ethnicity, Long(), l => l.EthnicitySpecified, l => l.EthnicityNullable);
        }

        [Fact]
        public void EthnicityNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.Ethnicity, Long(), l => l.EthnicitySpecified, l => l.EthnicityNullable);
        }

        [Fact]
        public void LLDDHealthProbNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.LLDDHealthProb, Long(), l => l.LLDDHealthProbSpecified, l => l.LLDDHealthProbNullable);
        }

        [Fact]
        public void LLDDHealthProbNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.LLDDHealthProb, Long(), l => l.LLDDHealthProbSpecified, l => l.LLDDHealthProbNullable);
        }

        [Fact]
        public void PMUKPRNNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.PMUKPRN, Long(), l => l.PMUKPRNSpecified, l => l.PMUKPRNNullable);
        }

        [Fact]
        public void PMUKPRNNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.PMUKPRN, Long(), l => l.PMUKPRNSpecified, l => l.PMUKPRNNullable);
        }

        [Fact]
        public void PrevUKPRNNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.PrevUKPRN, Long(), l => l.PrevUKPRNSpecified, l => l.PrevUKPRNNullable);            
        }  

        [Fact]
        public void PrevUKPRNNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.PrevUKPRN, Long(), l => l.PrevUKPRNSpecified, l => l.PrevUKPRNNullable);
        }
        
        [Fact]
        public void PlanEEPHoursNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.PlanEEPHours, Long(), l => l.PlanEEPHoursSpecified, l => l.PlanEEPHoursNullable);
        }

        [Fact]
        public void PlanEEPHoursNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.PlanEEPHours, Long(), l => l.PlanEEPHoursSpecified, l => l.PlanEEPHoursNullable);
        }

        [Fact]
        public void PlanLearnHoursNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.PlanLearnHours, Long(), l => l.PlanLearnHoursSpecified, l => l.PlanLearnHoursNullable);
        }

        [Fact]
        public void PlanLearnHoursNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.PlanLearnHours, Long(), l => l.PlanLearnHoursSpecified, l => l.PlanEEPHoursNullable);
        }

        [Fact]
        public void PriorAttainNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.PriorAttain, Long(), l => l.PriorAttainSpecified, l => l.PriorAttainNullable);
        }

        [Fact]
        public void PriorAttainNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.PriorAttain, Long(), l => l.PriorAttainSpecified, l => l.PriorAttainNullable);
        }        

        [Fact]
        public void ULNNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.ULN, Long(), l => l.ULNSpecified, l => l.ULNNullable);
        }

        [Fact]
        public void ULNNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.ULN, Long(), l => l.ULNSpecified, l => l.ULNNullable);
        }

        [Fact]
        public void ContactPreferences()
        {
            var learner = new MessageLearner()
            {
                ContactPreference = new MessageLearnerContactPreference[]
                {
                    new MessageLearnerContactPreference()
                }
            };

            learner.ContactPreferences.Should().BeSameAs(learner.ContactPreference);
            learner.ContactPreferences.Should().HaveCount(1);
        }

        [Fact]
        public void LearnerEmploymentStatuses()
        {
            var learner = new MessageLearner()
            {
                LearnerEmploymentStatus = new MessageLearnerLearnerEmploymentStatus[]
                {
                    new MessageLearnerLearnerEmploymentStatus()
                }
            };

            learner.LearnerEmploymentStatuses.Should().BeSameAs(learner.LearnerEmploymentStatus);
            learner.LearnerEmploymentStatuses.Should().HaveCount(1);
        }

        [Fact]
        public void LearnerFAMs()
        {
            var learner = new MessageLearner()
            {
                LearnerFAM = new MessageLearnerLearnerFAM[]
                {
                    new MessageLearnerLearnerFAM()
                }
            };

            learner.LearnerFAMs.Should().BeSameAs(learner.LearnerFAM);
            learner.LearnerFAMs.Should().HaveCount(1);
        }
        
        [Fact]
        public void LearnerHEs()
        {
            var learner = new MessageLearner()
            {
                LearnerHE = new MessageLearnerLearnerHE[]
                {
                    new MessageLearnerLearnerHE()
                }
            };

            learner.LearnerHEs.Should().BeSameAs(learner.LearnerHE);
            learner.LearnerHEs.Should().HaveCount(1);
        }

        [Fact]
        public void LearningDeliveries()
        {
            var learner = new MessageLearner()
            {
                LearningDelivery = new MessageLearnerLearningDelivery[]
                {
                    new MessageLearnerLearningDelivery()
                }
            };

            learner.LearningDeliveries.Should().BeSameAs(learner.LearningDelivery);
            learner.LearningDeliveries.Should().HaveCount(1);
        }    

        [Fact]
        public void LLDDAndHealthProblems()
        {
            var learner = new MessageLearner()
            {
                LLDDandHealthProblem = new MessageLearnerLLDDandHealthProblem[]
                {
                    new MessageLearnerLLDDandHealthProblem()
                }
            };

            learner.LLDDAndHealthProblems.Should().BeSameAs(learner.LLDDandHealthProblem);
            learner.LLDDAndHealthProblems.Should().HaveCount(1);
        }
        
        [Fact]
        public void ProviderSpecLearnerMonitorings()
        {
            var learner = new MessageLearner()
            {
                ProviderSpecLearnerMonitoring = new MessageLearnerProviderSpecLearnerMonitoring[]
                {
                    new MessageLearnerProviderSpecLearnerMonitoring()
                }
            };

            learner.ProviderSpecLearnerMonitorings.Should().BeSameAs(learner.ProviderSpecLearnerMonitoring);
            learner.ProviderSpecLearnerMonitorings.Should().HaveCount(1);
        }        
    }
}
