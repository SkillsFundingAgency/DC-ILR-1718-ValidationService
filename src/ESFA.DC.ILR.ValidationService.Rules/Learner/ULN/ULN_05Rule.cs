using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.ExternalData.ULN.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using ESFA.DC.ILR.ValidationService.Rules.Constants;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.ULN
{
    public class ULN_05Rule : AbstractRule, IRule<MessageLearner>
    {
        private readonly IULNReferenceDataService _ulnReferenceDataService;

        public ULN_05Rule(IULNReferenceDataService ulnReferenceDataService, IValidationErrorHandler validationErrorHandler) 
            : base(validationErrorHandler)
        {
            _ulnReferenceDataService = ulnReferenceDataService;
        }

        public void Validate(MessageLearner objectToValidate)
        {
            var uln = objectToValidate.ULN;

            if (ConditionMet(uln, _ulnReferenceDataService.Exists(uln)))
            {
                HandleValidationError(RuleNameConstants.ULN_05, objectToValidate.LearnRefNumber);
            }
        }

        public bool ConditionMet(long uln, bool ulnInReferenceData)
        {
            return !ulnInReferenceData && uln != ValidationConstants.TemporaryULN;
        }
    }
}