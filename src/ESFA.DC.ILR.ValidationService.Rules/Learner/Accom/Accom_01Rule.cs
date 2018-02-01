using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using ESFA.DC.ILR.ValidationService.Rules.Query.Interface;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.Accom
{
    public class Accom_01Rule :  AbstractRule, IRule<IMessageLearner>
    {
        public Accom_01Rule(IValidationErrorHandler validationErrorHandler)
            : base(validationErrorHandler)
        {
            
        }

        public void Validate(IMessageLearner objectToValidate)
        {
            
            if (ConditionMet(objectToValidate.AccomNullable))
            {
                HandleValidationError(RuleNameConstants.Accom_01Rule, objectToValidate.LearnRefNumber, null);
            }
            

        }


        public bool ConditionMet(long? accomValue)
        {
            return accomValue.HasValue && accomValue.Value != 5;

        }
    }
}
