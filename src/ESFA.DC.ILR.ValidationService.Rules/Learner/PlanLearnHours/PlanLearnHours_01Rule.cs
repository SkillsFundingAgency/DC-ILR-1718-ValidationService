using ESFA.DC.ILR.Model.Interface;
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
    public class PlanLearnHours_01Rule : AbstractRule, IRule<ILearner>
    {
        private readonly IDD07 _dd07;

        public PlanLearnHours_01Rule(IDD07 dd07, IValidationErrorHandler validationErrorHandler)
            : base(validationErrorHandler)
        {
            _dd07 = dd07;
        }

        public void Validate(ILearner objectToValidate)
        {

            if (HasPlanLearnLearnHoursConditionMet(objectToValidate.PlanLearnHoursNullable))
            {
                var areAllLearningAimsClosed = HasAllLearningAimsClosedExcludeConditionMet(objectToValidate.LearningDeliveries);

                if (!areAllLearningAimsClosed)
                {
                    foreach (var learningDelivery in objectToValidate.LearningDeliveries.Where(x => !Exclude(x)))
                    {
                        HandleValidationError(RuleNameConstants.PlanLearnHours_01Rule, objectToValidate.LearnRefNumber,learningDelivery.AimSeqNumberNullable);
                    }
                }
                else
                {
                    HandleValidationError(RuleNameConstants.PlanLearnHours_01Rule, objectToValidate.LearnRefNumber);
                }
            }
        }
        public bool HasPlanLearnLearnHoursConditionMet(long? planLearnHoursNullable)
        {
            return !planLearnHoursNullable.HasValue ;
        }

        public bool Exclude(ILearningDelivery learningDelivery)
        {

            return HasLearningDeliveryDd07ExcludeConditionMet(_dd07.Derive(learningDelivery.ProgTypeNullable)) ||
                   HasLearningDeliveryFamExcludeConditionMet(learningDelivery.FundModelNullable);
        }

        public bool HasLearningDeliveryDd07ExcludeConditionMet(string dd07)
        {
            return dd07 == ValidationConstants.Y;
        }
        public bool HasLearningDeliveryFamExcludeConditionMet(long? fundModelNullable)
        {
            return fundModelNullable.HasValue && fundModelNullable.Value == 70;

        }

        public bool HasAllLearningAimsClosedExcludeConditionMet(IReadOnlyCollection<ILearningDelivery> learningDeliveries)
        {
            return learningDeliveries!=null && learningDeliveries.All(x => x.LearnActEndDateNullable.HasValue);
        }
    }
}
