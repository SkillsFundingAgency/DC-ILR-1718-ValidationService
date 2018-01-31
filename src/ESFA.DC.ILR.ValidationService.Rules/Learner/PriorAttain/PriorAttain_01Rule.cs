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
    /// The Prior attainment code must be returned
    //Exclusion : This rule is not triggered by community learning aims (LearningDelivery.FundModel = 10) or 
    //(LearningDelivery.FundModel = 99 and  (LearningDeliveryFAM.LearnDelFAMType = SOF and LearningDeliveryFAM.LearnDelFAMCode = 108)).  
    //This rule is also not triggered by EFA funded learners (LearningDelivery.FundModel = 25 or 82)
    /// </summary>
    public class PriorAttain_01Rule : AbstractRule, IRule<IMessageLearner>

    {
        private readonly IMessageLearnerLearningDeliveryLearningDeliveryFAMQueryService _famQueryService;

        public PriorAttain_01Rule(IValidationErrorHandler validationErrorHandler, IMessageLearnerLearningDeliveryLearningDeliveryFAMQueryService famQueryService)
           : base(validationErrorHandler)
        {
            _famQueryService = famQueryService;
        }

        public void Validate(IMessageLearner objectToValidate)
        {
           
            foreach (var learningDelivery in objectToValidate.LearningDeliveries.Where(ld => !Exclude(ld)))
            {
                if (ConditionMet(objectToValidate.PriorAttainNullable))
                {
                    HandleValidationError(RuleNameConstants.PriorAttain_01Rule, objectToValidate.LearnRefNumber, learningDelivery.AimSeqNumberNullable);
                }
            }

        }
        

        public bool ConditionMet(long? priorAttain)
        {
            return !priorAttain.HasValue;

        }
        public bool Exclude(IMessageLearnerLearningDelivery learningDelivery)
        {

            var condition1 = learningDelivery.FundModelNullable.HasValue &&
                            (learningDelivery.FundModelNullable.Value == 10 ||
                            learningDelivery.FundModelNullable.Value == 25 ||
                            learningDelivery.FundModelNullable.Value == 82);

            var condition2 = learningDelivery.FundModelNullable.HasValue &&
                            (learningDelivery.FundModelNullable.Value == 99
                            && _famQueryService.HasLearningDeliveryFAMCodeForType(
                            learningDelivery.LearningDeliveryFAMs, LearningDeliveryFAMTypeConstants.SOF, "108"));

            return condition1 || condition2;
        }
    }


}
