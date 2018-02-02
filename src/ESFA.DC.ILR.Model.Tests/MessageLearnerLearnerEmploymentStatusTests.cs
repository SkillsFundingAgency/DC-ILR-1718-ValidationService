using ESFA.DC.ILR.Model.Tests.Abstract;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.Model.Tests
{
    public class MessageLearnerLearnerEmploymentStatusTests : AbstractModelTests<MessageLearnerLearnerEmploymentStatus>
    {
        [Fact]
        public void EmpStatNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.EmpStat, Long(), l => l.EmpStatSpecified, l => l.EmpStatNullable);
        }

        [Fact]
        public void EmpStatNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.EmpStat, Long(), l => l.EmpStatSpecified, l => l.EmpStatNullable);
        }

        [Fact]
        public void DateEmpStatAppNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.DateEmpStatApp, DateTime(), l => l.DateEmpStatAppSpecified, l => l.DateEmpStatAppNullable);
        }

        [Fact]
        public void DateEmpStatAppNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.DateEmpStatApp, DateTime(), l => l.DateEmpStatAppSpecified, l => l.DateEmpStatAppNullable);
        }

        [Fact]
        public void EmpIdNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.EmpId, Long(), l => l.EmpIdSpecified, l => l.EmpIdNullable);
        }

        [Fact]
        public void EmpIdNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.EmpId, Long(), l => l.EmpIdSpecified, l => l.EmpIdNullable);
        }
        
        [Fact]
        public void EmploymentStatusMonitorings()
        {
            var learnerEmploymentStatus = new MessageLearnerLearnerEmploymentStatus()
            {
                EmploymentStatusMonitoring = new MessageLearnerLearnerEmploymentStatusEmploymentStatusMonitoring[]
                {
                    new MessageLearnerLearnerEmploymentStatusEmploymentStatusMonitoring()
                }
            };

            learnerEmploymentStatus.EmploymentStatusMonitorings.Should().BeSameAs(learnerEmploymentStatus.EmploymentStatusMonitoring);
            learnerEmploymentStatus.EmploymentStatusMonitorings.Should().HaveCount(1);
        }
    }
}
