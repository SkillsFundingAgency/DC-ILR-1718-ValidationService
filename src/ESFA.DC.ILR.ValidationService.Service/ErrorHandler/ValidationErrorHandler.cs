using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Service.ErrorHandler.Model;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ESFA.DC.ILR.ValidationService.Service.ErrorHandler
{
    public class ValidationErrorHandler : IValidationErrorHandler
    {
        private readonly ConcurrentBag<ValidationError> _errorbag = new ConcurrentBag<ValidationError>();

        public ConcurrentBag<ValidationError> ErrorBag
        {
            get
            {
                return _errorbag;
            }
        }

        public void Handle(string ruleName, string learnRefNumber = null, long? aimSequenceNumber = null, IEnumerable<string> errorMessageParameters = null)
        {
            _errorbag.Add(new ValidationError(ruleName, learnRefNumber, aimSequenceNumber, errorMessageParameters));
        }
    }
}