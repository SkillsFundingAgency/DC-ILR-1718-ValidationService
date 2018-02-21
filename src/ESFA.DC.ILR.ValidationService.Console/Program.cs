using Autofac;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.Console.Modules;
using ESFA.DC.ILR.ValidationService.Console.Stubs;
using ESFA.DC.ILR.ValidationService.Interface;

namespace ESFA.DC.ILR.ValidationService.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var validationContext = new ValidationContextStub();

            var container = BuildContainer();

            using (var scope = container.BeginLifetimeScope())
            {
                var ruleSetOrchestrationService = scope.Resolve<IRuleSetOrchestrationService<ILearner>>();

                ruleSetOrchestrationService.Execute(validationContext);

                var validationErrorHandler = scope.Resolve<IValidationErrorHandler>();
            }
        }

        private static IContainer BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule<ValidationServiceConsoleModule>();

            return containerBuilder.Build();
        }
    }
}
