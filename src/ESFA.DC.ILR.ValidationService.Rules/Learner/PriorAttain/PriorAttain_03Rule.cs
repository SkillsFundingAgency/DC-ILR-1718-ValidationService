using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.ExternalData.PriorAttain;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using ESFA.DC.ILR.ValidationService.Rules.Query.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.PriorAttain
{
    /// <summary>
    /// Learner.PriorAttain is not null and <> valid lookup on ILR_PriorAttain
    /// </summary>
    public class PriorAttain_03Rule : AbstractRule, IRule<IMessageLearner>

    {
        private readonly IPriorAttainReferenceDataService _priorAttainReferenceDataService;

        public PriorAttain_03Rule(IValidationErrorHandler validationErrorHandler, IPriorAttainReferenceDataService priorAttainReferenceDataService)
           : base(validationErrorHandler)
        {
            _priorAttainReferenceDataService = priorAttainReferenceDataService;
        }

        public void Validate(IMessageLearner objectToValidate)
        {
           
            if (ConditionMet(objectToValidate.PriorAttainNullable))
            {
                HandleValidationError(RuleNameConstants.PriorAttain_03Rule, objectToValidate.LearnRefNumber);
            }
        }

        public bool ConditionMet(long? priorAttain)
        {
            return priorAttain.HasValue &&
                    !_priorAttainReferenceDataService.Exists(priorAttain.Value);

        }
        
    }


}
