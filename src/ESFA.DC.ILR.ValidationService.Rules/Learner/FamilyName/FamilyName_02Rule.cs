﻿using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using ESFA.DC.ILR.ValidationService.Rules.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.FamilyName
{
    public class FamilyName_02Rule : AbstractRule, IRule<MessageLearner>
    {
        public FamilyName_02Rule(IValidationErrorHandler validationErrorHandler)
            : base(validationErrorHandler)
        {
        }

        public void Validate(MessageLearner objectToValidate)
        {
            if (CrossLearningDeliveryConditionMet(objectToValidate.LearningDelivery) && ConditionMet(objectToValidate.PlanLearnHours, objectToValidate.GivenNames))
            {
                HandleValidationError(RuleNameConstants.FamilyName_02, objectToValidate.LearnRefNumber);
            }
        }

        public bool CrossLearningDeliveryConditionMet(IEnumerable<MessageLearnerLearningDelivery> learningDeliveries)
        {
            return learningDeliveries != null
                && (learningDeliveries.All(ld => ld.FundModel == 10)
                || learningDeliveries.All(ld => ld.FundModel == 99 && ld.HasLearningDeliveryFAMCodeForType(LearningDeliveryFAMTypeConstants.SOF, "108")));
        }

        public bool ConditionMet(long planLearnHours, string givenNames)
        {
            return planLearnHours > 10 && string.IsNullOrWhiteSpace(givenNames);
        }
    }
}