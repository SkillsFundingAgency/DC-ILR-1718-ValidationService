using ESFA.DC.ILR.ValidationService.ExternalData.LLDDCat.Interface;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DateTime = System.DateTime;

namespace ESFA.DC.ILR.ValidationService.ExternalData.LLDDCat
{
    public class LlddCatDataService : ILlddCatDataService
    {
        private readonly IReadOnlyDictionary<long, DateTime> _validLlddCategories;

        public LlddCatDataService()
        {
            var date2015 = new DateTime(2015, 7, 31);
            var date2099 = new DateTime(2099, 12, 31);
            var categories = new Dictionary<long, DateTime>();

            foreach (int num in Enumerable.Range(4, 14).Concat(Enumerable.Range(93, 7)))
            {
                categories.Add(num, date2099);
            }

            foreach (int num in Enumerable.Range(1, 3))
            {
                categories.Add(num, date2015);
            }

            _validLlddCategories = new ReadOnlyDictionary<long, DateTime>(categories);
        }

        public bool CategoryExists(long? category)
        {
            if (!category.HasValue)
            {
                return false;
            }
            return _validLlddCategories.ContainsKey(category.Value);
        }

        public bool CategoryExistForDate(long? category, DateTime? validTo)
        {
            if (!category.HasValue || !validTo.HasValue)
            {
                return false;
            }
            return _validLlddCategories.ContainsKey(category.Value) &&
                validTo.Value <= _validLlddCategories[category.Value];
        }
    }
}