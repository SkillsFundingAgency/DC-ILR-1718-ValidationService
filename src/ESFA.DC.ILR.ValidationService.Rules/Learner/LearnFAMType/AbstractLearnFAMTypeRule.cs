using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using System;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.LearnFAMType
{
    public abstract class AbstractLearnFAMTypeRule : AbstractRule, IRule<ILearner>
    {
        protected AbstractLearnFAMTypeRule(IValidationErrorHandler validationErrorHandler)
            : base(validationErrorHandler)
        {
        }

        public virtual void Validate(ILearner objectToValidate)
        {
            throw new NotImplementedException();
        }
    }
}