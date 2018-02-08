using ESFA.DC.ILR.Model.Extension;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Model
{
    public partial class MessageHeaderCollectionDetails : ICollectionDetails
    {
        public string CollectionString
        {
            get { return collectionField.XmlEnumToString(); }
        }

        public string YearString
        {
            get { return yearField.XmlEnumToString(); }
        }
    }
}
