using Autofac;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.Console.Stubs;
using ESFA.DC.ILR.ValidationService.ExternalData.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.RuleSet;
using ESFA.DC.ILR.ValidationService.RuleSet.Modules;
using ESFA.DC.ILR.ValidationService.Service.ErrorHandler;

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

            containerBuilder.RegisterType<RuleSetOrchestrationService<ILearner>>().As<IRuleSetOrchestrationService<ILearner>>();
            containerBuilder.RegisterType<AutoFacRuleSetResolutionService<ILearner>>().As<IRuleSetResolutionService<ILearner>>();
            containerBuilder.RegisterType<RuleSetExecutionService<ILearner>>().As<IRuleSetExecutionService<ILearner>>();
            containerBuilder.RegisterType<ReferenceDataCacheStub>().As<IReferenceDataCache>();
            containerBuilder.RegisterType<ReferenceDataCachePopulationServiceStub>().As<IReferenceDataCachePopulationService<ILearner>>();
            containerBuilder.RegisterType<ValidationItemProviderServiceStub>().As<IValidationItemProviderService<ILearner>>();

            containerBuilder.RegisterType<ValidationErrorHandler>().As<IValidationErrorHandler>().InstancePerLifetimeScope();

            containerBuilder.RegisterModule<ConsoleRuleSetModule>();

            return containerBuilder.Build();
        }
    }
}
