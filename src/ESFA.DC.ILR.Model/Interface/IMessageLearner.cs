using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR.Model.Interface
{
    public interface IMessageLearner
    {
        long? AccomNullable { get; }
        string AddLine1 { get; }
        string AddLine2 { get; }
        string AddLine3 { get; }
        string AddLine4 { get; }
        long? ALSCostNullable { get; }
        DateTime? DateOfBirthNullable { get; }
        string Email { get; }
        long? EthnicityNullable { get; }
        string EngGrade { get; }
        string FamilyName { get; }
        string GivenNames { get; }
        string LearnRefNumber { get; }
        long? LLDDHealthProbNullable { get; }
        string MathGrade { get; }
        string NINumber { get; }
        long? PlanEEPHoursNullable { get; }
        long? PlanLearnHoursNullable { get; }
        long? PMUKPRNNullable { get; }
        string Postcode { get; }
        string PostcodePrior { get; }
        string PrevLearnRefNumber { get; }
        long? PrevUKPRNNullable { get; }
        long? PriorAttainNullable { get; }
        long? ULNNullable { get; }
        string Sex { get; }
        string TelNo { get; }

        IReadOnlyCollection<IMessageLearnerContactPreference> ContactPreferences { get; }
        IReadOnlyCollection<IMessageLearnerLearnerFAM> LearnerFAMs { get; }
        IReadOnlyCollection<IMessageLearnerLearningDelivery> LearningDeliveries { get; }
        IReadOnlyCollection<IMessageLearnerLLDDAndHealthProblem> LLDDAndHealthProblems { get; }
        IReadOnlyCollection<IMessageLearnerProviderSpecLearnerMonitoring> ProviderSpecLearnerMonitorings { get; }
        IReadOnlyCollection<IMessageLearnerLearnerEmploymentStatus> LearnerEmploymentStatuses { get; }
        IReadOnlyCollection<IMessageLearnerLearnerHE> LearnerHEs { get; }
    }
}
