using System;
using System.Collections.Generic;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Tests.Model
{
    public class TestLearner : ILearner
    {
        public long? AccomNullable { get; set; }

        public string AddLine1 { get; set; }

        public string AddLine2 { get; set; }

        public string AddLine3 { get; set; }

        public string AddLine4 { get; set; }

        public long? ALSCostNullable { get; set; }

        public DateTime? DateOfBirthNullable { get; set; }

        public string Email { get; set; }

        public long? EthnicityNullable { get; set; }

        public string EngGrade { get; set; }

        public string FamilyName { get; set; }

        public string GivenNames { get; set; }

        public string LearnRefNumber { get; set; }

        public long? LLDDHealthProbNullable { get; set; }

        public string MathGrade { get; set; }

        public string NINumber { get; set; }

        public long? PlanEEPHoursNullable { get; set; }

        public long? PlanLearnHoursNullable { get; set; }

        public long? PMUKPRNNullable { get; set; }

        public string Postcode { get; set; }

        public string PostcodePrior { get; set; }

        public string PrevLearnRefNumber { get; set; }

        public long? PrevUKPRNNullable { get; set; }

        public long? PriorAttainNullable { get; set; }

        public long? ULNNullable { get; set; }

        public string Sex { get; set; }

        public string TelNo { get; set; }

        public IReadOnlyCollection<IContactPreference> ContactPreferences { get; set; }

        public IReadOnlyCollection<ILearnerFAM> LearnerFAMs { get; set; }

        public IReadOnlyCollection<ILearningDelivery> LearningDeliveries { get; set; }

        public IReadOnlyCollection<ILLDDAndHealthProblem> LLDDAndHealthProblems { get; set; }

        public IReadOnlyCollection<IProviderSpecLearnerMonitoring> ProviderSpecLearnerMonitorings { get; set; }

        public IReadOnlyCollection<ILearnerEmploymentStatus> LearnerEmploymentStatuses { get; set; }

        public IReadOnlyCollection<ILearnerHE> LearnerHEs { get; set; }
    }
}
