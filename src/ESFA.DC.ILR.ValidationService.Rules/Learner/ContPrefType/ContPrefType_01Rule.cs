using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.ExternalData.ContPrefType.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using ESFA.DC.ILR.ValidationService.Rules.Constants;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.ContPrefType
{
    /// <summary>
    /// LearnerContactPreference.ContPrefType is not null and LearnerContactPreference.ContPrefCode <> valid lookup on ILR_ContPrefTypeCode
    /// </summary>
    public class ContPrefType_01Rule : AbstractRule, IRule<ILearner>
    {
        private readonly IContactPreferenceDataService _contactPreferenceDataService;

        public ContPrefType_01Rule(IValidationErrorHandler validationErrorHandler, IContactPreferenceDataService contactPreferenceDataService)
            : base(validationErrorHandler)
        {
            _contactPreferenceDataService = contactPreferenceDataService;
        }

        public void Validate(ILearner objectToValidate)
        {
            foreach (var contactPreference in objectToValidate.ContactPreferences)
            {
                if (ConditionMet(contactPreference.ContPrefType, contactPreference.ContPrefCodeNullable))
                {
                    HandleValidationError(RuleNameConstants.ContPrefType_01Rule, objectToValidate.LearnRefNumber, null);
                }
            }
        }

        public bool ConditionMet(string contactPreferenceType, long? contPrefCode)
        {
            return !string.IsNullOrWhiteSpace(contactPreferenceType) &&
                   !_contactPreferenceDataService.CodeExists(contPrefCode);
        }
    }
}