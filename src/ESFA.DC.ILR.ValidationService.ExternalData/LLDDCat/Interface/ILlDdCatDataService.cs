using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR.ValidationService.ExternalData.LLDDCat.Interface
{
    public interface ILlddCatDataService
    {
        bool CategoryExists(long? cocategory);
        bool CategoryExistForDate(long? category, DateTime? validTo);
    }
}