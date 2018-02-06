using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using ESFA.DC.ILR.ValidationService.Rules.Query.Interface;
using System.Collections.Generic;
using System.Linq;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.GivenNames
{
    public class GivenNames_04Rule : AbstractRule, IRule<MessageLearner>
    {
        private readonly ILearningDeliveryFAMQueryService _learningDeliveryFAMQueryService;

        public GivenNames_04Rule(ILearningDeliveryFAMQueryService learningDeliveryFAMQueryService, IValidationErrorHandler validationErrorHandler)
            : base(validationErrorHandler)
        {
            _learningDeliveryFAMQueryService = learningDeliveryFAMQueryService;
        }

        public void Validate(MessageLearner objectToValidate)
        {
            if (CrossLearningDeliveryConditionMet(objectToValidate.LearningDelivery) && ConditionMet(objectToValidate.PlanLearnHours, objectToValidate.ULN, objectToValidate.GivenNames))
            {
                HandleValidationError(RuleNameConstants.GivenNames_04, objectToValidate.LearnRefNumber);
            }
        }

        public bool CrossLearningDeliveryConditionMet(IEnumerable<MessageLearnerLearningDelivery> learningDeliveries)
        {
            return learningDeliveries != null
                && (learningDeliveries.All(ld => ld.FundModel == 10)
                || learningDeliveries.All(ld => ld.FundModel == 99 && _learningDeliveryFAMQueryService.HasLearningDeliveryFAMCodeForType(ld.LearningDeliveryFAM, LearningDeliveryFAMTypeConstants.SOF, "108")));
        }

        public bool ConditionMet(long planLearnHours, long uln, string givenNames)
        {
            return planLearnHours <= 10 
                && uln != ValidationConstants.TemporaryULN 
                && string.IsNullOrWhiteSpace(givenNames);
        }
    }
}
