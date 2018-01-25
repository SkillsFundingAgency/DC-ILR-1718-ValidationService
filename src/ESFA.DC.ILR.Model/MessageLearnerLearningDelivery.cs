using ESFA.DC.ILR.Model.Interface;
using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace ESFA.DC.ILR.Model
{
    public partial class MessageLearnerLearningDelivery : IMessageLearnerLearningDelivery
    {
        [XmlIgnore]
        public long? AimSeqNumberNullable
        {
            get { return aimSeqNumberFieldSpecified ? (long?)aimSeqNumberField : null;  }
        }

        [XmlIgnore]
        public long? FundModelNullable
        {
            get { return fundModelFieldSpecified ? (long?)fundModelField : null; }
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

        public IReadOnlyCollection<IMessageLearnerLearningDeliveryLearningDeliveryFAM> LearningDeliveryFAMs
        {
            get { return learningDeliveryFAMField; }
        }
    }
}
