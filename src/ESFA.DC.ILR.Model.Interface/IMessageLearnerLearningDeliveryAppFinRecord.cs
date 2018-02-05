using System;

namespace ESFA.DC.ILR.Model.Interface
{
    public interface IMessageLearnerLearningDeliveryAppFinRecord
    {
        string AFinType { get; }
        long? AFinCodeNullable { get; }
        DateTime? AFinDateNullable { get; }
        long? AFinAmountNullable { get; }        
    }
}
