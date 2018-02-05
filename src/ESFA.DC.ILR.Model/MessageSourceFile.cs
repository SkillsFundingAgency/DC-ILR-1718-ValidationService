using System;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Model
{
    public partial class MessageSourceFile : ISourceFile
    {
        public DateTime? DateTimeNullable
        {
            get
            {
                return dateTimeFieldSpecified ? (DateTime?)dateTimeField : null;
            }
        }        
    }
}
