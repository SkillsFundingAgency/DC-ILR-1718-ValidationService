using ESFA.DC.ILR.ValidationService.ExternalData.LARS.Model;
using System.Collections.Generic;

namespace ESFA.DC.ILR.ValidationService.ExternalData.Interface
{
    public interface IReferenceDataCache
    {
        IEnumerable<long> ULNs { get; }

        IDictionary<string, LearningDelivery> LearningDeliveries { get; }

        void Populate(IEnumerable<long> ulns, IEnumerable<string> learnAimRefs);
    }
}
