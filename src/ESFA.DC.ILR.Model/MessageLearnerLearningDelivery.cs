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
        public long? AimTypeNullable
        {
            get { return aimTypeFieldSpecified ? (long?)aimTypeField : null; }
        }

        [XmlIgnore]
        public long? FundModelNullable
        {
            get { return fundModelFieldSpecified ? (long?)fundModelField : null; }
        }

        [XmlIgnore]
        public long? FworkCodeNullable
        {
            get { return fworkCodeFieldSpecified ? (long?)fworkCodeField : null; }
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

        [XmlIgnore]
        public long? ProgTypeNullable
        {
            get { return progTypeFieldSpecified ? (long?)progTypeField : null; }
        }

        [XmlIgnore]
        public long? PwayCodeNullable
        {
            get { return pwayCodeFieldSpecified ? (long?)pwayCodeField : null; }
        }

        [XmlIgnore]
        public IReadOnlyCollection<IMessageLearnerLearningDeliveryLearningDeliveryFAM> LearningDeliveryFAMs
        {
            get { return learningDeliveryFAMField; }
        }
    }
}
