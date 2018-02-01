using ESFA.DC.ILR.ValidationService.ExternalData.Interface;
using ESFA.DC.ILR.ValidationService.ExternalData.ULN.Interface;
using System.Linq;

namespace ESFA.DC.ILR.ValidationService.ExternalData.PriorAttain
{
    public class PriorAttainReferenceDataService : IULNReferenceDataService
    {
        private IReferenceDataCache _referenceDataCache;

        public PriorAttainReferenceDataService(IReferenceDataCache referenceDataCache)
        {
            _referenceDataCache = referenceDataCache;
        }

        public bool Exists(long priorAttain)
        {
            return _referenceDataCache.PriorAttains.Contains(priorAttain);
        }
    }
}
