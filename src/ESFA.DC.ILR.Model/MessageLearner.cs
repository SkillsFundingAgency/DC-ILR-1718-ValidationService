using ESFA.DC.ILR.Model.Interface;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ESFA.DC.ILR.Model
{
    public partial class MessageLearner : IMessageLearner
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
        
        [XmlIgnore]
        public long? ULNNullable
        {
            get { return uLNFieldSpecified ? (long?)uLNField : null; }
        }

        [XmlIgnore]
        public IReadOnlyCollection<IMessageLearnerLearningDelivery> LearningDeliveries
        {
            get { return learningDeliveryField; }
        }

        [XmlIgnore]
        public long?  PriorAttainNullable
        {
            get { return priorAttainFieldSpecified ? (long?) priorAttainField : null; }
        }
    }
}
