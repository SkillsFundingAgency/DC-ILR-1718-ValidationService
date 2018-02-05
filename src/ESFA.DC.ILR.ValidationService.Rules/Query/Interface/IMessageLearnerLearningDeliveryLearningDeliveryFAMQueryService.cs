using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.Model.Interface;
using System.Collections.Generic;

namespace ESFA.DC.ILR.ValidationService.Rules.Query.Interface
{
    public interface IMessageLearnerLearningDeliveryLearningDeliveryFAMQueryService
    {
        bool HasAnyLearningDeliveryFAMCodesForType(IEnumerable<ILearningDeliveryFAM> learningDeliveryFAMs, string famType, IEnumerable<string> famCodes);
        bool HasLearningDeliveryFAMCodeForType(IEnumerable<ILearningDeliveryFAM> learningDeliveryFAMs, string famType, string famCode);
        bool HasLearningDeliveryFAMType(IEnumerable<ILearningDeliveryFAM> learningDeliveryFAMs, string famType);
    }
}
