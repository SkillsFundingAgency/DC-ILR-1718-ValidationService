﻿using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using ESFA.DC.ILR.ValidationService.Rules.Query.Interface;
using System.Collections.Generic;
using ESFA.DC.ILR.ValidationService.Rules.Constants;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.EngGrade
{
    /// <summary>
    /// Learner.LearnFAMType = ECF and Learner.LearnFAMCode = 2, 3 or 4 and Learner.EngGrade <> "NONE"
    /// </summary>
    public class EngGrade_04Rule : AbstractRule, IRule<ILearner>
    {
        private readonly ILearnerFAMQueryService _learnerFamQueryService;
        private const string EngGradeNone = "NONE";
        private  readonly HashSet<long> _famCodes = new HashSet<long>() {2,3,4};


        public EngGrade_04Rule(IValidationErrorHandler validationErrorHandler, ILearnerFAMQueryService learnerFamQueryService)
            : base(validationErrorHandler)
        {
            _learnerFamQueryService = learnerFamQueryService;

        }

        public void Validate(ILearner objectToValidate)
        {

            if (ConditionMet(objectToValidate.EngGrade, objectToValidate.LearnerFAMs))
            {
                HandleValidationError(RuleNameConstants.EngGrade_04Rule, objectToValidate.LearnRefNumber);
            }

        }

        public bool ConditionMet(string engGrade, IReadOnlyCollection<ILearnerFAM> learnerFams)
        {
            return !string.IsNullOrWhiteSpace(engGrade) &&
                   engGrade != EngGradeNone &&
                   _learnerFamQueryService.HasAnyLearnerFAMCodesForType(learnerFams, LearnerFamTypeConstants.ECF, _famCodes);

        }
        

    }
}
