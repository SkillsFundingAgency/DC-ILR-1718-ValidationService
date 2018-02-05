using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Tests.Model
{
    public class TestHeader : IHeader
    {
        public ICollectionDetails CollectionDetailsEntity { get; set; }

        public ISource SourceEntity { get; set; }
    }
}
