﻿using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using ESFA.DC.ILR.ValidationService.Rules.Query.Interface;
using System.Collections.Generic;
using System.Linq;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.GivenNames
{
    public class FamilyName_02Rule : AbstractRule, IRule<MessageLearner>
    {
        private readonly IMessageLearnerLearningDeliveryLearningDeliveryFAMQueryService _messageLearnerLearningDeliveryLearningDeliveryFAMQueryService;

        public FamilyName_02Rule(IMessageLearnerLearningDeliveryLearningDeliveryFAMQueryService messageLearnerLearningDeliveryLearningDeliveryFAMQueryService, IValidationErrorHandler validationErrorHandler)
            : base(validationErrorHandler)
        {
            _messageLearnerLearningDeliveryLearningDeliveryFAMQueryService = messageLearnerLearningDeliveryLearningDeliveryFAMQueryService;
        }

        public void Validate(MessageLearner objectToValidate)
        {
            if (CrossLearningDeliveryConditionMet(objectToValidate.LearningDelivery) && ConditionMet(objectToValidate.PlanLearnHours, objectToValidate.FamilyName))
            {
                HandleValidationError(RuleNameConstants.FamilyName_02, objectToValidate.LearnRefNumber);
            }
        }

        public bool CrossLearningDeliveryConditionMet(IEnumerable<MessageLearnerLearningDelivery> learningDeliveries)
        {
            return learningDeliveries != null
                && (learningDeliveries.All(ld => ld.FundModel == 10)
                || learningDeliveries.All(ld => ld.FundModel == 99 && _messageLearnerLearningDeliveryLearningDeliveryFAMQueryService.HasLearningDeliveryFAMCodeForType(ld.LearningDeliveryFAM, LearningDeliveryFAMTypeConstants.SOF, "108")));
        }

        public bool ConditionMet(long planLearnHours, string familyName)
        {
            return planLearnHours > 10 && string.IsNullOrWhiteSpace(familyName);
        }
    }
}
