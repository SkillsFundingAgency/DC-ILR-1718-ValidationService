namespace ESFA.DC.ILR.Model.Interface
{
    public interface ILearningDeliveryHE
    {
        string NUMHUS { get; }
        string SSN { get; }
        string QUALENT3 { get; }
        long? SOC2000Nullable { get; }
        long? SECNullable { get; }
        string UCASAPPID { get; }
        long? TYPEYRNullable { get; }
        long? MODESTUDNullable { get; }
        long? FUNDLEVNullable { get; }
        long? FUNDCOMPNullable { get; }
        decimal? STULOADNullable { get; }
        long? YEARSTUNullable { get; }
        long? MSTUFEENullable { get; }
        decimal? PCOLABNullable { get; }
        decimal? PCFLDCSNullable { get; }
        decimal? PCSLDCSNullable { get; }
        decimal? PCTLDCSNullable { get; }
        long? SPECFEENullable { get; }
        long? NETFEENullable { get; }
        long? GROSSFEENullable { get; }
        string DOMICILE { get; }
        long? ELQNullable { get; }
        string HEPostCode { get; }
    }
}
