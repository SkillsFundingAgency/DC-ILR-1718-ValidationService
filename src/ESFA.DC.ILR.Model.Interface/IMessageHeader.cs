namespace ESFA.DC.ILR.Model.Interface
{
    public interface IMessageHeader
    {
        IMessageHeaderCollectionDetails CollectionDetailsEntity { get; }
        IMessageHeaderSource SourceEntity { get; }
    }
}
