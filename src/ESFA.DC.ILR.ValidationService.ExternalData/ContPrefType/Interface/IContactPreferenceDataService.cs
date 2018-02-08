using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR.ValidationService.ExternalData.ContPrefType.Interface
{
    public interface IContactPreferenceDataService
    {
        bool TypeExists(string type);
        bool CodeExists(long? code);
        bool TypeForCodesExist(string type, IEnumerable<long> codes, DateTime validTo);
    }
}