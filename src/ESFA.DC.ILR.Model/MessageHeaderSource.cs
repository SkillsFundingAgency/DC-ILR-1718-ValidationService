using ESFA.DC.ILR.Model.Extension;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Model
{
    public partial class MessageHeaderSource : IMessageHeaderSource
    {
        public string ProtectiveMarkingString
        {
            get { return protectiveMarkingField.XmlEnumToString(); }
        }
    }
}
