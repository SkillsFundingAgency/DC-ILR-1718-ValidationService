using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Derived.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Learner.DateOfBirth;
using FluentAssertions;
using Moq;
using System;
using System.Linq.Expressions;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Learner.DateOfBirth
{
    public class DateOfBirth_48RuleTests
    {
        [Fact]
        public void Exclude_True()
        {
            var rule = new DateOfBirth_48Rule(null, null, null, null);

            rule.Exclude(25).Should().BeTrue();
        }

        [Fact]
        public void Exclude_False()
        {
            var rule = new DateOfBirth_48Rule(null, null, null, null);

            rule.Exclude(24).Should().BeFalse();
        }

        [Fact]
        public void LearnerConditionMet_True()
        {
            var rule = new DateOfBirth_48Rule(null, null, null, null);

            rule.LearnerConditionMet(new DateTime(2018, 1, 1)).Should().BeTrue();
        }

        [Fact]
        public void LearnerConditionMet_False()
        {
            var rule = new DateOfBirth_48Rule(null, null, null, null);

            rule.LearnerConditionMet(null).Should().BeFalse();
        }

        [Fact]
        public void DD04ConditionMet_True()
        {
            var rule = new DateOfBirth_48Rule(null, null, null, null);

            rule.DD04ConditionMet(new DateTime(2017, 12, 1), new DateTime(2017, 8, 1), new DateTime(2018, 6, 1)).Should().BeTrue();
        }

        [Theory]
        [InlineData(2015, 1, 1)]
        [InlineData(2019, 1, 1)]
        public void DD04ConditionMet_False(int year, int month, int day)
        {
            var rule = new DateOfBirth_48Rule(null, null, null, null);

            rule.DD04ConditionMet(new DateTime(year, month, day), new DateTime(2017, 8, 1), new DateTime(2018, 6, 1)).Should().BeFalse();
        }

        [Fact]
        public void DD04ConditionMet_Null()
        {
            var rule = new DateOfBirth_48Rule(null, null, null, null);

            rule.DD04ConditionMet(null, new DateTime(2017, 8, 1), new DateTime(2018, 6, 1)).Should().BeFalse();
        }

        [Fact]
        public void DD07ConditionMet_True()
        {
            var rule = new DateOfBirth_48Rule(null, null, null, null);

            rule.DD07ConditionMet("Y").Should().BeTrue();
        }

        [Theory]
        [InlineData("N")]
        [InlineData("AnythingElse")]
        public void DD07ConditionMet_False(string dd07)
        {
            var rule = new DateOfBirth_48Rule(null, null, null, null);

            rule.DD07ConditionMet(dd07).Should().BeFalse();
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
            var rule = new DateOfBirth_48Rule(null, null, null, null);
            
            rule.BirthdayAt(DateTime.Parse(dateOfBirth), age).Should().Be(DateTime.Parse(birthday));
        }

        [Fact]
        public void BirthdayAt_DateOfBirthNull()
        {
            var rule = new DateOfBirth_48Rule(null, null, null, null);

            rule.BirthdayAt(null, 30).Should().BeNull();
        }

        [Fact]
        public void Validate_NoErrors()
        {
            var learner = new MessageLearner()
            {
                DateOfBirthSpecified = false
            };

            var rule = new DateOfBirth_48Rule(null, null, null, null);

            rule.Validate(learner);
        }

        [Fact]
        public void Validate_Error()
        {
            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                ProgType = 1,
                AimType = 1,
                LearnStartDate = new DateTime(2017, 1, 1),
                LearnStartDateSpecified = true
            };

            var learner = new MessageLearner()
            {
                DateOfBirth = new DateTime(2002, 1, 1),
                DateOfBirthSpecified = true,
                LearningDelivery = new MessageLearnerLearningDelivery[]
                {
                    learningDelivery
                }
            };

            var dd04Mock = new Mock<IDD04>();
            var dd07Mock = new Mock<IDD07>();
            var validationDataServiceMock = new Mock<IValidationDataService>();
            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();

            dd04Mock.Setup(dd => dd.Derive(learner.LearningDelivery, learningDelivery)).Returns(new DateTime(2017, 1, 1));
            dd07Mock.Setup(dd => dd.Derive(1)).Returns("Y");
            validationDataServiceMock.SetupGet(vds => vds.ApprencticeProgAllowedStartDate).Returns(new DateTime(2016, 8, 1));

            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("DateOfBirth_48", null, null, null);

            validationErrorHandlerMock.Setup(handle);

            var rule = new DateOfBirth_48Rule(dd04Mock.Object, dd07Mock.Object, validationDataServiceMock.Object, validationErrorHandlerMock.Object);

            rule.Validate(learner);

            validationErrorHandlerMock.Verify(handle, Times.Once);
        }
    }
}
