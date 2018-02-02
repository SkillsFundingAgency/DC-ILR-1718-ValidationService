using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Learner.PlanLearnHours
{
    public abstract class PlanLearnHoursTestsBase
    {
        protected MessageLearner SetupLearner(long? planLearnHours, long? planEepHours, long? fundModel)
        {
            var learner = new MessageLearner
            {
                PlanLearnHours = planLearnHours ?? 0,
                PlanLearnHoursSpecified = planLearnHours.HasValue,
                PlanEEPHours = planEepHours ?? 0,
                PlanEEPHoursSpecified = planEepHours.HasValue
            };

            var learningDelivery = new MessageLearnerLearningDelivery()
            {
                FundModel = fundModel ?? 0,
                FundModelSpecified = fundModel.HasValue
            };
            learner.LearningDelivery = new MessageLearnerLearningDelivery[] { learningDelivery };
            return learner;
        }

      
    }
}
