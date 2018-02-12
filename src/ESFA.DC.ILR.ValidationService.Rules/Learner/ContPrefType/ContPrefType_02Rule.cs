using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using ESFA.DC.ILR.ValidationService.Rules.Constants;
using System.Collections.Generic;
using System.Linq;

namespace ESFA.DC.ILR.ValidationService.Rules.Learner.ContPrefType
{
    /// <summary>
    /// LearnerContactPreference.ContPrefType = RUI and LearnerContactPreference.ContPrefCode = 3, 4 or 5 and (LearnerContactPreference.ContPrefType = PMC or
    /// LearnerContactPreference.ContPrefType = RUI  and LearnerContactPreference.ContPrefCode = 1 or 2 or LearnerContactPreference.ContPrefType = PMC and LearnerContactPreference.ContPrefCode = 3)
    /// </summary>
    public class ContPrefType_02Rule : AbstractRule, IRule<ILearner>
    {
        private readonly string ContactTypeRUI = "RUI";
        private readonly string ContactTypePMC = "PMC";

        public ContPrefType_02Rule(IValidationErrorHandler validationErrorHandler)
            : base(validationErrorHandler)
        {
        }

        public void Validate(ILearner objectToValidate)
        {
            foreach (var contactPreference in objectToValidate.ContactPreferences)
            {
                if (ConditionMet(contactPreference.ContPrefType, contactPreference.ContPrefCodeNullable, objectToValidate.ContactPreferences))
                {
                    HandleValidationError(RuleNameConstants.ContPrefType_02Rule, objectToValidate.LearnRefNumber);
                }
            }
        }

        public bool ConditionMet(string contactPreferenceType, long? contPrefCode, IReadOnlyCollection<IContactPreference> contactPreferences)
        {
            return ConditionMetNotToBeContacted(contactPreferenceType, contPrefCode) &&
                   (ConditionMetContactPMC(contactPreferences) || ConditionMetContactRUI(contactPreferences));
        }

        public bool ConditionMetNotToBeContacted(string contactPreferenceType, long? contPrefCode)
        {
            return !string.IsNullOrWhiteSpace(contactPreferenceType)
                   && contPrefCode.HasValue &&
                   (contactPreferenceType == ContactTypeRUI &&
                    (contPrefCode == 3 || contPrefCode == 4 || contPrefCode == 5));
        }

        public bool ConditionMetContactRUI(IReadOnlyCollection<IContactPreference> contactPreferences)
        {
            return contactPreferences.Any(
                x => (x.ContPrefType == ContactTypeRUI && x.ContPrefCodeNullable.HasValue &&
                       (x.ContPrefCodeNullable.Value == 1 || x.ContPrefCodeNullable.Value == 2)));
        }

        public bool ConditionMetContactPMC(IReadOnlyCollection<IContactPreference> contactPreferences)
        {
            return contactPreferences.Any(x =>
                (x.ContPrefType == ContactTypePMC && x.ContPrefCodeNullable.HasValue &&
                 (x.ContPrefCodeNullable.Value == 1 || x.ContPrefCodeNullable.Value == 2 ||
                  x.ContPrefCodeNullable.Value == 3)));
        }
    }
}