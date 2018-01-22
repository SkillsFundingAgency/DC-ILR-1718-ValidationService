﻿using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.ExternalData.Organisation.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.PrevUKPRN
{
    public class PrevUKPRN_01Rule : AbstractRule, IRule<MessageLearner>
    {
        private readonly IOrganisationReferenceDataService _organisationReferenceDataService;

        public PrevUKPRN_01Rule(IOrganisationReferenceDataService organisationReferenceDataService, IValidationErrorHandler validationErrorHandler)
            : base(validationErrorHandler)
        {
            _organisationReferenceDataService = organisationReferenceDataService;
        }

        public void Validate(MessageLearner objectToValidate)
        {
            if (NullConditionMet(objectToValidate.PrevUKPRNNullable) 
                && LookupConditionMet(_organisationReferenceDataService.UkprnExists(objectToValidate.PrevUKPRN)))
            {
                HandleValidationError(RuleNameConstants.PrevUKPRN_01, objectToValidate.LearnRefNumber);
            }
        }

        public bool NullConditionMet(long? prevUkprn)
        {
            return prevUkprn.HasValue;
        }

        public bool LookupConditionMet(bool ukprnExists)
        {
            return !ukprnExists;
        }
    }
}