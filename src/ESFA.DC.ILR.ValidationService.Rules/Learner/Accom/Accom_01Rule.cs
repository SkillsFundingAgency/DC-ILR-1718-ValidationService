using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.Accom
{
    public class Accom_01Rule :  AbstractRule, IRule<IMessageLearner>
    {
        private const int AccomValue = 5;
        public Accom_01Rule(IValidationErrorHandler validationErrorHandler)
            : base(validationErrorHandler)
        {
            
        }

        public void Validate(IMessageLearner objectToValidate)
        {
            if (ConditionMet(objectToValidate.AccomNullable))
            {
                HandleValidationError(RuleNameConstants.Accom_01Rule, objectToValidate.LearnRefNumber);
            }
        }

        public bool ConditionMet(long? accomValue)
        {
            return accomValue.HasValue && accomValue.Value != AccomValue;
        }
    }
}
