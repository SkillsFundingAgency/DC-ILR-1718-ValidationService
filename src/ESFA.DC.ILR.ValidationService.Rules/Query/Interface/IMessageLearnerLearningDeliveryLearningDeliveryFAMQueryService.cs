using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.Model.Interface;
using System.Collections.Generic;

namespace ESFA.DC.ILR.ValidationService.Rules.Query.Interface
{
    public interface IMessageLearnerLearningDeliveryLearningDeliveryFAMQueryService
    {
        bool HasAnyLearningDeliveryFAMCodesForType(IEnumerable<IMessageLearnerLearningDeliveryLearningDeliveryFAM> learningDeliveryFAMs, string famType, IEnumerable<string> famCodes);
        bool HasLearningDeliveryFAMCodeForType(IEnumerable<IMessageLearnerLearningDeliveryLearningDeliveryFAM> learningDeliveryFAMs, string famType, string famCode);
        bool HasLearningDeliveryFAMType(IEnumerable<IMessageLearnerLearningDeliveryLearningDeliveryFAM> learningDeliveryFAMs, string famType);
    }
}
