using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using ESFA.DC.ILR.ValidationService.Rules.Query.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.DateOfBirth
{
    public class DateOfBirth_05Rule : AbstractRule, IRule<IMessageLearner>
    {
        private readonly IDateTimeQueryService _dateTimeQueryService;

        private readonly IEnumerable<long> _fundModels = new HashSet<long>() { 10, 99 };

        public DateOfBirth_05Rule(IDateTimeQueryService dateTimeQueryService, IValidationErrorHandler validationErrorHandler)
            : base(validationErrorHandler)
        {
            _dateTimeQueryService = dateTimeQueryService;
        }

        public void Validate(IMessageLearner objectToValidate)
        {
            foreach (var learningDelivery in objectToValidate.LearningDeliveries)
            {
                if (ConditionMet(objectToValidate.DateOfBirthNullable, learningDelivery.LearnStartDateNullable, learningDelivery.FundModelNullable))
                {
                    HandleValidationError(RuleNameConstants.DateOfBirth_05, objectToValidate.LearnRefNumber, learningDelivery.AimSeqNumberNullable);
                }
            }
        }

        public bool ConditionMet(DateTime? dateOfBirth, DateTime? learnStartDate, long? fundModel)
        {
            return fundModel.HasValue
                && _fundModels.Contains(fundModel.Value)
                && dateOfBirth.HasValue
                && learnStartDate.HasValue
                && _dateTimeQueryService.YearsBetween(dateOfBirth.Value, learnStartDate.Value) < 4;
        }
    }
}
