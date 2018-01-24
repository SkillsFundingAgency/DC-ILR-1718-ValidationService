using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.Model.Interface;
using System.Collections.Generic;

namespace ESFA.DC.ILR.ValidationService.Rules.Query.Interface
{
    public interface IMessageLearnerLearningDeliveryLearningDeliveryFAMQueryService
    {
        string LearningDeliveryFAMCodeForType(IEnumerable<IMessageLearnerLearningDeliveryLearningDeliveryFAM> learningDeliveryFAMs, string famType);
        bool HasLearningDeliveryFAMCodeForType(IEnumerable<IMessageLearnerLearningDeliveryLearningDeliveryFAM> learningDeliveryFAMs, string famType, string famCode);
    }
}
