using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Model
{
    public partial class MessageLearnerLearningDeliveryLearningDeliveryHE : ILearningDeliveryHE
    {
        public long? SOC2000Nullable
        {
            get { return sOC2000FieldSpecified ? (long?)sOC2000Field : null; }
        }

        public long? SECNullable
        {
            get { return sECFieldSpecified ? (long?)sECField : null; }
        }

        public long? TYPEYRNullable
        {
            get { return tYPEYRFieldSpecified ? (long?)tYPEYRField : null; }
        }

        public long? MODESTUDNullable
        {
            get { return mODESTUDFieldSpecified ? (long?)mODESTUDField : null; }
        }

        public long? FUNDLEVNullable
        {
            get { return fUNDLEVFieldSpecified ? (long?)fUNDLEVField : null; }
        }

        public long? FUNDCOMPNullable
        {
            get { return fUNDCOMPFieldSpecified ? (long?)fUNDCOMPField : null; }
        }

        public decimal? STULOADNullable
        { 
            get { return sTULOADFieldSpecified? (long?) sTULOADField : null; }
        }

        public long? YEARSTUNullable
        {
            get { return yEARSTUFieldSpecified ? (long?)yEARSTUField : null; }
        }

        public long? MSTUFEENullable
        {
            get { return mSTUFEEFieldSpecified ? (long?)mSTUFEEField : null; }
        }

        public decimal? PCOLABNullable
        {
            get { return pCOLABFieldSpecified ? (decimal?)pCOLABField : null; }
        }

        public decimal? PCFLDCSNullable
        {
            get { return pCFLDCSFieldSpecified ? (decimal?)pCFLDCSField : null; }
        }

        public decimal? PCSLDCSNullable
        {
            get { return pCSLDCSFieldSpecified ? (decimal?)pCSLDCSField : null; }
        }

        public decimal? PCTLDCSNullable
        {
            get { return pCTLDCSFieldSpecified ? (decimal?)pCTLDCSField : null; }
        }

        public long? SPECFEENullable
        {
            get { return sPECFEEFieldSpecified ? (long?)sPECFEEField : null; }
        }

        public long? NETFEENullable
        {
            get { return nETFEEFieldSpecified ? (long?)nETFEEField : null; }
        }

        public long? ELQNullable
        {
            get { return eLQFieldSpecified ? (long?)eLQField : null; }
        }

        public long? GROSSFEENullable
        {
            get
            {
                return gROSSFEEFieldSpecified ? (long?)gROSSFEEField : null;
            }
        }
    }
}
