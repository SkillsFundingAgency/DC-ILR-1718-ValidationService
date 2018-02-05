using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR.Model.Interface
{
    public interface ILearningDelivery
    {
        DateTime? AchDateNullable { get; }
        long? AddHoursNullable { get; }
        long? AimSeqNumberNullable { get; }
        long? AimTypeNullable { get; }
        long? CompStatusNullable { get; }
        string ConRefNumber { get; }
        string DelLocPostCode { get; }
        long? EmpOutcomeNullable { get; }
        string EPAOrgID { get; }
        long? FundModelNullable { get; }
        long? FworkCodeNullable { get; }
        string LearnAimRef { get; }
        DateTime? LearnActEndDateNullable { get; }
        DateTime? LearnPlanEndDateNullable { get; }
        DateTime? LearnStartDateNullable { get; }
        DateTime? OrigLearnStartDateNullable { get; }
        long? OtherFundAdjNullable { get; }
        long? OutcomeNullable { get; }
        string OutGrade { get; }
        long? PartnerUKPRNNullable { get; }
        long? PriorLearnFundAdjNullable { get; }
        long? ProgTypeNullable { get; }
        long? PwayCodeNullable { get; }
        long? StdCodeNullable { get; }
        string SWSupAimId { get; }
        long? WithdrawReasonNullable { get; }

        IReadOnlyCollection<IAppFinRecord> AppFinRecords { get; }
        IReadOnlyCollection<ILearningDeliveryFAM> LearningDeliveryFAMs { get; }
        IReadOnlyCollection<ILearningDeliveryHE> LearningDeliveryHEs { get; }
        IReadOnlyCollection<ILearningDeliveryWorkPlacement> LearningDeliveryWorkPlacements { get; }
        IReadOnlyCollection<IProviderSpecDeliveryMonitoring> ProviderSpecDeliveryMonitorings { get; }        
    }
}
