using ESFA.DC.ILR.ValidationService.Interface;

namespace ESFA.DC.ILR.ValidationService.Console.Stubs
{
    public class ValidationContextStub : IValidationContext
    {
        public string Input { get; set; }
        public string Output { get; set; }
    }
}
