using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.ExternalData.FileDataService.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using ESFA.DC.ILR.ValidationService.Rules.Query.Interface;
using System;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.ULN
{
    public class ULN_09Rule : AbstractRule, IRule<MessageLearner>
    {
        private readonly IFileDataService _fileDataService;
        private readonly IValidationDataService _validationDataService;
        private readonly ILearningDeliveryFAMQueryService _messageLearnerLearningDeliveryLearningDeliveryFAMQueryService;

        public ULN_09Rule(IFileDataService fileDataService, IValidationDataService validationDataService, ILearningDeliveryFAMQueryService messageLearnerLearningDeliveryLearningDeliveryFAMQueryService, IValidationErrorHandler validationErrorHandler)
            : base(validationErrorHandler)
        {
            _fileDataService = fileDataService;
            _validationDataService = validationDataService;
            _messageLearnerLearningDeliveryLearningDeliveryFAMQueryService = messageLearnerLearningDeliveryLearningDeliveryFAMQueryService;
        }

        public void Validate(MessageLearner objectToValidate)
        {
            foreach (var learningDelivery in objectToValidate.LearningDelivery)
            {
                if (ConditionMet(_messageLearnerLearningDeliveryLearningDeliveryFAMQueryService.HasLearningDeliveryFAMCodeForType(learningDelivery.LearningDeliveryFAM, LearningDeliveryFAMTypeConstants.LDM, "034"), _fileDataService.FilePreparationDate, _validationDataService.AcademicYearJanuaryFirst, objectToValidate.ULN))
                {
                    HandleValidationError(RuleNameConstants.ULN_09, objectToValidate.LearnRefNumber, learningDelivery.AimSeqNumberNullable);
                }
            }
        }
        
        public bool ConditionMet(bool famTypeAndCodeMatch, DateTime filePreparationDate, DateTime academicYearJanuaryFirst, long uln)
        {
            return famTypeAndCodeMatch
                && uln == ValidationConstants.TemporaryULN
                && filePreparationDate >= academicYearJanuaryFirst;
        }
    }
}
