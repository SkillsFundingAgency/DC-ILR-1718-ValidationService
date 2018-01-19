using System;
using System.Xml.Serialization;

namespace ESFA.DC.ILR.Model
{
    public partial class MessageLearner
    {
        [XmlIgnore]
        public DateTime? DateOfBirthNullable
        {
            get { return dateOfBirthFieldSpecified ? (DateTime?)dateOfBirthField : null; }
        }

        [XmlIgnore]
        public long? PMUKPRNNullable
        {
            get { return pMUKPRNFieldSpecified ? (long?)pMUKPRNField : null;  }
        }

        [XmlIgnore]
        public long? PrevUKPRNNullable
        {
            get { return prevUKPRNFieldSpecified ? (long?)prevUKPRNField : null;  }
        }
    }
}
