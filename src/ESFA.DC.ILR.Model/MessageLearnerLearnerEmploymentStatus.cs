using System;
using System.Collections.Generic;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Model
{
    public partial class MessageLearnerLearnerEmploymentStatus : ILearnerEmploymentStatus
    {
        public long? EmpStatNullable
        {
            get { return empStatFieldSpecified ? (long?)empStatField : null; }
        }

        public DateTime? DateEmpStatAppNullable
        {
            get { return dateEmpStatAppFieldSpecified ? (DateTime?)dateEmpStatAppField : null; }
        }

        public long? EmpIdNullable
        {
            get { return empIdFieldSpecified ? (long?)empIdField : null; }
        }
        
        public IReadOnlyCollection<IEmploymentStatusMonitoring> EmploymentStatusMonitorings
        {
            get { return employmentStatusMonitoringField;  }
        }
    }
}
