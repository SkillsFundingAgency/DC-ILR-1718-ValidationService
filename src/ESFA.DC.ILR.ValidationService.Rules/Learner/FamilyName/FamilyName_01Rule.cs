using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using ESFA.DC.ILR.ValidationService.Rules.Query.Interface;
using System.Linq;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.GivenNames
{
    public class FamilyName_01Rule : AbstractRule, IRule<MessageLearner>
    {
        private readonly ILearningDeliveryFAMQueryService _messageLearnerLearningDeliveryLearningDeliveryFAMQueryService;

        public FamilyName_01Rule(ILearningDeliveryFAMQueryService messageLearnerLearningDeliveryLearningDeliveryFAMQueryService, IValidationErrorHandler validationErrorHandler) 
            : base(validationErrorHandler)
        {
            _messageLearnerLearningDeliveryLearningDeliveryFAMQueryService = messageLearnerLearningDeliveryLearningDeliveryFAMQueryService;
        }

        public void Validate(MessageLearner objectToValidate)
        {
            if (objectToValidate.LearningDelivery == null || !objectToValidate.LearningDelivery.All(ld => Exclude(ld)))
            {
                if (ConditionMet(objectToValidate.FamilyName))
                {
                    HandleValidationError(RuleNameConstants.FamilyName_01, objectToValidate.LearnRefNumber);
                }
            }            
        }

        public bool ConditionMet(string familyName)
        {
            return string.IsNullOrWhiteSpace(familyName);
        }

        public bool Exclude(MessageLearnerLearningDelivery learningDelivery)
        {
            return learningDelivery.FundModel == 10
                || (learningDelivery.FundModel == 99 && _messageLearnerLearningDeliveryLearningDeliveryFAMQueryService.HasLearningDeliveryFAMCodeForType(learningDelivery.LearningDeliveryFAM, LearningDeliveryFAMTypeConstants.SOF, "108"));
        }
    }
}
