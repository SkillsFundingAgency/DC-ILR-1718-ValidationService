using System;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Tests.Model
{
    public class TestCollectionDetails : ICollectionDetails
    {
        public string CollectionString { get; set; }

        public string YearString { get; set; }

        public DateTime FilePreparationDate { get; set; }
    }
}
