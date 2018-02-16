using System.Linq;
using ESFA.DC.ILR.ValidationService.ExternalData.Interface;
using ESFA.DC.ILR.ValidationService.Interface;

namespace ESFA.DC.ILR.ValidationService.RuleSet
{
    public class RuleSetOrchestrationService<T> : IRuleSetOrchestrationService where T : class
    {
        private readonly IRuleSetResolutionService<T> _ruleSetResolutionService;
        private readonly IRuleSetExecutionService<T> _ruleSetExecutionService;
        private readonly IValidationItemProviderService<T> _validationItemProviderService;
        private readonly IReferenceDataCache _referenceDataCache;
        private readonly IReferenceDataCachePopulationService<T> _referenceDataCachePopulationService;

        public RuleSetOrchestrationService(IRuleSetResolutionService<T> ruleSetResolutionService, IValidationItemProviderService<T> validationItemProviderService, IReferenceDataCache referenceDataCache, IReferenceDataCachePopulationService<T> referenceDataCachePopulationService, IRuleSetExecutionService<T> ruleSetExecutionService)
        {
            _ruleSetResolutionService = ruleSetResolutionService;
            _validationItemProviderService = validationItemProviderService;
            _referenceDataCache = referenceDataCache;
            _referenceDataCachePopulationService = referenceDataCachePopulationService;
            _ruleSetExecutionService = ruleSetExecutionService;
        }

        public void Execute(IValidationContext validationContext)
        {
            var ruleSet = _ruleSetResolutionService.Resolve().ToList();

            var validationItems = _validationItemProviderService.Provide(validationContext).ToList();

            _referenceDataCachePopulationService.Populate(_referenceDataCache, validationItems);

            foreach (var validationItem in validationItems)
            {
                _ruleSetExecutionService.Execute(ruleSet, validationItem);
            }
        }
    }
}
