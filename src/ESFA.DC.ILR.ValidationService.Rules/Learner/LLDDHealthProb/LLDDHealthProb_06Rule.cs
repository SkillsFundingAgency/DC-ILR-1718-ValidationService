using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Constants;
using ESFA.DC.ILR.ValidationService.Rules.Derived.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Learner.LLDDHealthProb.Lookup;
using ESFA.DC.ILR.ValidationService.Rules.Query.Interface;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.LLDDHealthProb
{
    /// <summary>
    /// If the learner's LLDD and health problem is 'Learner does not consider himself or herself to have a learning difficulty and/or disability or health problem', 
    /// then a LLDD and Health Problem record must not be returned
    /// </summary>
    public class LLDDHealthProb_06Rule : AbstractRule, IRule<ILearner>
    {
        private readonly int _validLLDDHealthProblemValue = 1;
        private readonly IDD06 _dd06;
        private readonly ILearningDeliveryFAMQueryService _learningDeliveryFAMQueryService;

        public LLDDHealthProb_06Rule(IValidationErrorHandler validationErrorHandler, IDD06 dd06, ILearningDeliveryFAMQueryService learningDeliveryFAMQueryService)
            : base(validationErrorHandler)
        {
            _dd06 = dd06;
            _learningDeliveryFAMQueryService = learningDeliveryFAMQueryService;
        }

        public void Validate(ILearner objectToValidate)
        {
            if (ConditionMet(objectToValidate.LLDDHealthProbNullable, objectToValidate.LLDDAndHealthProblems))
            {
                HandleValidationError(RuleNameConstants.LLDDHealthProb_04Rule, objectToValidate.LearnRefNumber);
            }
        }

        public bool ConditionMet(long? lldHealthProblem, IReadOnlyCollection<ILLDDAndHealthProblem> llddAndHealthProblems)
        {
            return lldHealthProblem.HasValue &&
                   lldHealthProblem.Value == _validLLDDHealthProblemValue &&
                   (llddAndHealthProblems == null || !llddAndHealthProblems.Any());
        }
    
    }
}
