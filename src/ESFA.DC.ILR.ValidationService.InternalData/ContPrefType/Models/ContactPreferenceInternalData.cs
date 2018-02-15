using System;

namespace ESFA.DC.ILR.ValidationService.InternalData.ContPrefType.Models
{
    public class ContactPreferenceInternalData : IInternalData
    {
        public long Code { get; set; }
        public string Type { get; set; }
        public DateTime ValidTo { get; set; }
    }
}