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
        public void AimType_Specified_False()
        {
            var aimType = 1234;
            var learningDelivery = new MessageLearnerLearningDelivery();

            learningDelivery.AimTypeSpecified = false;
            learningDelivery.AimType = aimType;

            learningDelivery.AimTypeNullable.Should().BeNull();
        }

        [Fact]
        public void AimType_Specified_True()
        {
            var aimType = 1234;
            var learningDelivery = new MessageLearnerLearningDelivery();

            learningDelivery.AimTypeSpecified = true;
            learningDelivery.AimType = aimType;

            learningDelivery.AimTypeNullable.Should().Be(aimType);
            learningDelivery.AimTypeNullable.Should().NotBeNull();
        }

        [Fact]
        public void FworkCode_Specified_False()
        {
            var fworkCode = 1234;
            var learningDelivery = new MessageLearnerLearningDelivery();

            learningDelivery.FworkCodeSpecified = false;
            learningDelivery.FworkCode = fworkCode;

            learningDelivery.FworkCodeNullable.Should().BeNull();
        }

        [Fact]
        public void FworkCode_Specified_True()
        {
            var fworkCode = 1234;
            var learningDelivery = new MessageLearnerLearningDelivery();

            learningDelivery.FworkCodeSpecified = true;
            learningDelivery.FworkCode = fworkCode;

            learningDelivery.FworkCodeNullable.Should().Be(fworkCode);
            learningDelivery.FworkCodeNullable.Should().NotBeNull();
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

        [Fact]
        public void ProgType_Specified_False()
        {
            var progType = 1234;
            var learningDelivery = new MessageLearnerLearningDelivery();

            learningDelivery.ProgTypeSpecified = false;
            learningDelivery.ProgType = progType;

            learningDelivery.ProgTypeNullable.Should().BeNull();
        }

        [Fact]
        public void ProgType_Specified_True()
        {
            var progType = 1234;
            var learningDelivery = new MessageLearnerLearningDelivery();

            learningDelivery.ProgTypeSpecified = true;
            learningDelivery.ProgType = progType;

            learningDelivery.ProgTypeNullable.Should().Be(progType);
            learningDelivery.ProgTypeNullable.Should().NotBeNull();
        }

        [Fact]
        public void PwayCode_Specified_False()
        {
            var pwayCode = 1234;
            var learningDelivery = new MessageLearnerLearningDelivery();

            learningDelivery.PwayCodeSpecified = false;
            learningDelivery.PwayCode = pwayCode;

            learningDelivery.PwayCodeNullable.Should().BeNull();
        }

        [Fact]
        public void PwayCode_Specified_True()
        {
            var pwayCode = 1234;
            var learningDelivery = new MessageLearnerLearningDelivery();

            learningDelivery.PwayCodeSpecified = true;
            learningDelivery.PwayCode = pwayCode;

            learningDelivery.PwayCodeNullable.Should().Be(pwayCode);
            learningDelivery.PwayCodeNullable.Should().NotBeNull();
        }
    }
}
