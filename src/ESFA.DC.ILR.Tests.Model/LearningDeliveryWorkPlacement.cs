using System;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Tests.Model
{
    public partial class MessageLearnerLearningDeliveryLearningDeliveryWorkPlacement : ILearningDeliveryWorkPlacement
    {
        public DateTime? WorkPlaceStartDateNullable { get; set; }

        public DateTime? WorkPlaceEndDateNullable { get; set; }

        public long? WorkPlaceHoursNullable { get; set; }

        public long? WorkPlaceModeNullable { get; set; }

        public long? WorkPlaceEmpIdNullable { get; set; }
    }
}
