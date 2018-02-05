using ESFA.DC.ILR.Model.Tests.Abstract;
using Xunit;

namespace ESFA.DC.ILR.Model.Tests
{
    public class MessageLearnerLearningDeliveryLearningDeliveryWorkPlacementTests : AbstractModelTests<MessageLearnerLearningDeliveryLearningDeliveryWorkPlacement>
    {
        [Fact]
        public void WorkPlaceStartDateNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.WorkPlaceStartDate, DateTime(), l => l.WorkPlaceStartDateSpecified, l => l.WorkPlaceStartDateNullable);
        }

        [Fact]
        public void WorkPlaceStartDateNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.WorkPlaceStartDate, DateTime(), l => l.WorkPlaceStartDateSpecified, l => l.WorkPlaceStartDateNullable);
        }

        [Fact]
        public void WorkPlaceEndDateNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.WorkPlaceEndDate, DateTime(), l => l.WorkPlaceEndDateSpecified, l => l.WorkPlaceEndDateNullable);
        }

        [Fact]
        public void WorkPlaceEndDateNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.WorkPlaceEndDate, DateTime(), l => l.WorkPlaceEndDateSpecified, l => l.WorkPlaceEndDateNullable);
        }

        [Fact]
        public void WorkPlaceHoursNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.WorkPlaceHours, Long(), l => l.WorkPlaceHoursSpecified, l => l.WorkPlaceHoursNullable);
        }

        [Fact]
        public void WorkPlaceHoursNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.WorkPlaceHours, Long(), l => l.WorkPlaceHoursSpecified, l => l.WorkPlaceHoursNullable);
        }

        [Fact]
        public void WorkPlaceModeNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.WorkPlaceMode, Long(), l => l.WorkPlaceModeSpecified, l => l.WorkPlaceModeNullable);
        }

        [Fact]
        public void WorkPlaceModeNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.WorkPlaceMode, Long(), l => l.WorkPlaceModeSpecified, l => l.WorkPlaceModeNullable);
        }
        
        [Fact]
        public void WorkPlaceEmpIdNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.WorkPlaceEmpId, Long(), l => l.WorkPlaceEmpIdSpecified, l => l.WorkPlaceEmpIdNullable);
        }

        [Fact]
        public void WorkPlaceEmpIdNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.WorkPlaceEmpId, Long(), l => l.WorkPlaceEmpIdSpecified, l => l.WorkPlaceEmpIdNullable);
        }
    }
}
