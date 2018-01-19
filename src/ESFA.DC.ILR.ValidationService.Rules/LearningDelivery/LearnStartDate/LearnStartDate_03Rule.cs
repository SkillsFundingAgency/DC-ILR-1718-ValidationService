using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using ESFA.DC.ILR.ValidationService.Rules.Derived.Interface;
using System;

namespace ESFA.DC.ILR.ValidationService.Rules.LearningDelivery.LearnStartDate
{
    public class LearnStartDate_03Rule : AbstractRule, IRule<MessageLearner>
    {
        private readonly IDD07 _dd07;
        private readonly IValidationDataService _validationDataService;

        public LearnStartDate_03Rule(IDD07 dd07, IValidationDataService validationDataService, IValidationErrorHandler validationErrorHandler)
            : base(validationErrorHandler)
        {
            _dd07 = dd07;
            _validationDataService = validationDataService;
        }

        public void Validate(MessageLearner objectToValidate)
        {
            foreach (var learningDelivery in objectToValidate.LearningDelivery)
            {
                if (ConditionMet(learningDelivery.LearnStartDate, _validationDataService.AcademicYearEnd, learningDelivery.ProgType, _dd07.Derive(learningDelivery.ProgType)))
                {
                    HandleValidationError(RuleNameConstants.LearnStartDate_03, objectToValidate.LearnRefNumber, learningDelivery.AimSeqNumberNullable);
                }
            }
        }

        public bool ConditionMet(DateTime learnStartDate, DateTime academicYearEnd, long progType, string dd07)
        {
            return dd07 == ValidationConstants.N
                && progType != 24
                && learnStartDate > academicYearEnd;
        }
    }
}
