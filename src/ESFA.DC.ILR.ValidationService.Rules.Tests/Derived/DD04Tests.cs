using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Rules.Derived;
using FluentAssertions;
using System;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Derived
{
    public class DD04Tests
    {
        [Fact]
        public void Derive()
        {
            var earliestLearningDelivery = new MessageLearnerLearningDelivery()
            {
                ProgType = 1,
                FworkCode = 1,
                PwayCode = 1,
                AimType = 1,
                LearnStartDate = new DateTime(2015, 1, 1)
            };

            var latestLearningDelivery = new MessageLearnerLearningDelivery()
            {
                ProgType = 1,
                FworkCode = 1,
                PwayCode = 1,
                AimType = 1,
                LearnStartDate = new DateTime(2017, 1, 1)
            };

            var learner = new MessageLearner()
            {
                LearningDelivery = new MessageLearnerLearningDelivery[]
                {
                    latestLearningDelivery,
                    earliestLearningDelivery
                }
            };

            var dd04 = new DD04();

            dd04.Derive(learner.LearningDelivery, latestLearningDelivery).Should().Be(new DateTime(2015, 1, 1));
        }

        [Fact]
        public void EarliestLearningDeliveryLearnStartDateFor_NullLearningDelivery()
        {
            var learner = new MessageLearner
            {
                LearningDelivery = null
            };

            var dd04 = new DD04();

            dd04.EarliestLearningDeliveryLearnStartDateFor(null, 1, 1, 1, 1).Should().BeNull();
        }

        [Fact]
        public void EarliestLearningDeliveryLearnStartDateFor_NoMatch()
        {
            var learningDeliveries = new MessageLearnerLearningDelivery[]
            {
                new MessageLearnerLearningDelivery()
                {
                    AimType = 1,
                    ProgType = 1,
                    FworkCode = 1,
                    PwayCode = 1,
                }
            };            

            var dd04 = new DD04();

            dd04.EarliestLearningDeliveryLearnStartDateFor(learningDeliveries, 1, 1, 1, 2);
        }

        [Fact]
        public void EarliestLearningDeliveryLearnStartDateFor_SingleMatch()
        {
            var learnStartDate = new DateTime(2017, 1, 1);

            var learningDeliveries = new MessageLearnerLearningDelivery[]
            {
                new MessageLearnerLearningDelivery()
                {
                    AimType = 1,
                    ProgType = 1,
                    FworkCode = 1,
                    PwayCode = 1,
                    LearnStartDate = learnStartDate
                },
                new MessageLearnerLearningDelivery()
                {
                    AimType = 1,
                    ProgType = 1,
                    FworkCode = 1,
                    PwayCode = 2,
                }
            };

            var dd04 = new DD04();

            dd04.EarliestLearningDeliveryLearnStartDateFor(learningDeliveries, 1, 1, 1, 1).Should().Be(learnStartDate);
        }

        [Fact]
        public void EarliestLearningDeliveryLearnStartDateFor_OrderedMatch()
        {
            var earliestLearnStartDate = new DateTime(2017, 1, 1);
            var latestLearnStartDate = new DateTime(2018, 1, 1);

            var learningDeliveries = new MessageLearnerLearningDelivery[]
            {
                new MessageLearnerLearningDelivery()
                {
                    AimType = 1,
                    ProgType = 1,
                    FworkCode = 1,
                    PwayCode = 1,
                    LearnStartDate = earliestLearnStartDate
                },
                new MessageLearnerLearningDelivery()
                {
                    AimType = 1,
                    ProgType = 1,
                    FworkCode = 1,
                    PwayCode = 1,
                    LearnStartDate = latestLearnStartDate
                },
                new MessageLearnerLearningDelivery()
                {
                    AimType = 1,
                    ProgType = 1,
                    FworkCode = 1,
                    PwayCode = 2,
                }
            };

            var dd04 = new DD04();

            dd04.EarliestLearningDeliveryLearnStartDateFor(learningDeliveries, 1, 1, 1, 1).Should().Be(earliestLearnStartDate);
        }        
    }
}
