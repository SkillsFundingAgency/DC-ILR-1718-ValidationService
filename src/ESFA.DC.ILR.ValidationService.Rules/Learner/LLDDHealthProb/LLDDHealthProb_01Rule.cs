using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Constants;
using ESFA.DC.ILR.ValidationService.Rules.Learner.LLDDHealthProb.Lookup;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.LLDDHealthProb
{
    /// <summary>
    /// The learner's LLDD and health problem must be a valid lookup
    /// </summary>
    public class LLDDHealthProb_01Rule : AbstractRule, IRule<ILearner>
    {

        public LLDDHealthProb_01Rule(IValidationErrorHandler validationErrorHandler)
            : base(validationErrorHandler)
        {
        }
        public void Validate(ILearner objectToValidate)
        {
            if (ConditionMet(objectToValidate.LLDDHealthProbNullable))
            {
                HandleValidationError(RuleNameConstants.LLDDHealthProb_01Rule, objectToValidate.LearnRefNumber);
            }
        }

        public bool ConditionMet(long? lldHealthProblem)
        {
            return lldHealthProblem.HasValue &&
                   !LLDDHealthProbLookupData.LLDDHealthProbLookupValues.Contains(lldHealthProblem.Value);
        }
    
    }
}
