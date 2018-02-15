namespace ESFA.DC.ILR.ValidationService.Interface
{
    public interface IRuleSetExecutionService<in T> where T: class
    {
        void Execute(T objectToValidate);
    }
}
