using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.ExternalData.Organisation.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Learner.PMUKPRN;
using FluentAssertions;
using Moq;
using System;
using System.Linq.Expressions;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Learner.PMUKPRN
{
    public class PMUKPRN_01RuleTests
    {
        [Fact]
        public void NullConditionMet_True()
        {
            var rule = new PMUKPRN_01Rule(null, null);

            rule.NullConditionMet(1).Should().BeTrue();
        }

        [Fact]
        public void NullConditionMet_False()
        {
            var rule = new PMUKPRN_01Rule(null, null);

            rule.NullConditionMet(null).Should().BeFalse();
        }

        [Fact]
        public void LookupConditionMet_True()
        {
            var rule = new PMUKPRN_01Rule(null, null);

            rule.LookupConditionMet(false).Should().BeTrue();
        }

        [Fact]
        public void LookupConditionMet_False()
        {
            var rule = new PMUKPRN_01Rule(null, null);

            rule.LookupConditionMet(true).Should().BeFalse();
        }

        [Fact]
        public void Validate_Error()
        {
            var learner = new MessageLearner()
            {
                PMUKPRNSpecified = true,
                PMUKPRN = 1,
            };

            var organisationReferenceDataServiceMock = new Mock<IOrganisationReferenceDataService>();
            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();

            organisationReferenceDataServiceMock.Setup(ord => ord.UkprnExists(1)).Returns(false);
            
            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("PMUKPRN_01", null, null, null);

            validationErrorHandlerMock.Setup(handle);

            var rule = new PMUKPRN_01Rule(organisationReferenceDataServiceMock.Object, validationErrorHandlerMock.Object);

            rule.Validate(learner);

            validationErrorHandlerMock.Verify(handle, Times.Once);
        }

        [Fact]
        public void Validate_NoErrors()
        {
            var learner = new MessageLearner()
            {
                PMUKPRNSpecified = false
            };
         
            var rule = new PMUKPRN_01Rule(null, null);

            rule.Validate(learner);
        }
    }
}
