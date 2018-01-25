using FluentAssertions;
using System;
using Xunit;

namespace ESFA.DC.ILR.Model.Tests
{
    public class MessageLearnerLearningDeliveryTests
    {
        [Fact]
        public void AimSeqNumber_Specified_False()
        {
            var learningDelivery = new MessageLearnerLearningDelivery();

            learningDelivery.LearnActEndDateSpecified = false;
            learningDelivery.AimSeqNumber = 1234;

            learningDelivery.AimSeqNumberNullable.Should().BeNull();
        }

        [Fact]
        public void AimSeqNumber_Specified_True()
        {
            var aimSeqNumber = 1234;
            var learningDelivery = new MessageLearnerLearningDelivery();

            learningDelivery.AimSeqNumberSpecified = true;
            learningDelivery.AimSeqNumber = aimSeqNumber;

            learningDelivery.AimSeqNumberNullable.Should().Be(aimSeqNumber);
            learningDelivery.AimSeqNumberNullable.Should().NotBeNull();
        }

        [Fact]
        public void LearnStartEndDate_Specified_False()
        {
            var learningDelivery = new MessageLearnerLearningDelivery();
                
            learningDelivery.LearnStartDateSpecified = false;
            learningDelivery.LearnStartDate = new DateTime(2018, 1, 1);

            learningDelivery.LearnStartDateNullable.Should().BeNull();            
        }

        [Fact]
        public void LearnStartEndDate_Specified_True()
        {
            var learningDelivery = new MessageLearnerLearningDelivery();

            var date = new DateTime(2018, 1, 1);

            learningDelivery.LearnStartDateSpecified = true;
            learningDelivery.LearnStartDate = date;

            learningDelivery.LearnStartDateNullable.Should().Be(date);
            learningDelivery.LearnStartDateNullable.Should().NotBeNull();
        }

        [Fact]
        public void LearnPlanEndDate_Specified_False()
        {
            var learningDelivery = new MessageLearnerLearningDelivery();

            learningDelivery.LearnPlanEndDateSpecified = false;
            learningDelivery.LearnPlanEndDate = new DateTime(2018, 1, 1);

            learningDelivery.LearnPlanEndDateNullable.Should().BeNull();
        }

        [Fact]
        public void LearnPlanEndDate_Specified_True()
        {
            var learningDelivery = new MessageLearnerLearningDelivery();

            var date = new DateTime(2018, 1, 1);

            learningDelivery.LearnPlanEndDateSpecified = true;
            learningDelivery.LearnPlanEndDate = date;

            learningDelivery.LearnPlanEndDateNullable.Should().Be(date);
            learningDelivery.LearnPlanEndDateNullable.Should().NotBeNull();
        }

        [Fact]
        public void LearnActEndDate_Specified_False()
        {
            var learningDelivery = new MessageLearnerLearningDelivery();

            learningDelivery.LearnActEndDateSpecified = false;
            learningDelivery.LearnActEndDate = new DateTime(2018, 1, 1);

            learningDelivery.LearnActEndDateNullable.Should().BeNull();
        }

        [Fact]
        public void LearnActEndDate_Specified_True()
        {
            var learningDelivery = new MessageLearnerLearningDelivery();

            var date = new DateTime(2018, 1, 1);

            learningDelivery.LearnActEndDateSpecified = true;
            learningDelivery.LearnActEndDate = date;

            learningDelivery.LearnActEndDateNullable.Should().Be(date);
            learningDelivery.LearnActEndDateNullable.Should().NotBeNull();
        }

        [Fact]
        public void FundModel_Specified_False()
        {
            var learningDelivery = new MessageLearnerLearningDelivery();

            learningDelivery.FundModelSpecified = false;
            learningDelivery.FundModel = 1234;

            learningDelivery.FundModelNullable.Should().BeNull();
        }

        [Fact]
        public void FundModel_Specified_True()
        {
            var learningDelivery = new MessageLearnerLearningDelivery();

            learningDelivery.FundModelSpecified = true;
            learningDelivery.FundModel = 1234;

            learningDelivery.FundModelNullable.Should().Be(1234);
            learningDelivery.FundModelNullable.Should().NotBeNull();
        }

        [Fact]
        public void LearningDeliveryFAMs()
        {
            var learningDelivery = new MessageLearnerLearningDelivery();

            learningDelivery.LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[]
            {
                new MessageLearnerLearningDeliveryLearningDeliveryFAM()
            };

            learningDelivery.LearningDeliveryFAMs.Should().BeSameAs(learningDelivery.LearningDeliveryFAM);
            learningDelivery.LearningDeliveryFAMs.Should().HaveCount(1);
        }
    }
}
