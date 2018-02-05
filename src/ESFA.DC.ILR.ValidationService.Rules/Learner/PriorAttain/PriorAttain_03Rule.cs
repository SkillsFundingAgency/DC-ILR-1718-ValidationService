using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.ExternalData.PriorAttain.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.PriorAttain
{
    public class PriorAttain_03Rule : AbstractRule, IRule<ILearner>
    {
        private readonly IPriorAttainReferenceDataService _priorAttainReferenceDataService;

        public PriorAttain_03Rule(IPriorAttainReferenceDataService priorAttainReferenceDataService, IValidationErrorHandler validationErrorHandler)
           : base(validationErrorHandler)
        {
            _priorAttainReferenceDataService = priorAttainReferenceDataService;
        }

        public void Validate(ILearner objectToValidate)
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
