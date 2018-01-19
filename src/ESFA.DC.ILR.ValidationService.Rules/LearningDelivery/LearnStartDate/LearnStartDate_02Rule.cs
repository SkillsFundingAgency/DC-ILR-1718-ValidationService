using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using System;

namespace ESFA.DC.ILR.ValidationService.Rules.LearningDelivery.LearnStartDate
{
    public class LearnStartDate_02Rule : AbstractRule, IRule<MessageLearner>
    {
        private readonly IValidationDataService _validationDataService;

        public LearnStartDate_02Rule(IValidationDataService validationDataService, IValidationErrorHandler validationErrorHandler)
            : base(validationErrorHandler)
        {
            _validationDataService = validationDataService;
        }

        public void Validate(MessageLearner objectToValidate)
        {
            foreach (var learningDelivery in objectToValidate.LearningDelivery)
            {
                if (ConditionMet(learningDelivery.LearnStartDate, _validationDataService.AcademicYearStart))
                {
                    HandleValidationError(RuleNameConstants.LearnStartDate_02, objectToValidate.LearnRefNumber, learningDelivery.AimSeqNumberNullable);
                }
            }
        }

        public bool ConditionMet(DateTime learnStartDate, DateTime academicYearStart)
        {
            return learnStartDate < academicYearStart.AddYears(-10);
        }
    }
}
