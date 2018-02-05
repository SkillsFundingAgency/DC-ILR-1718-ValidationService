using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Learner.ALSCost;
using ESFA.DC.ILR.ValidationService.Rules.Query;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Learner.ALSCost
{
    public class ALSCost_02RuleTests
    {
        [Fact]
        public void ConditionMet_True()
        {
            var learnerFamQueryService = new MessageLearnerFAMQueryService();
            var learnerFams = new[]
            {
                new MessageLearnerLearnerFAM()
                {
                    LearnFAMType = "XYZ"
                }
            };
            var rule = new ALSCost_02Rule(null,learnerFamQueryService);
            rule.ConditionMet(10,learnerFams).Should().BeTrue();
        }

        [Theory]
        [InlineData(null,"XYZ")]
        [InlineData(100,"HNS")]
        public void ConditionMet_False(long? alsCost,string famType)
        {
            var learnerFamQueryService = new MessageLearnerFAMQueryService();

            var fams = new List<IMessageLearnerLearnerFAM>()
            {
                new MessageLearnerLearnerFAM()
                {
                    LearnFAMType = famType
                }
            };
            var rule = new ALSCost_02Rule(null,learnerFamQueryService);
            rule.ConditionMet(alsCost, fams).Should().BeFalse();
        }
       

        [Fact]
        public void Validate_Error()
        {
            var learner = SetupLearner(null);

            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("ALSCost_02", null, null, null);
            
            var rule = new ALSCost_02Rule(validationErrorHandlerMock.Object, new MessageLearnerFAMQueryService());
            rule.Validate(learner);
            validationErrorHandlerMock.Verify(handle, Times.Once);
        }

        [Fact]
        public void Validate_NoError()
        {
            var learner = SetupLearner("HNS");

            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();
            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("ALSCost_02", null, null, null);
            
            var rule = new ALSCost_02Rule(validationErrorHandlerMock.Object, new MessageLearnerFAMQueryService());
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
