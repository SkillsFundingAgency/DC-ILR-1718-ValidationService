using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using ESFA.DC.ILR.ValidationService.Rules.Constants;
using ESFA.DC.ILR.ValidationService.Rules.Derived.Interface;
using System;

namespace ESFA.DC.ILR.ValidationService.Rules.LearningDelivery.LearnStartDate
{
    public class LearnStartDate_12Rule : AbstractRule, IRule<MessageLearner>
    {
        private readonly IDD07 _dd07;
        private readonly IValidationDataService _validationDataService;

        public LearnStartDate_12Rule(IDD07 dd07, IValidationDataService validationDataService, IValidationErrorHandler validationErrorHandler)
            : base(validationErrorHandler)
        {
            _dd07 = dd07;
            _validationDataService = validationDataService;
        }

        public void Validate(MessageLearner objectToValidate)
        {
            foreach (var learningDelivery in objectToValidate.LearningDelivery)
            {
                if (ConditionMet(learningDelivery.LearnStartDate, _validationDataService.AcademicYearEnd, _dd07.Derive(learningDelivery.ProgType)))
                {
                    HandleValidationError(RuleNameConstants.LearnStartDate_12, objectToValidate.LearnRefNumber, learningDelivery.AimSeqNumberNullable);
                }
            }
        }

        public bool ConditionMet(DateTime learnStartDate, DateTime academicYearEnd, string dd07)
        {
            return dd07 == ValidationConstants.Y
                && learnStartDate > academicYearEnd.AddYears(1);
        }
    }
}
