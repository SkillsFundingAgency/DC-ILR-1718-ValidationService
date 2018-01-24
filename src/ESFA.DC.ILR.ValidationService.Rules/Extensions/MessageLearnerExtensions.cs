using ESFA.DC.ILR.Model;
using System;
using System.Linq;

namespace ESFA.DC.ILR.ValidationService.Rules.Extensions
{
    public static class MessageLearnerExtensions
    {
        public static DateTime? BirthdayAt(this MessageLearner learner, int age)
        {
            return learner.DateOfBirthSpecified ? (DateTime?)learner.DateOfBirth.AddYears(age) : null;
        }
    }
}
