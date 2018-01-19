using System.Collections.Generic;

namespace ESFA.DC.ILR.ValidationService.Service.ErrorHandler.Model
{
    public struct ValidationError
    {
        public ValidationError(string ruleName, string learnerRefernenceNumber, long? aimSequenceNumber = null,  IEnumerable<string> errorMessageParameters = null)
        {
            LearnerReferenceNumber = learnerRefernenceNumber;
            AimSequenceNumber = aimSequenceNumber;
            RuleName = ruleName;
            ErrorMessageParameters = errorMessageParameters;
        }

        public string LearnerReferenceNumber { get; private set; }

        public long? AimSequenceNumber { get; private set; }

        public string RuleName { get; private set; }

        public IEnumerable<string> ErrorMessageParameters { get; private set; }
    }
}