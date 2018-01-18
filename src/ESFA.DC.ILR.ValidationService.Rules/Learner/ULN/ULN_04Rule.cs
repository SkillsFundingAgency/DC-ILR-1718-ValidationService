using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using ESFA.DC.ILR.ValidationService.Rules.Derived.Interface;
using System.Linq;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.ULN
{
    public class ULN_04Rule : AbstractRule, IRule<MessageLearner>
    {
        private readonly IDD01 _dd01;

        public ULN_04Rule(IDD01 dd01, IValidationErrorHandler validationErrorHandler) 
            : base(validationErrorHandler)
        {
            _dd01 = dd01;
        }

        public void Validate(MessageLearner objectToValidate)
        {
            if (ConditionMet(objectToValidate.ULN, _dd01.Derive(objectToValidate.ULN)))
            {
                HandleValidationError(RuleNameConstants.ULN_04);
            }
        }

        public bool ConditionMet(long uln, string dd01)
        {
            var ulnString = uln.ToString();

            return (dd01 == ValidationConstants.N 
                || (dd01 != ValidationConstants.Y && ulnString.Length >= 10 && dd01 != ulnString.ElementAt(9).ToString()));
        }
    }
}
