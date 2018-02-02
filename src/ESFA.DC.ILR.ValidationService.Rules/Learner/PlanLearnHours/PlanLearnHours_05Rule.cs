﻿using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.PlanLearnHours
{
    /// <summary>
    /// If returned, the sum of the Planned learning hours and the Planned employability, enrichment and pastoral hours must not be greater than 4000 hours
    /// </summary>
    public class PlanLearnHours_05Rule : AbstractRule, IRule<IMessageLearner>
    {

        public PlanLearnHours_05Rule(IValidationErrorHandler validationErrorHandler)
            : base(validationErrorHandler)
        {

        }

        public void Validate(IMessageLearner objectToValidate)
        {
            foreach (var learningDelivery in objectToValidate.LearningDeliveries)
            {
                if (ConditionMet(objectToValidate.PlanLearnHoursNullable,objectToValidate.PlanEEPHoursNullable))
                {
                    HandleValidationError(RuleNameConstants.PlanLearnHours_05Rule, objectToValidate.LearnRefNumber,learningDelivery.AimSeqNumberNullable);
                }
            }
        }

        public bool ConditionMet(long? planLearnHours, long? planEeepHours)
        {
            return planLearnHours.HasValue && 
                   planLearnHours.Value + (planEeepHours ?? 0) > 4000;
        }

    }
}
