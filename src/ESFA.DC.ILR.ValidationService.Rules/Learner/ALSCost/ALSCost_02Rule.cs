using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.ALSCost
{

    /// <summary>
    /// Learner.ALSCost not null and LearnerFAM.LearnFAMType not HNS
    /// </summary>
    public class ALSCost_02Rule : AbstractRule, IRule<ILearner>
    {
        
        private const string HnsFamCode = "HNS";

        public ALSCost_02Rule(IValidationErrorHandler validationErrorHandler)
            : base(validationErrorHandler)
        {
            
        }

        public void Validate(ILearner objectToValidate)
        {
            if (ConditionMet(objectToValidate.ALSCostNullable,objectToValidate.LearnerFAMs))
            {
                HandleValidationError(RuleNameConstants.ALSCost_02Rule, objectToValidate.LearnRefNumber);
            }
            
        }
        public bool ConditionMet(long? aLsCostNullable, IReadOnlyCollection<ILearnerFAM> learnerFams)
        {
            return aLsCostNullable.HasValue && !HasAnyHnsLearnerFam(learnerFams);
        }
        ///TODO: Not sure if this Learner FAM will be used elsewhere as well - If it is then this can be extracted out as a query service of its own like learning delivery fam service
        public bool HasAnyHnsLearnerFam(IReadOnlyCollection<ILearnerFAM> learnerFams)
        {
            return learnerFams!=null && learnerFams.Any(x => x.LearnFAMType == HnsFamCode);
        }
    }
}
