using System;
using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using ESFA.DC.ILR.ValidationService.Rules.Constants;
using ESFA.DC.ILR.ValidationService.Rules.Derived.Interface;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.PrimaryLLDD
{
    /// <summary>
    /// There is more than one occurrence of LLDDandHealthProblem record where LLDDandHealthProblem.PrimaryLLDD = 1
    /// </summary>
    public class PrimaryLLDD_03Rule : AbstractRule, IRule<ILearner>
    {
        private readonly int ValidPrimaryLldd = 1;
        
        public PrimaryLLDD_03Rule(IValidationErrorHandler validationErrorHandler)
            : base(validationErrorHandler)
        {
            
        }

        public void Validate(ILearner objectToValidate)
        {
            if (ConditionMet(objectToValidate.LLDDAndHealthProblems))
            {
                HandleValidationError(RuleNameConstants.PrimaryLLDD_03Rule, objectToValidate.LearnRefNumber);
            }

        }

        public bool ConditionMet(IReadOnlyCollection<ILLDDAndHealthProblem> lLDDAndHealthProblems)
        {
            return lLDDAndHealthProblems != null &&
                   lLDDAndHealthProblems.Count(x =>
                       x.PrimaryLLDDNullable.HasValue && x.PrimaryLLDDNullable.Value == ValidPrimaryLldd) > 1;
        }


    }
}
