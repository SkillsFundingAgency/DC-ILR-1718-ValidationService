using ESFA.DC.ILR.Model;
using System;
using System.Linq;

namespace ESFA.DC.ILR.ValidationService.Rules.Extensions
{
    public static class MessageLearnerExtensions
    {
        public static DateTime? EarliestLearningDeliveryLearnStartDateFor(this MessageLearner learner, long aimType, long progType, long fworkCode, long pwayCode)
        {
            if (learner.LearningDelivery == null)
            {
                return null;
            }

            return learner.LearningDelivery
                .Where(ld => ld.AimType == aimType && ld.ProgType == progType && ld.FworkCode == fworkCode && ld.PwayCode == pwayCode)
                .OrderBy(ld => ld.LearnStartDate)
                .Select(ld => (DateTime?)ld.LearnStartDate)
                .FirstOrDefault();
        }

        public static DateTime? BirthdayAt(this MessageLearner learner, int age)
        {
            return learner.DateOfBirthSpecified ? (DateTime?)learner.DateOfBirth.AddYears(age) : null;
        }

        public static int? AgeOn(this MessageLearner learner, DateTime reference)
        {
            if (!learner.DateOfBirthSpecified)
            {
                return null;
            }

            int age = reference.Year - learner.DateOfBirth.Year;

            return reference < learner.DateOfBirth.AddYears(age) ? age - 1 : age;
        }
    }
}
