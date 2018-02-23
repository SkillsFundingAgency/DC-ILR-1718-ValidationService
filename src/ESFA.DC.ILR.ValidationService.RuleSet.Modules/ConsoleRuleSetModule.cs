using System;
using System.Collections.Generic;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Learner.Accom;
using ESFA.DC.ILR.ValidationService.Rules.Learner.AddLine1;
using ESFA.DC.ILR.ValidationService.Rules.Learner.ALSCost;
using ESFA.DC.ILR.ValidationService.Rules.Learner.ContPrefType;
using ESFA.DC.ILR.ValidationService.Rules.Learner.DateOfBirth;
using ESFA.DC.ILR.ValidationService.Rules.Learner.EngGrade;
using ESFA.DC.ILR.ValidationService.Rules.Learner.Ethnicity;
using ESFA.DC.ILR.ValidationService.Rules.Learner.FamilyName;
using ESFA.DC.ILR.ValidationService.Rules.Learner.GivenNames;
using ESFA.DC.ILR.ValidationService.RuleSet.Modules.Abstract;

namespace ESFA.DC.ILR.ValidationService.RuleSet.Modules
{
    public class ConsoleRuleSetModule : AbstractRuleSetModule
    {
        public ConsoleRuleSetModule()
        {
            RuleSetType = typeof(IRule<ILearner>);

            Rules = new List<Type>()
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
        }
    }
}
