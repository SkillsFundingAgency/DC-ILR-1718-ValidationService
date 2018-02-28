using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Modules.Modules;
using ESFA.DC.ILR.ValidationService.Rules.Learner.Accom;
using ESFA.DC.ILR.ValidationService.Rules.Learner.AddLine1;
using ESFA.DC.ILR.ValidationService.Rules.Learner.ALSCost;
using ESFA.DC.ILR.ValidationService.Rules.Learner.ContPrefType;
using ESFA.DC.ILR.ValidationService.Rules.Learner.DateOfBirth;
using ESFA.DC.ILR.ValidationService.Rules.Learner.EngGrade;
using ESFA.DC.ILR.ValidationService.Rules.Learner.Ethnicity;
using ESFA.DC.ILR.ValidationService.Rules.Learner.FamilyName;
using ESFA.DC.ILR.ValidationService.RuleSet.Modules.Common;
using FluentAssertions;
using Moq;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.RuleSet.Modules.Tests
{
    public class ConsoleRuleSetModuleTests
    {
        [Fact]
        public void RuleSet()
        {
            var builder = new ContainerBuilder();

            RegisterDependencies(builder);

            builder.RegisterModule<DataModule>();
            builder.RegisterModule<DerivedDataModule>();
            builder.RegisterModule<QueryServiceModule>();
            builder.RegisterModule<ConsoleRuleSetModule>();

            var container = builder.Build();

            var rules = container.Resolve<IEnumerable<IRule<ILearner>>>().ToList();

            rules.Should().ContainItemsAssignableTo<IRule<ILearner>>();

            var ruleTypes = new List<Type>()
            {
                typeof(Accom_01Rule),

                typeof(AddLine1_03Rule),

                typeof(ALSCost_02Rule),

                typeof(ContPrefType_01Rule),
                typeof(ContPrefType_02Rule),
                typeof(ContPrefType_03Rule),

                typeof(DateOfBirth_01Rule),
                typeof(DateOfBirth_02Rule),
                typeof(DateOfBirth_03Rule),
                typeof(DateOfBirth_04Rule),
                typeof(DateOfBirth_05Rule),
                typeof(DateOfBirth_06Rule),
                typeof(DateOfBirth_07Rule),
                typeof(DateOfBirth_10Rule),
                typeof(DateOfBirth_12Rule),
                typeof(DateOfBirth_13Rule),
                typeof(DateOfBirth_14Rule),
                typeof(DateOfBirth_20Rule),
                typeof(DateOfBirth_23Rule),
                typeof(DateOfBirth_24Rule),
                typeof(DateOfBirth_48Rule),

                typeof(EngGrade_01Rule),
                typeof(EngGrade_03Rule),
                typeof(EngGrade_04Rule),

                typeof(Ethnicity_01Rule),

                typeof(FamilyName_01Rule),
                typeof(FamilyName_02Rule),
                typeof(FamilyName_04Rule),
            };

            foreach (var ruleType in ruleTypes)
            {
                rules.Should().ContainSingle(r => r.GetType() == ruleType);
            }

            rules.Should().HaveCount(28);
        }

        private void RegisterDependencies(ContainerBuilder builder)
        {
            builder.RegisterInstance(new Mock<IValidationErrorHandler>().Object).As<IValidationErrorHandler>();
        }
    }
}
