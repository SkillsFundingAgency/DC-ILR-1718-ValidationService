using System;
using System.Xml.Serialization;

namespace ESFA.DC.ILR.Model
{
    public partial class MessageLearner
    {
        [XmlIgnore]
        public long? PrevUKPRNNullable
        {
            get { return prevUKPRNFieldSpecified ? (long?)prevUKPRNField : null;  }
        }

        [XmlIgnore]
        public DateTime? DateOfBirthNullable
        {
            get { return dateOfBirthFieldSpecified ? (DateTime?)dateOfBirthField : null; }
        }
    }
}
