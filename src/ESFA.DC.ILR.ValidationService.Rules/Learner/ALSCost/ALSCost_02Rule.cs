using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.ValidationService.Rules.Query.Interface;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.ALSCost
{

    /// <summary>
    /// Learner.ALSCost not null and LearnerFAM.LearnFAMType not HNS
    /// </summary>
    public class ALSCost_02Rule : AbstractRule, IRule<IMessageLearner>
    {
        
        private const string HnsFamCode = "HNS";
        private readonly IMessageLearnerFAMQueryService _learnerFamQueryService;

        public ALSCost_02Rule(IValidationErrorHandler validationErrorHandler,IMessageLearnerFAMQueryService learnerFamQueryService)
            : base(validationErrorHandler)
        {
            _learnerFamQueryService = learnerFamQueryService;
        }

        public void Validate(IMessageLearner objectToValidate)
        {
            if (ConditionMet(objectToValidate.ALSCostNullable,objectToValidate.LearnerFAMs))
            {
                HandleValidationError(RuleNameConstants.ALSCost_02Rule, objectToValidate.LearnRefNumber);
            }
            
        }
        public bool ConditionMet(long? aLsCostNullable, IReadOnlyCollection<IMessageLearnerLearnerFAM> learnerFams)
        {
            return aLsCostNullable.HasValue && !_learnerFamQueryService.HasLearnerFAMType(learnerFams,HnsFamCode);
        }
        
    }
}
