using System.Collections.Generic;

namespace ESFA.DC.ILR.ValidationService.Interface
{
    public interface IValidationErrorHandler
    {
        void Handle(string ruleName, string learnRefNumer, long? aimSequenceNumber, IEnumerable<string> errorMessageParameters);
    }
}