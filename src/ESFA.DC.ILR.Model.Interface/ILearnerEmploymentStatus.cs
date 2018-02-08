using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR.Model.Interface
{
    public interface ILearnerEmploymentStatus
    {
        long? EmpStatNullable { get; }
        DateTime? DateEmpStatAppNullable { get; }
        long? EmpIdNullable { get; }        

        IReadOnlyCollection<IEmploymentStatusMonitoring> EmploymentStatusMonitorings { get; }
    }
}
