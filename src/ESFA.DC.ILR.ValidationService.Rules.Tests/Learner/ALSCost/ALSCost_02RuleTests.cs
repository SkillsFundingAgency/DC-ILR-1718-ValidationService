using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Learner.Accom;
using ESFA.DC.ILR.ValidationService.Rules.Learner.PriorAttain;
using ESFA.DC.ILR.ValidationService.Rules.Query.Interface;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Learner.ALSCost;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Learner.ALSCost
{
    public class ALSCost_02RuleTests
    {
        [Fact]
        public void ConditionMet_True()
        {
            var rule = new ALSCost_02Rule(null);
            rule.ConditionMet(10,null).Should().BeTrue();
        }

        [Theory]
        [InlineData(null,"XYZ")]
        [InlineData(100,"HNS")]
        public void ConditionMet_False(long? alsCost,string famType)
        {
            var fams = new List<ILearnerFAM>()
            {
                new MessageLearnerLearnerFAM()
                {
                    LearnFAMType = famType
                }
            };
            var rule = new ALSCost_02Rule(null);
            rule.ConditionMet(alsCost, fams).Should().BeFalse();
        }
        [Fact]
        public void HasAnyHnsLearnerFam_False()
        {
            var fams = new List<ILearnerFAM>()
            {
                new MessageLearnerLearnerFAM()
                {
                    LearnFAMType = "XYZ"
                },
                new MessageLearnerLearnerFAM()
                {
                    LearnFAMType = "ABC"
                }
            };
            var rule = new ALSCost_02Rule(null);
            rule.HasAnyHnsLearnerFam(fams).Should().BeFalse();
        }

        [Fact]
        public void HasAnyHnsLearnerFam_True()
        {
            var fams = new List<ILearnerFAM>()
            {
                new MessageLearnerLearnerFAM()
                {
                    LearnFAMType = "XYZ"
                },
                new MessageLearnerLearnerFAM()
                {
                    LearnFAMType = "HNS"
                }
            };
            var rule = new ALSCost_02Rule(null);
            rule.HasAnyHnsLearnerFam(fams).Should().BeTrue();
        }


        [Fact]
        public void Validate_Error()
        {
            var learner = SetupLearner(null);

            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("ALSCost_02", null, null, null);

            var rule = new ALSCost_02Rule(validationErrorHandlerMock.Object);
            rule.Validate(learner);
            validationErrorHandlerMock.Verify(handle, Times.Once);
        }

        [Fact]
        public void Validate_NoError()
        {
            var learner = SetupLearner("HNS");

            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("ALSCost_02", null, null, null);

            var rule = new ALSCost_02Rule(validationErrorHandlerMock.Object);
            rule.Validate(learner);
            validationErrorHandlerMock.Verify(handle, Times.Never);
        }

        private  MessageLearner SetupLearner(string learnFamType)
        {
            var learner = new MessageLearner()
            {
                ALSCostSpecified = true,
                ALSCost = 10,
                LearnerFAM = new MessageLearnerLearnerFAM[]
                {
                    new MessageLearnerLearnerFAM()
                    {
                        LearnFAMType = learnFamType
                    }
                }
            };
            return learner;
        }
    }
}
