﻿using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.ExternalData.FileDataService.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using ESFA.DC.ILR.ValidationService.Rules.Query.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.ULN
{
    public class ULN_06Rule : AbstractRule, IRule<ILearner>
    {
        private readonly IFileDataService _fileDataService;
        private readonly IValidationDataService _validationDataService;
        private readonly ILearningDeliveryFAMQueryService _messageLearnerLearningDeliveryLearningDeliveryFAMQueryService;

        private readonly IEnumerable<long?> _fundModels = new HashSet<long?> { 25, 82, 35, 36, 81, 70 };

        public ULN_06Rule(IFileDataService fileDataService, IValidationDataService validationDataService, ILearningDeliveryFAMQueryService messageLearnerLearningDeliveryLearningDeliveryFAMQueryService, IValidationErrorHandler validationErrorHandler)
            : base(validationErrorHandler)
        {
            _fileDataService = fileDataService;
            _validationDataService = validationDataService;
            _messageLearnerLearningDeliveryLearningDeliveryFAMQueryService = messageLearnerLearningDeliveryLearningDeliveryFAMQueryService;
        }

        public void Validate(ILearner objectToValidate)
        {
            foreach (var learningDelivery in objectToValidate.LearningDeliveries.Where(ld => !Exclude(ld)))
            {
                if (ConditionMet(
                    learningDelivery.FundModelNullable,
                    _messageLearnerLearningDeliveryLearningDeliveryFAMQueryService.HasLearningDeliveryFAMCodeForType(learningDelivery.LearningDeliveryFAMs, LearningDeliveryFAMTypeConstants.ADL, "1"),
                    objectToValidate.ULNNullable,
                    _fileDataService.FilePreparationDate,
                    _validationDataService.AcademicYearJanuaryFirst,
                    learningDelivery.LearnStartDateNullable,
                    learningDelivery.LearnPlanEndDateNullable,
                    learningDelivery.LearnActEndDateNullable))
                {
                    HandleValidationError(RuleNameConstants.ULN_06, objectToValidate.LearnRefNumber, learningDelivery.AimSeqNumberNullable);
                }
            }
        }

        public bool ConditionMet(long? fundModel, bool adlFamCodeOne, long? uln, DateTime filePreparationDate, DateTime academicYearJanuaryFirst, DateTime? learnStartDate, DateTime? learnPlanEndDate, DateTime? learnActEndDate)
        {
            return FundModelConditionMet(fundModel, adlFamCodeOne)
                && FilePreparationDateConditionMet(filePreparationDate, academicYearJanuaryFirst)
                && LearningDatesConditionMet(learnStartDate, learnPlanEndDate, learnActEndDate, filePreparationDate)
                && UlnConditionMet(uln);
        }

        public bool FundModelConditionMet(long? fundModel, bool adlFamCodeOne)
        {
            return _fundModels.Contains(fundModel)
                || (fundModel == 99 && adlFamCodeOne);
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

        public bool UlnConditionMet(long? uln)
        {
            return uln == ValidationConstants.TemporaryULN;
        }

        public bool Exclude(ILearningDelivery learningDelivery)
        {
            return _messageLearnerLearningDeliveryLearningDeliveryFAMQueryService.HasLearningDeliveryFAMCodeForType(learningDelivery.LearningDeliveryFAMs, LearningDeliveryFAMTypeConstants.LDM, "034")
                || _messageLearnerLearningDeliveryLearningDeliveryFAMQueryService.HasLearningDeliveryFAMCodeForType(learningDelivery.LearningDeliveryFAMs, LearningDeliveryFAMTypeConstants.ACT, "1");
        }        
    }
}
