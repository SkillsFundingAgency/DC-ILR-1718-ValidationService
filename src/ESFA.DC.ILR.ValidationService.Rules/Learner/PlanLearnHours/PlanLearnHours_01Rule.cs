﻿using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using ESFA.DC.ILR.ValidationService.Rules.Derived.Interface;
using System.Collections.Generic;
using System.Linq;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.PlanLearnHours
{
    /// <summary>
    /// The Planned learning hours must be returned unless the learner is undertaking an apprenticeship
    /// </summary>
    public class PlanLearnHours_01Rule : AbstractRule, IRule<IMessageLearner>
    {
        private readonly IDD07 _dd07;

        public PlanLearnHours_01Rule(IValidationErrorHandler validationErrorHandler, IDD07 dd07)
            : base(validationErrorHandler)
        {
            _dd07 = dd07;
        }

        public void Validate(IMessageLearner objectToValidate)
        {

            if (ConditionMet(objectToValidate.PlanLearnHoursNullable))
            {
                if (!HasAllLearningAimsClosedExcludeConditionMet(objectToValidate.LearningDeliveries))
                {
                    //if there is any learning delivery not DD07 and fundmodel 70 then exclusion doesnt apply
                    if (objectToValidate.LearningDeliveries==null || objectToValidate.LearningDeliveries.Any(x => !Exclude(x)))
                    {
                        HandleValidationError(RuleNameConstants.PlanLearnHours_01Rule, objectToValidate.LearnRefNumber);
                    }
                }
            }
        }
        public bool ConditionMet(long? planLearnHoursNullable)
        {
            return !planLearnHoursNullable.HasValue ;
        }

        public bool Exclude(IMessageLearnerLearningDelivery learningDelivery)
        {

            return HasLearningDeliveryDd07ExcludeConditionMet(_dd07.Derive(learningDelivery.ProgTypeNullable)) ||
                   HasLearningDeliveryFundModelExcludeConditionMet(learningDelivery.FundModelNullable);
        }

        public bool HasLearningDeliveryDd07ExcludeConditionMet(string dd07)
        {
            return dd07 == ValidationConstants.Y;
        }
        public bool HasLearningDeliveryFundModelExcludeConditionMet(long? fundModelNullable)
        {
            return fundModelNullable.HasValue && fundModelNullable.Value == 70;

        }

        public bool HasAllLearningAimsClosedExcludeConditionMet(IReadOnlyCollection<IMessageLearnerLearningDelivery> learningDeliveries)
        {
            return learningDeliveries!=null && learningDeliveries.All(x => x.LearnActEndDateNullable.HasValue);
        }
    }
}
