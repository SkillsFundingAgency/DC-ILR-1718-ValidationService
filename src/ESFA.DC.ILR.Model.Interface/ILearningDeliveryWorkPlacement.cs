using System;

namespace ESFA.DC.ILR.Model.Interface
{
    public interface ILearningDeliveryWorkPlacement
    {
        DateTime? WorkPlaceStartDateNullable { get; }
        DateTime? WorkPlaceEndDateNullable { get; }
        long? WorkPlaceHoursNullable { get; }
        long? WorkPlaceModeNullable { get; }
        long? WorkPlaceEmpIdNullable { get; }
    }
}
