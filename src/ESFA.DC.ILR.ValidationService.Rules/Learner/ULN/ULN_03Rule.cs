using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.ExternalData.FileDataService.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using ESFA.DC.ILR.ValidationService.Rules.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.ULN
{
    public class ULN_03Rule : AbstractRule, IRule<MessageLearner>
    {
        private readonly IFileDataService _fileDataService;
        private readonly IValidationDataService _validationDataService;

        private readonly IEnumerable<long> _fundModels = new long[] { 25, 82, 35, 36, 81, 70 };

        public ULN_03Rule(IFileDataService fileDataService, IValidationDataService validationDataService, IValidationErrorHandler validationErrorHandler)
            : base(validationErrorHandler)
        {
            _fileDataService = fileDataService;
            _validationDataService = validationDataService;
        }

        public void Validate(MessageLearner objectToValidate)
        {
            foreach (var learningDelivery in objectToValidate.LearningDelivery.Where(ld => !Exclude(ld)))
            {
                if (ConditionMet(learningDelivery.FundModel, objectToValidate.ULN, _fileDataService.FilePreparationDate, _validationDataService.AcademicYearJanuaryFirst))
                {
                    _validationErrorHandler.Handle(RuleNameConstants.ULN_03, objectToValidate.LearnRefNumber, learningDelivery.AimSeqNumberNullable);
                }
            }
        }

        public bool ConditionMet(long fundModel, long uln, DateTime filePreparationDate, DateTime academicYearJanuaryFirst)
        {
            return _fundModels.Contains(fundModel) && uln == ValidationConstants.TemporaryULN && filePreparationDate < academicYearJanuaryFirst;
        }

        public bool Exclude(MessageLearnerLearningDelivery learningDelivery)
        {
            var fam = learningDelivery.LearningDeliveryFAMCodeForType(LearningDeliveryFAMTypeConstants.ACT);

            return fam != null && fam == "1";
        }
    }
}
