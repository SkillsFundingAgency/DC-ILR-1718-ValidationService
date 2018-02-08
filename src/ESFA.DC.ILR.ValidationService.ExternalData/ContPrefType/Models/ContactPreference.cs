using System;

namespace ESFA.DC.ILR.ValidationService.ExternalData.ContPrefType.Models
{
    public class ContactPreference
    {
        public int Code { get; set; }
        public string Type { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
