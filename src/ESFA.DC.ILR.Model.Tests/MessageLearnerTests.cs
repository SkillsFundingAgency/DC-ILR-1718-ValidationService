using FluentAssertions;
using System;
using Xunit;

namespace ESFA.DC.ILR.Model.Tests
{
    public class MessageLearnerTests
    {
        [Fact]
        public void DateOfBirthNullable_Specified_True()
        {
            var dateOfBirth = new DateTime(2018, 1, 1);
            var learner = new MessageLearner();

            learner.DateOfBirthSpecified = true;
            learner.DateOfBirth = dateOfBirth;

            learner.DateOfBirthNullable.Should().Be(dateOfBirth);
            learner.DateOfBirthNullable.Should().NotBeNull();
        }

        [Fact]
        public void DateOfBirthNullable_Specified_False()
        {
            var dateOfBirth = new DateTime(2018, 1, 1);
            var learner = new MessageLearner();

            learner.DateOfBirthSpecified = false;
            learner.DateOfBirth = dateOfBirth;

            learner.DateOfBirthNullable.Should().BeNull();
        }

        [Fact]
        public void PrevUKPRNNullable_Specified_True()
        {
            var learner = new MessageLearner();

            learner.PrevUKPRNSpecified = true;
            learner.PrevUKPRN = 1234;

            learner.PrevUKPRNNullable.Should().Be(1234);
            learner.PrevUKPRNNullable.Should().NotBeNull();
        }

        [Fact]
        public void PrevUKPRNNullable_Specified_False()
        {
            var learner = new MessageLearner();

            learner.PrevUKPRNSpecified = false;
            learner.PrevUKPRN = 1234;

            learner.PrevUKPRNNullable.Should().BeNull();
        }

        [Fact]
        public void PMUKPRNNullable_Specified_True()
        {
            var learner = new MessageLearner();

            learner.PMUKPRNSpecified = true;
            learner.PMUKPRN = 1234;

            learner.PMUKPRNNullable.Should().Be(1234);
            learner.PMUKPRNNullable.Should().NotBeNull();
        }

        [Fact]
        public void PMUKPRNNullable_Specified_False()
        {
            var learner = new MessageLearner();

            learner.PMUKPRNSpecified = false;
            learner.PMUKPRN = 1234;

            learner.PMUKPRNNullable.Should().BeNull();
        }
    }
}
