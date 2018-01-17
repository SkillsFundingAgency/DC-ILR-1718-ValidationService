using System;
using System.Xml.Serialization;

namespace ESFA.DC.ILR.Model
{
    public partial class MessageLearnerLearningDelivery
    {
        [XmlIgnore]
        public long? AimSeqNumberNullable
        {
            get { return aimSeqNumberFieldSpecified ? (long?)aimSeqNumberField : null;  }
        }

        [XmlIgnore]
        public DateTime? LearnStartDateNullable
        {
            get { return learnStartDateFieldSpecified ? (DateTime?)learnStartDateField : null; }
        }

        [XmlIgnore]
        public DateTime? LearnPlanEndDateNullable
        {
            get { return learnPlanEndDateFieldSpecified ? (DateTime?)learnPlanEndDateField : null; }
        }

        [XmlIgnore]
        public DateTime? LearnActEndDateNullable
        {
            get { return learnActEndDateFieldSpecified ? (DateTime?)learnActEndDateField : null; }
        }
    }
}
