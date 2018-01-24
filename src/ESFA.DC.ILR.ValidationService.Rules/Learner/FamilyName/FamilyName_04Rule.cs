﻿using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using ESFA.DC.ILR.ValidationService.Rules.Query.Interface;
using System.Collections.Generic;
using System.Linq;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.FamilyName
{
    public class FamilyName_04Rule : AbstractRule, IRule<MessageLearner>
    {
        private readonly IMessageLearnerLearningDeliveryLearningDeliveryFAMQueryService _messageLearnerLearningDeliveryLearningDeliveryFAMQueryService;

        public FamilyName_04Rule(IMessageLearnerLearningDeliveryLearningDeliveryFAMQueryService messageLearnerLearningDeliveryLearningDeliveryFAMQueryService, IValidationErrorHandler validationErrorHandler)
            : base(validationErrorHandler)
        {
            _messageLearnerLearningDeliveryLearningDeliveryFAMQueryService = messageLearnerLearningDeliveryLearningDeliveryFAMQueryService;
        }

        public void Validate(MessageLearner objectToValidate)
        {
            if (CrossLearningDeliveryConditionMet(objectToValidate.LearningDelivery) && ConditionMet(objectToValidate.PlanLearnHours, objectToValidate.ULN, objectToValidate.GivenNames))
            {
                HandleValidationError(RuleNameConstants.FamilyName_04, objectToValidate.LearnRefNumber);
            }
        }

        public bool CrossLearningDeliveryConditionMet(IEnumerable<MessageLearnerLearningDelivery> learningDeliveries)
        {
            return learningDeliveries != null
                && (learningDeliveries.All(ld => ld.FundModel == 10)
                || learningDeliveries.All(ld => ld.FundModel == 99 && _messageLearnerLearningDeliveryLearningDeliveryFAMQueryService.HasLearningDeliveryFAMCodeForType(ld.LearningDeliveryFAM, LearningDeliveryFAMTypeConstants.SOF, "108")));
        }

        public bool ConditionMet(long planLearnHours, long uln, string givenNames)
        {
            return planLearnHours <= 10 
                && uln != ValidationConstants.TemporaryULN 
                && string.IsNullOrWhiteSpace(givenNames);
        }
    }
}