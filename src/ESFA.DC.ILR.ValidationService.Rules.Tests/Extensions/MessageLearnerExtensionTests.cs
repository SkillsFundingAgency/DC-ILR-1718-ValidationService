using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Rules.Extensions;
using FluentAssertions;
using System;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Extensions
{
    public class MessageLearnerExtensionTests
    {
        [Fact]
        public void EarliestLearningDeliveryLearnStartDateFor_NullLearningDelivery()
        {
            var learner = new MessageLearner();

            learner.LearningDelivery = null;

            learner.EarliestLearningDeliveryLearnStartDateFor(1, 1, 1, 1).Should().BeNull();
        }

        [Fact]
        public void EarliestLearningDeliveryLearnStartDateFor_NoMatch()
        {
            var learner = new MessageLearner()
            {
                LearningDelivery = new MessageLearnerLearningDelivery[]
                {
                    new MessageLearnerLearningDelivery()
                    {
                        AimType = 1,
                        ProgType = 1,
                        FworkCode = 1,
                        PwayCode = 1,
                    }
                }
            };

            learner.EarliestLearningDeliveryLearnStartDateFor(1, 1, 1, 2).Should().BeNull();
        }

        [Fact]
        public void EarliestLearningDeliveryLearnStartDateFor_SingleMatch()
        {
            var learnStartDate = new DateTime(2017, 1, 1);

            var learner = new MessageLearner()
            {
                LearningDelivery = new MessageLearnerLearningDelivery[]
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
                }
            };

            learner.EarliestLearningDeliveryLearnStartDateFor(1, 1, 1, 1).Should().Be(learnStartDate);
        }

        [Fact]
        public void EarliestLearningDeliveryLearnStartDateFor_OrderedMatch()
        {
            var earliestLearnStartDate = new DateTime(2017, 1, 1);
            var latestLearnStartDate = new DateTime(2018, 1, 1);

            var learner = new MessageLearner()
            {
                LearningDelivery = new MessageLearnerLearningDelivery[]
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
                }
            };

            learner.EarliestLearningDeliveryLearnStartDateFor(1, 1, 1, 1).Should().Be(earliestLearnStartDate);
        }

        [Theory]
        [InlineData("1988-2-10", 30, "2018-2-10")]
        [InlineData("2018-1-1", 0, "2018-1-1")]
        [InlineData("2018-1-1", -1, "2017-1-1")]
        [InlineData("2018-1-1", 1, "2019-1-1")]
        [InlineData("1996-2-29", 1, "1997-2-28")]
        [InlineData("1996-2-29", 4, "2000-2-29")]
        public void BirthdayAt(string dateOfBirth, int age, string birthday)
        {
            var learner = new MessageLearner()
            {
                DateOfBirth = DateTime.Parse(dateOfBirth),
                DateOfBirthSpecified = true
            };

            learner.BirthdayAt(age).Should().Be(DateTime.Parse(birthday));
        }

        [Fact]
        public void BirthdayAt_DateOfBirthNull()
        {
            var learner = new MessageLearner()
            {
                DateOfBirthSpecified = false
            };

            learner.BirthdayAt(30).Should().BeNull();
        }

        [Theory]
        [InlineData("1988-2-10", "2018-1-18", 29)]
        [InlineData("1988-2-10", "2018-2-10", 30)]
        [InlineData("1988-2-10", "1988-2-10", 0)]
        [InlineData("1988-2-10", "1989-2-10", 1)]
        [InlineData("1988-2-10", "1987-2-10", -1)]
        public void AgeOn(string dateOfBirth, string reference, int age)
        {
            var learner = new MessageLearner()
            {
                DateOfBirth = DateTime.Parse(dateOfBirth),
                DateOfBirthSpecified = true
            };

            learner.AgeOn(DateTime.Parse(reference)).Should().Be(age);
        }

        [Fact]
        public void AgeOn_Null()
        {
            var learner = new MessageLearner()
            {
                DateOfBirthSpecified = false
            };

            learner.AgeOn(new DateTime(2018, 1, 1)).Should().BeNull();
        }
    }
}
