namespace ESFA.DC.ILR.Model.Interface
{
    public interface IHeader
    {
        ICollectionDetails CollectionDetailsEntity { get; }
        ISource SourceEntity { get; }
    }
}
