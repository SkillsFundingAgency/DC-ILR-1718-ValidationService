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

            dd04.Derive(learner, latestLearningDelivery).Should().Be(new DateTime(2015, 1, 1));
        }
    }
}
