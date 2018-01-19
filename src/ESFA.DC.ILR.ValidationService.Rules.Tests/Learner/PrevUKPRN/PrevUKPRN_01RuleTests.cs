using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.ExternalData.Organisation.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Learner.PrevUKPRN;
using FluentAssertions;
using Moq;
using System;
using System.Linq.Expressions;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Learner.PrevUKPRN
{
    public class PrevUKPRN_01RuleTests
    {
        [Fact]
        public void NullConditionMet_True()
        {
            var rule = new PrevUKPRN_01Rule(null, null);

            rule.NullConditionMet(1).Should().BeTrue();
        }

        [Fact]
        public void NullConditionMet_False()
        {
            var rule = new PrevUKPRN_01Rule(null, null);

            rule.NullConditionMet(null).Should().BeFalse();
        }

        [Fact]
        public void LookupConditionMet_True()
        {
            var rule = new PrevUKPRN_01Rule(null, null);

            rule.LookupConditionMet(false).Should().BeTrue();
        }

        [Fact]
        public void LookupConditionMet_False()
        {
            var rule = new PrevUKPRN_01Rule(null, null);

            rule.LookupConditionMet(true).Should().BeFalse();
        }

        [Fact]
        public void Validate_Error()
        {
            var learner = new MessageLearner()
            {
                PrevUKPRNSpecified = true,
                PrevUKPRN = 1,
            };

            var organisationReferenceDataServiceMock = new Mock<IOrganisationReferenceDataService>();
            var validationErrorHandlerMock = new Mock<IValidationErrorHandler>();

            organisationReferenceDataServiceMock.Setup(ord => ord.UkprnExists(1)).Returns(false);
            
            Expression<Action<IValidationErrorHandler>> handle = veh => veh.Handle("PrevUKPRN_01", null, null, null);

            validationErrorHandlerMock.Setup(handle);

            var rule = new PrevUKPRN_01Rule(organisationReferenceDataServiceMock.Object, validationErrorHandlerMock.Object);

            rule.Validate(learner);

            validationErrorHandlerMock.Verify(handle, Times.Once);
        }

        [Fact]
        public void Validate_NoErrors()
        {
            var learner = new MessageLearner()
            {
                PrevUKPRNSpecified = false
            };
         
            var rule = new PrevUKPRN_01Rule(null, null);

            rule.Validate(learner);
        }
    }
}
