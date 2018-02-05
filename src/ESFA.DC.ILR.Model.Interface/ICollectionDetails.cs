using System;

namespace ESFA.DC.ILR.Model.Interface
{
    public interface ICollectionDetails
    {
        string CollectionString { get; }
        string YearString { get; }
        DateTime FilePreparationDate { get; }
    }
}
