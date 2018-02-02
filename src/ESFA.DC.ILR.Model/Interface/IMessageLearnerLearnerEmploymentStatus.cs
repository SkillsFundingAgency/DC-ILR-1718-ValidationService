using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR.Model.Interface
{
    public interface IMessageLearnerLearnerEmploymentStatus
    {
        long? EmpStatNullable { get; }
        DateTime? DateEmpStatAppNullable { get; }
        long? EmpIdNullable { get; }        

        IReadOnlyCollection<IMessageLearnerLearnerEmploymentStatusEmploymentStatusMonitoring> EmploymentStatusMonitorings { get; }
    }
}
