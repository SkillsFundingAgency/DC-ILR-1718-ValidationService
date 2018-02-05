using System;
using System.Collections.Generic;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Tests.Model
{
    public class LearnerEmploymentStatus : ILearnerEmploymentStatus
    {
        public long? EmpStatNullable { get; set; }

        public DateTime? DateEmpStatAppNullable { get; set; }

        public long? EmpIdNullable { get; set; }

        public IReadOnlyCollection<IEmploymentStatusMonitoring> EmploymentStatusMonitorings { get; set; }
    }
}
