namespace ESFA.DC.ILR.ValidationService.Interface
{
    public interface IRuleSetOrchestrationService<T> where T : class
    {
        void Execute(IValidationContext validationContext);
    }
}
