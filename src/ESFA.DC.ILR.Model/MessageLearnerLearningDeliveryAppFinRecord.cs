using System;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Model
{
    public partial class MessageLearnerLearningDeliveryAppFinRecord : IAppFinRecord
    {
        public long? AFinCodeNullable
        {
            get { return aFinCodeFieldSpecified ? (long?)aFinCodeField : null; }
        }

        public DateTime? AFinDateNullable
        {
            get { return aFinDateFieldSpecified ? (DateTime?)aFinDateField : null; }
        }

        public long? AFinAmountNullable
        {
            get { return aFinAmountFieldSpecified ? (long?)aFinAmountField : null; }
        }
    }
}
