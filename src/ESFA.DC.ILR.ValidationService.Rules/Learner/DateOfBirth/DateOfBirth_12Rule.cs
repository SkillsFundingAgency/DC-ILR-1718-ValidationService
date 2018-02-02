﻿using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using ESFA.DC.ILR.ValidationService.Rules.Query.Interface;
using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.DateOfBirth
{
    public class DateOfBirth_12Rule : AbstractRule, IRule<IMessageLearner>
    {
        private readonly IDateTimeQueryService _dateTimeQueryService;
        private readonly IMessageLearnerLearningDeliveryLearningDeliveryFAMQueryService _messageLearnerLearningDeliveryLearningDeliveryFAMQueryService;

        private readonly IEnumerable<string> famCodes = new HashSet<string> { "1", "2" };

        public DateOfBirth_12Rule(IDateTimeQueryService dateTimeQueryService, IMessageLearnerLearningDeliveryLearningDeliveryFAMQueryService messageLearnerLearningDeliveryLearningDeliveryFAMQueryService, IValidationErrorHandler validationErrorHandler)
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
                    _messageLearnerLearningDeliveryLearningDeliveryFAMQueryService.HasAnyLearningDeliveryFAMCodesForType(learningDelivery.LearningDeliveryFAMs, LearningDeliveryFAMTypeConstants.ASL, famCodes)))
                {
                    HandleValidationError(RuleNameConstants.DateOfBirth_12, objectToValidate.LearnRefNumber, learningDelivery.AimSeqNumberNullable);
                }
            }
        }

        public bool ConditionMet(long? fundModel, DateTime? dateOfBirth, DateTime? learnStartDate, bool hasASLOneorTwo)
        {
            return hasASLOneorTwo
                && fundModel.HasValue
                && fundModel.Value == 10
                && dateOfBirth.HasValue
                && learnStartDate.HasValue
                && _dateTimeQueryService.YearsBetween(dateOfBirth.Value, learnStartDate.Value) < 19;
        }
    }
}