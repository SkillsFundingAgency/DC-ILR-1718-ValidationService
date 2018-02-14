using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR.ValidationService.ExternalData.ContPrefType.Interface
{
    public interface IContactPreferenceDataService
    {
        bool TypeExists(string type);
        bool CodeExists(long? code);
        bool TypeForCodeExist(string type, long? code, DateTime? validTo);
    }
}