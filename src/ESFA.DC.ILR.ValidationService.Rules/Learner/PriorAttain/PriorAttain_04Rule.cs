using ESFA.DC.ILR.Model.Interface;
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
    /// If the prior attainment is level 4 or above, then the learner must not be on an Adult skills funded intermediate or advanced apprenticeship
    /// </summary>
    public class PriorAttain_04Rule : AbstractRule, IRule<IMessageLearner>

    {

        private readonly HashSet<long> _validPriorAttainValues = new HashSet<long> { 4, 5, 10, 11, 12, 13 };

        public PriorAttain_04Rule(IValidationErrorHandler validationErrorHandler)
           : base(validationErrorHandler)
        {
        }

        public void Validate(IMessageLearner objectToValidate)
        {
           
            foreach (var learningDelivery in objectToValidate.LearningDeliveries)
            {
                if (ConditionMet(objectToValidate.PriorAttainNullable,learningDelivery.FundModelNullable,learningDelivery.ProgTypeNullable))
                {
                    HandleValidationError(RuleNameConstants.PriorAttain_04Rule, objectToValidate.LearnRefNumber, learningDelivery.AimSeqNumberNullable);
                }
            }

        }
        

        public bool ConditionMet(long? priorAttain, long? fundModel, long? progType)
        {

            return PriorAttainConditionMet(priorAttain) &&
                    FundModelConditionMet(fundModel) &&
                    ProgTypeConditionMet(progType);

        }

        public bool PriorAttainConditionMet(long? priorAttain)
        {
            
            return priorAttain.HasValue && _validPriorAttainValues.Contains(priorAttain.Value);
        }
        public bool FundModelConditionMet(long? fundModel)
        {
            return fundModel.HasValue && fundModel.Value == 35;
        }

        public bool ProgTypeConditionMet(long? progType)
        {
            return progType.HasValue && (progType.Value == 2 || progType.Value == 3); 
        }

    }


}
