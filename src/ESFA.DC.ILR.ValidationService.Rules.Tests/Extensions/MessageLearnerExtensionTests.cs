using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Rules.Extensions;
using FluentAssertions;
using System;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Extensions
{
    public class MessageLearnerExtensionTests
    {        
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
    }
}
