using ESFA.DC.ILR.Model.Tests.Abstract;
using Xunit;

namespace ESFA.DC.ILR.Model.Tests
{
    public class MessageLearnerLearningDeliveryLearningDeliveryHETests : AbstractModelTests<MessageLearnerLearningDeliveryLearningDeliveryHE>
    {        
        [Fact]
        public void SOC2000Nullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.SOC2000, Long(), l => l.SOC2000Specified, l => l.SOC2000Nullable);
        }

        [Fact]
        public void SOC2000Nullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.SOC2000, Long(), l => l.SOC2000Specified, l => l.SOC2000Nullable);
        }

        [Fact]
        public void SECNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.SEC, Long(), l => l.SECSpecified, l => l.SECNullable);
        }

        [Fact]
        public void SECNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.SEC, Long(), l => l.SECSpecified, l => l.SECNullable);
        }

        [Fact]
        public void TYPEYRNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.TYPEYR, Long(), l => l.TYPEYRSpecified, l => l.TYPEYRNullable);
        }

        [Fact]
        public void TYPEYRNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.TYPEYR, Long(), l => l.TYPEYRSpecified, l => l.TYPEYRNullable);
        }
        
        [Fact]
        public void MODESTUDNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.MODESTUD, Long(), l => l.MODESTUDSpecified, l => l.MODESTUDNullable);
        }

        [Fact]
        public void MODESTUDNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.MODESTUD, Long(), l => l.MODESTUDSpecified, l => l.MODESTUDNullable);
        }

        [Fact]
        public void FUNDLEVNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.FUNDLEV, Long(), l => l.FUNDLEVSpecified, l => l.FUNDLEVNullable);
        }

        [Fact]
        public void FUNDLEVNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.FUNDLEV, Long(), l => l.FUNDLEVSpecified, l => l.FUNDLEVNullable);
        }

        [Fact]
        public void FUNDCOMPNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.FUNDCOMP, Long(), l => l.FUNDCOMPSpecified, l => l.FUNDCOMPNullable);
        }

        [Fact]
        public void FUNDCOMPNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.FUNDCOMP, Long(), l => l.FUNDCOMPSpecified, l => l.FUNDCOMPNullable);
        }

        [Fact]
        public void STULOADNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.STULOAD, Long(), l => l.STULOADSpecified, l => l.STULOADNullable);
        }

        [Fact]
        public void STULOADNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.STULOAD, Long(), l => l.STULOADSpecified, l => l.STULOADNullable);
        }

        [Fact]
        public void YEARSTUNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.YEARSTU, Long(), l => l.YEARSTUSpecified, l => l.YEARSTUNullable);
        }

        [Fact]
        public void YEARSTUNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.YEARSTU, Long(), l => l.YEARSTUSpecified, l => l.YEARSTUNullable);
        }

        [Fact]
        public void MSTUFEENullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.MSTUFEE, Long(), l => l.MSTUFEESpecified, l => l.MSTUFEENullable);
        }

        [Fact]
        public void MSTUFEENullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.MSTUFEE, Long(), l => l.MSTUFEESpecified, l => l.MSTUFEENullable);
        }

        [Fact]
        public void PCOLABNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.PCOLAB, Decimal(), l => l.PCOLABSpecified, l => l.PCOLABNullable);
        }

        [Fact]
        public void PCOLABNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.PCOLAB, Decimal(), l => l.PCOLABSpecified, l => l.PCOLABNullable);
        }

        [Fact]
        public void PCFLDCSNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.PCFLDCS, Decimal(), l => l.PCFLDCSSpecified, l => l.PCFLDCSNullable);
        }

        [Fact]
        public void PCFLDCSNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.PCFLDCS, Decimal(), l => l.PCFLDCSSpecified, l => l.PCFLDCSNullable);
        }

        [Fact]
        public void PCSLDCSNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.PCSLDCS, Decimal(), l => l.PCSLDCSSpecified, l => l.PCSLDCSNullable);
        }

        [Fact]
        public void PCSLDCSNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.PCSLDCS, Decimal(), l => l.PCSLDCSSpecified, l => l.PCSLDCSNullable);
        }

        [Fact]
        public void PCTLDCSNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.PCTLDCS, Decimal(), l => l.PCTLDCSSpecified, l => l.PCTLDCSNullable);
        }

        [Fact]
        public void PCTLDCSNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.PCTLDCS, Decimal(), l => l.PCTLDCSSpecified, l => l.PCTLDCSNullable);
        }

        [Fact]
        public void SPECFEENullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.SPECFEE, Long(), l => l.SPECFEESpecified, l => l.SPECFEENullable);
        }

        [Fact]
        public void SPECFEENullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.SPECFEE, Long(), l => l.SPECFEESpecified, l => l.SPECFEENullable);
        }

        [Fact]
        public void NETFEENullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.NETFEE, Long(), l => l.NETFEESpecified, l => l.NETFEENullable);
        }

        [Fact]
        public void NETFEENullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.NETFEE, Long(), l => l.NETFEESpecified, l => l.NETFEENullable);
        }

        [Fact]
        public void ELQNullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.ELQ, Long(), l => l.ELQSpecified, l => l.ELQNullable);
        }

        [Fact]
        public void ELQNullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.ELQ, Long(), l => l.ELQSpecified, l => l.ELQNullable);
        }

        [Fact]
        public void GROSSFEENullable_Specified_True()
        {
            TestNullableSpecifiedTrue(l => l.GROSSFEE, Long(), l => l.GROSSFEESpecified, l => l.GROSSFEENullable);
        }

        [Fact]
        public void GROSSFEENullable_Specified_False()
        {
            TestNullableSpecifiedFalse(l => l.GROSSFEE, Long(), l => l.GROSSFEESpecified, l => l.GROSSFEENullable);
        }        
    }
}
