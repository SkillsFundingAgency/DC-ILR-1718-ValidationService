﻿using ESFA.DC.ILR.Model;
using System.Linq;

namespace ESFA.DC.ILR.ValidationService.Rules.Extensions
{
    public static class MessageLearnerLearningDeliveryExtensions
    {
        public static string LearningDeliveryFAMCodeForType(this MessageLearnerLearningDelivery learningDelivery, string famType)
        {
            if (learningDelivery.LearningDeliveryFAM == null)
            {
                return null;
            }

            return learningDelivery.LearningDeliveryFAM.Where(ldfam => ldfam.LearnDelFAMType == famType).Select(ldfam => ldfam.LearnDelFAMCode).FirstOrDefault();
        }
    }
}
