namespace ESFA.DC.ILR.ValidationService.Interface
{
    public interface IRule<T> where T : class
    {
        void Validate(T objectToValidate);
    }
}