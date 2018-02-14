using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.ExternalData.LLDDCat.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using ESFA.DC.ILR.ValidationService.Rules.Constants;
using ESFA.DC.ILR.ValidationService.Rules.Derived.Interface;
using System;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.LLDDCat
{
    /// <summary>
    /// DD06 > 'Valid to' in ILR_LLDDCat
    /// </summary>
    public class LLDDCat_02Rule : AbstractRule, IRule<ILearner>
    {
        private readonly ILlddCatDataService _llddCatDataService;
        private readonly IDD06 _dd06;

        public LLDDCat_02Rule(IValidationErrorHandler validationErrorHandler, ILlddCatDataService llddCatDataService, IDD06 dd06)
            : base(validationErrorHandler)
        {
            _llddCatDataService = llddCatDataService;
            _dd06 = dd06;
        }

        public void Validate(ILearner objectToValidate)
        {
            foreach (var lldcat in objectToValidate.LLDDAndHealthProblems)
            {
                if (ConditionMet(lldcat.LLDDCatNullable, _dd06.Derive(objectToValidate.LearningDeliveries)))
                {
                    HandleValidationError(RuleNameConstants.LLDDCat_02Rule, objectToValidate.LearnRefNumber);
                }
            }
        }

        public bool ConditionMet(long? llddCategory, DateTime? minimumStartDate)
        {
            return llddCategory.HasValue &&
                   !_llddCatDataService.CategoryExistForDate(llddCategory, minimumStartDate);
        }
    }
}