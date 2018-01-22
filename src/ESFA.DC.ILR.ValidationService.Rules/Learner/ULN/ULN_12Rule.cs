using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using ESFA.DC.ILR.ValidationService.Rules.Extensions;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.ULN
{
    public class ULN_12Rule : AbstractRule, IRule<MessageLearner>
    {
        public ULN_12Rule(IValidationErrorHandler validationErrorHandler)
            : base(validationErrorHandler)
        {
        }

        public void Validate(MessageLearner objectToValidate)
        {
            foreach (var learningDelivery in objectToValidate.LearningDelivery)
            {
                if (ConditionMet(learningDelivery.HasLearningDeliveryFAMCodeForType(LearningDeliveryFAMTypeConstants.ACT, "1"), objectToValidate.ULNNullable))
                {
                    HandleValidationError(RuleNameConstants.ULN_12, objectToValidate.LearnRefNumber, learningDelivery.AimSeqNumberNullable);
                }
            }
        }

        public bool ConditionMet(bool hasACTCodeOne, long? uln)
        {
            return hasACTCodeOne
                && (!uln.HasValue || uln.Value == ValidationConstants.TemporaryULN);
        }
    }
}
