﻿using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.ULN
{
    public class ULN_02Rule : IRule<MessageLearner>
    {
        private readonly IValidationErrorHandler _validationErrorHandler;
        private readonly IEnumerable<long> _fundModels = new long[] { 99, 10 };

        public ULN_02Rule(IValidationErrorHandler validationErrorHandler)
        {
            _validationErrorHandler = validationErrorHandler;
        }

        public void Validate(MessageLearner objectToValidate)
        {
            foreach (var learningDelivery in objectToValidate.LearningDelivery.Where(ld => !Exclude(ld)))
            {
                if (ConditionMet(learningDelivery.FundModel, objectToValidate.ULN))
                {
                    _validationErrorHandler.Handle(RuleNameConstants.ULN_02, objectToValidate.LearnRefNumber, learningDelivery.AimSeqNumberNullable);
                }
            }
        }

        public bool ConditionMet(long fundModel, long uln)
        {
            return _fundModels.Contains(fundModel) && uln == ValidationConstants.TemporaryULN;
        }

        public bool Exclude(MessageLearnerLearningDelivery learningDelivery)
        {
            var fam = learningDelivery.LearningDeliveryFAMCodeForType(LearningDeliveryFAMTypeConstants.SOF);

            return fam != null && fam == "1";
        }
    }
}