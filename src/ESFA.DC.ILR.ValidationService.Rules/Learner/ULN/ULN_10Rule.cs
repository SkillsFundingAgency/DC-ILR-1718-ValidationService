using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.ExternalData.FileDataService.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using ESFA.DC.ILR.ValidationService.Rules.Query.Interface;
using System;
using System.Linq;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.ULN
{
    public class ULN_10Rule : AbstractRule, IRule<MessageLearner>
    {
        private readonly IFileDataService _fileDataService;
        private readonly IValidationDataService _validationDataService;
        private readonly ILearningDeliveryFAMQueryService _messageLearnerLearningDeliveryLearningDeliveryFAMQueryService;

        public ULN_10Rule(IFileDataService fileDataService, IValidationDataService validationDataService, ILearningDeliveryFAMQueryService messageLearnerLearningDeliveryLearningDeliveryFAMQueryService, IValidationErrorHandler validationErrorHandler)
            : base(validationErrorHandler)
        {
            _fileDataService = fileDataService;
            _validationDataService = validationDataService;
            _messageLearnerLearningDeliveryLearningDeliveryFAMQueryService = messageLearnerLearningDeliveryLearningDeliveryFAMQueryService;
        }

        public void Validate(MessageLearner objectToValidate)
        {
            foreach (var learningDelivery in objectToValidate.LearningDelivery.Where(ld => !Exclude(ld)))
            {
                if (ConditionMet(learningDelivery.FundModel,
                    _messageLearnerLearningDeliveryLearningDeliveryFAMQueryService.HasLearningDeliveryFAMCodeForType(learningDelivery.LearningDeliveryFAM, LearningDeliveryFAMTypeConstants.SOF, "1"),
                    objectToValidate.ULN,
                    _fileDataService.FilePreparationDate,
                    _validationDataService.AcademicYearJanuaryFirst,
                    learningDelivery.LearnStartDateNullable,
                    learningDelivery.LearnPlanEndDateNullable,
                    learningDelivery.LearnActEndDateNullable))
                {
                    HandleValidationError(RuleNameConstants.ULN_10, objectToValidate.LearnRefNumber, learningDelivery.AimSeqNumberNullable);
                }
            }
        }

        public bool ConditionMet(long fundModel, bool hasSOFCodeOne, long uln, DateTime filePreparationDate, DateTime academicYearJanuaryFirst, DateTime? learnStartDate, DateTime? learnPlanEndDate, DateTime? learnActEndDate)
        {
            return FundModelConditionMet(fundModel)
                && FAMConditionMet(hasSOFCodeOne)
                && FilePreparationDateConditionMet(filePreparationDate, academicYearJanuaryFirst)
                && LearningDatesConditionMet(learnStartDate, learnPlanEndDate, learnActEndDate, filePreparationDate)
                && UlnConditionMet(uln);
        }

        public bool FundModelConditionMet(long fundModel)
        {
            return fundModel == 99;
        }

        public bool FAMConditionMet(bool hasSOFCodeOne)
        {
            return hasSOFCodeOne;
        }

        public bool FilePreparationDateConditionMet(DateTime filePreparationDate, DateTime academicYearJanuaryFirst)
        {
            return filePreparationDate >= academicYearJanuaryFirst;
        }

        public bool LearningDatesConditionMet(DateTime? learnStartDate, DateTime? learnPlanEndDate, DateTime? learnActEndDate, DateTime filePreparationDate)
        {
            return ((learnPlanEndDate - learnStartDate).Value.TotalDays >= 5
                || (learnActEndDate.HasValue && (learnActEndDate - learnStartDate).Value.TotalDays >= 5))
                && (filePreparationDate - learnStartDate).Value.TotalDays <= 60;
        }

        public bool UlnConditionMet(long uln)
        {
            return uln == ValidationConstants.TemporaryULN;
        }

        public bool Exclude(MessageLearnerLearningDelivery learningDelivery)
        {
            return _messageLearnerLearningDeliveryLearningDeliveryFAMQueryService.HasLearningDeliveryFAMCodeForType(learningDelivery.LearningDeliveryFAM, LearningDeliveryFAMTypeConstants.LDM, "034");
        }
    }
}
