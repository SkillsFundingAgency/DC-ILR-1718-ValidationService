using System;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Model
{
    public partial class MessageLearnerLearningDeliveryLearningDeliveryWorkPlacement : ILearningDeliveryWorkPlacement
    {
        public DateTime? WorkPlaceStartDateNullable
        {
            get { return workPlaceStartDateFieldSpecified ? (DateTime?)workPlaceStartDateField : null; }
        }

        public DateTime? WorkPlaceEndDateNullable
        {
            get { return workPlaceEndDateFieldSpecified ? (DateTime?)workPlaceEndDateField : null;  }
        }

        public long? WorkPlaceHoursNullable
        {
            get { return workPlaceHoursFieldSpecified ? (long?)workPlaceHoursField : null;  }
        }

        public long? WorkPlaceModeNullable
        {
            get { return workPlaceModeFieldSpecified ? (long?)workPlaceModeField : null; }
        }

        public long? WorkPlaceEmpIdNullable
        {
            get { return workPlaceEmpIdFieldSpecified ? (long?)workPlaceEmpIdField : null; }
        }
    }
}
