using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Tests.Model
{
    public class TestContactPreference : IContactPreference
    {
        public string ContPrefType { get; set; }

        public long? ContPrefCodeNullable { get; set; }
    }
}
