using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using ESFA.DC.ILR.ValidationService.Rules.Constants;
using System;

namespace ESFA.DC.ILR.ValidationService.Rules.LearningDelivery.LearnStartDate
{
    public class LearnStartDate_05Rule : AbstractRule, IRule<MessageLearner>
    {
        public LearnStartDate_05Rule(IValidationErrorHandler validationErrorHandler)
            : base(validationErrorHandler)
        {
        }

        public void Validate(MessageLearner objectToValidate)
        {
            foreach (var learningDelivery in objectToValidate.LearningDelivery)
            {
                if (ConditionMet(objectToValidate.DateOfBirthNullable, learningDelivery.LearnStartDate))
                {
                    HandleValidationError(RuleNameConstants.LearnStartDate_05, objectToValidate.LearnRefNumber, learningDelivery.AimSeqNumberNullable);
                }
            }
        }

        public bool ConditionMet(DateTime? dateOfBirth, DateTime learnStartDate)
        {
            return dateOfBirth.HasValue
                && dateOfBirth.Value >= learnStartDate;
        }
    }
}
