﻿using ESFA.DC.ILR.ValidationService.Rules.Query.Interface;
using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.ValidationService.Rules.Query
{
    public class MessageLearnerLearningDeliveryLearningDeliveryFAMQueryService : IMessageLearnerLearningDeliveryLearningDeliveryFAMQueryService
    {
        public bool HasAnyLearningDeliveryFAMCodesForType(IEnumerable<IMessageLearnerLearningDeliveryLearningDeliveryFAM> learningDeliveryFAMs, string famType, IEnumerable<string> famCodes)
        {
            if (learningDeliveryFAMs == null || famCodes == null)
            {
                return false;
            }

            return learningDeliveryFAMs.Any(ldfam => ldfam.LearnDelFAMType == famType && famCodes.Contains(ldfam.LearnDelFAMCode));            
        }

        public bool HasLearningDeliveryFAMCodeForType(IEnumerable<IMessageLearnerLearningDeliveryLearningDeliveryFAM> learningDeliveryFAMs, string famType, string famCode)
        {
            if (learningDeliveryFAMs == null)
            {
                return false;
            }

            return learningDeliveryFAMs.Any(ldfam => ldfam.LearnDelFAMType == famType && ldfam.LearnDelFAMCode == famCode);
        }

        public bool HasLearningDeliveryFAMType(IEnumerable<IMessageLearnerLearningDeliveryLearningDeliveryFAM> learningDeliveryFAMs, string famType)
        {
            if (learningDeliveryFAMs == null)
            {
                return false;
            }

            return learningDeliveryFAMs.Any(ldfam => ldfam.LearnDelFAMType == famType);
        }        
    }
}
