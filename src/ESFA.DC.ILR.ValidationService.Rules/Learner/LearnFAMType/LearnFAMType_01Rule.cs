using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Constants;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.LearnFAMType
{
    /// <summary>
    /// If a FAM type is returned, the FAM code must be a valid lookup for that FAM type
    /// </summary>
    public class LearnFAMType_01Rule : AbstractLearnFAMTypeRule
    {
        public LearnFAMType_01Rule(IValidationErrorHandler validationErrorHandler)
            : base(validationErrorHandler)
        {
        }

        public override void Validate(ILearner objectToValidate)
        {
            foreach (var learningDelivery in objectToValidate.LearningDeliveries)
            {
                if (ConditionMet(objectToValidate.EngGrade, learningDelivery.FundModelNullable))
                {
                    HandleValidationError(RuleNameConstants.EngGrade_01Rule, objectToValidate.LearnRefNumber, learningDelivery.AimSeqNumberNullable);
                }
            }
        }

        public bool ConditionMet(string engGradeNullable, long? fundModelNullable)
        {
            return string.IsNullOrWhiteSpace(engGradeNullable);
        }
    }
}