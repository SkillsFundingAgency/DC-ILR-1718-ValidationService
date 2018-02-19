using System.Collections.Generic;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.Tests.Model;
using ESFA.DC.ILR.ValidationService.Interface;

namespace ESFA.DC.ILR.ValidationService.Console.Stubs
{
    public class ValidationItemProviderServiceStub : IValidationItemProviderService<ILearner>
    {
        public IEnumerable<ILearner> Provide(IValidationContext validationContext)
        {
            return new List<TestLearner>()
            {
                new TestLearner()
                {
                    AccomNullable = 1
                },
                new TestLearner()
                {
                    AccomNullable = 5
                }
            };
        }
    }
}
