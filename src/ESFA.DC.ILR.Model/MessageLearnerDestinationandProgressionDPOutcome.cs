using System;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Model
{
    public partial class MessageLearnerDestinationandProgressionDPOutcome : IDPOutcome
    {
        public long? OutCodeNullable
        {
            get { return outCodeFieldSpecified ? (long?)outCodeField : null; }
        }

        public DateTime? OutStartDateNullable
        {
            get { return outStartDateFieldSpecified ? (DateTime?)outStartDateField : null; }
        }

        public DateTime? OutEndDateNullable
        {
            get { return outEndDateFieldSpecified ? (DateTime?)outEndDateField : null; }
        }

        public DateTime? OutCollDateNullable
        {
            get { return outCollDateFieldSpecified ? (DateTime?)outCollDateField : null; }
        }
    }
}
