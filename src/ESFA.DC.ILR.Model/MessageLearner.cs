using ESFA.DC.ILR.Model.Interface;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ESFA.DC.ILR.Model
{
    public partial class MessageLearner : ILearner
    {
        [XmlIgnore]
        public long? AccomNullable
        {
            get { return accomFieldSpecified ? (long?)accomField : null; }
        }
        
        [XmlIgnore]
        public long? ALSCostNullable
        {
            get { return aLSCostFieldSpecified ? (long?)aLSCostField : null; }
        }

        [XmlIgnore]
        public DateTime? DateOfBirthNullable
        {
            get { return dateOfBirthFieldSpecified ? (DateTime?)dateOfBirthField : null; }
        }

        [XmlIgnore]
        public long? EthnicityNullable
        {
            get { return ethnicityFieldSpecified ? (long?)ethnicityField : null; }
        }

        [XmlIgnore]
        public long? LLDDHealthProbNullable
        {
            get { return lLDDHealthProbFieldSpecified ? (long?)lLDDHealthProbField : null; }
        }

        [XmlIgnore]
        public long? PlanEEPHoursNullable
        {
            get { return planEEPHoursFieldSpecified ? (long?)planEEPHoursField : null; }
        }

        [XmlIgnore]
        public long? PlanLearnHoursNullable
        {
            get { return planLearnHoursFieldSpecified ? (long?)planLearnHoursField : null; }
        }
        
        [XmlIgnore]
        public long? PMUKPRNNullable
        {
            get { return pMUKPRNFieldSpecified ? (long?)pMUKPRNField : null; }
        }

        [XmlIgnore]
        public long? PrevUKPRNNullable
        {
            get { return prevUKPRNFieldSpecified ? (long?)prevUKPRNField : null; }
        }

        [XmlIgnore]
        public long? PriorAttainNullable
        {
            get { return priorAttainFieldSpecified ? (long?)priorAttainField : null; }
        }
        
        [XmlIgnore]
        public long? ULNNullable
        {
            get { return uLNFieldSpecified ? (long?)uLNField : null; }
        }

        [XmlIgnore]
        public IReadOnlyCollection<IContactPreference> ContactPreferences
        {
            get { return contactPreferenceField; }
        }

        [XmlIgnore]
        public IReadOnlyCollection<ILearnerEmploymentStatus> LearnerEmploymentStatuses
        {
            get { return learnerEmploymentStatusField; }
        }

        [XmlIgnore]
        public IReadOnlyCollection<ILearnerFAM> LearnerFAMs
        {
            get { return learnerFAMField; }
        }

        [XmlIgnore]
        public IReadOnlyCollection<ILearnerHE> LearnerHEs
        {
            get { return learnerHEField; }
        }

        [XmlIgnore]
        public IReadOnlyCollection<ILearningDelivery> LearningDeliveries
        {
            get { return learningDeliveryField; }
        }

        [XmlIgnore]
        public IReadOnlyCollection<ILLDDAndHealthProblem> LLDDAndHealthProblems
        {
            get { return lLDDandHealthProblemField; }
        }

        [XmlIgnore]
        public IReadOnlyCollection<IProviderSpecLearnerMonitoring> ProviderSpecLearnerMonitorings
        {
            get { return providerSpecLearnerMonitoringField; }
        }
    }
}
