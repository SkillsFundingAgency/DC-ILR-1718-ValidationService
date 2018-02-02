using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Model
{
    public partial class MessageHeader : IMessageHeader
    {
        public IMessageHeaderCollectionDetails CollectionDetailsEntity
        {
            get { return collectionDetailsField; }
        }

        public IMessageHeaderSource SourceEntity
        {
            get { return sourceField; }
        }
    }
}
