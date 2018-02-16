using Autofac;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Learner.Accom;

namespace ESFA.DC.ILR.ValidationService.RuleSet.Modules
{
    public class ConsoleRuleSetModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Accom_01Rule>().As<IRule<ILearner>>();
        }
    }
}
