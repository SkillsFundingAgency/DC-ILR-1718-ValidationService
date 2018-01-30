using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using ESFA.DC.ILR.ValidationService.Rules.Query.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.DateOfBirth
{
    public class DateOfBirth_14Rule : AbstractRule, IRule<IMessageLearner>
    {
        private readonly IDateTimeQueryService _dateTimeQueryService;
        private readonly IMessageLearnerLearningDeliveryLearningDeliveryFAMQueryService _messageLearnerLearningDeliveryLearningDeliveryFAMQueryService;

        private readonly IEnumerable<long?> _fundModels = new HashSet<long?> { 35, 81 };
        
        public DateOfBirth_14Rule(IDateTimeQueryService dateTimeQueryService, IMessageLearnerLearningDeliveryLearningDeliveryFAMQueryService messageLearnerLearningDeliveryLearningDeliveryFAMQueryService, IValidationErrorHandler validationErrorHandler)
            : base(validationErrorHandler)
        {
            _dateTimeQueryService = dateTimeQueryService;
            _messageLearnerLearningDeliveryLearningDeliveryFAMQueryService = messageLearnerLearningDeliveryLearningDeliveryFAMQueryService;
        }

        public void Validate(IMessageLearner objectToValidate)
        {
            foreach (var learningDelivery in objectToValidate.LearningDeliveries)
            {
                if (ConditionMet(
                    learningDelivery.FundModelNullable,
                    objectToValidate.DateOfBirthNullable,
                    learningDelivery.LearnStartDateNullable,
                    _messageLearnerLearningDeliveryLearningDeliveryFAMQueryService.HasLearningDeliveryFAMCodeForType(learningDelivery.LearningDeliveryFAMs, LearningDeliveryFAMTypeConstants.LDM, "034")))
                {
                    HandleValidationError(RuleNameConstants.DateOfBirth_14, objectToValidate.LearnRefNumber, learningDelivery.AimSeqNumberNullable);
                }
            }
        }

        public bool ConditionMet(long? fundModel, DateTime? dateOfBirth, DateTime? learnStartDate, bool hasSOFOne)
        {
            return hasSOFOne
                && fundModel.HasValue
                && _fundModels.Contains(fundModel.Value)
                && dateOfBirth.HasValue
                && learnStartDate.HasValue
                && _dateTimeQueryService.YearsBetween(dateOfBirth.Value, learnStartDate.Value) < 18;
        }
    }
}
