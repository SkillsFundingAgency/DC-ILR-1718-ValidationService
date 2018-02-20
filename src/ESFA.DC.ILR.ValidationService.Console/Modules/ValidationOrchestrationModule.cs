using Autofac;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.Console.Stubs;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.RuleSet;
using ESFA.DC.ILR.ValidationService.Service.ErrorHandler;

namespace ESFA.DC.ILR.ValidationService.Console.Modules
{
    public class ValidationOrchestrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RuleSetOrchestrationService<ILearner>>().As<IRuleSetOrchestrationService<ILearner>>();
            builder.RegisterType<AutoFacRuleSetResolutionService<ILearner>>().As<IRuleSetResolutionService<ILearner>>();
            builder.RegisterType<RuleSetExecutionService<ILearner>>().As<IRuleSetExecutionService<ILearner>>();
            builder.RegisterType<ValidationItemProviderServiceStub>().As<IValidationItemProviderService<ILearner>>();
            builder.RegisterType<ValidationErrorHandler>().As<IValidationErrorHandler>().InstancePerLifetimeScope();
        }
    }
}
