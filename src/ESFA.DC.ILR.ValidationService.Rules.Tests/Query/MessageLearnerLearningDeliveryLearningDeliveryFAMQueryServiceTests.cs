using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Rules.Query;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Query
{
    public class MessageLearnerLearningDeliveryLearningDeliveryFAMQueryServiceTests
    {        
        [Fact]
        public void HasLearningDeliveryFAMCodeForType_True()
        {
            var learningDeliveryFAMs = new MessageLearnerLearningDeliveryLearningDeliveryFAM[]
            {
                new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "TypeOne", LearnDelFAMCode = "CodeOne" },
                new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "TypeTwo", LearnDelFAMCode = "CodeTwo" },            
            };

            var queryService = new MessageLearnerLearningDeliveryLearningDeliveryFAMQueryService();

            queryService.HasLearningDeliveryFAMCodeForType(learningDeliveryFAMs, "TypeTwo", "CodeTwo").Should().BeTrue();
        }

        [Fact]
        public void HasLearningDeliveryFAMCodeForType_FalseNull()
        {
            var queryService = new MessageLearnerLearningDeliveryLearningDeliveryFAMQueryService();

            queryService.HasLearningDeliveryFAMCodeForType(null, "TypeTwo", "CodeTwo").Should().BeFalse();
        }

        [Fact]
        public void HasLearningDeliveryFAMCodeForType_FalseMismatch()
        {
            var learningDeliveryFAMs = new MessageLearnerLearningDeliveryLearningDeliveryFAM[]
            {
                new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "TypeOne", LearnDelFAMCode = "CodeOne" },
                new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "TypeTwo", LearnDelFAMCode = "CodeTwo" },
            };

            var queryService = new MessageLearnerLearningDeliveryLearningDeliveryFAMQueryService();

            queryService.HasLearningDeliveryFAMCodeForType(learningDeliveryFAMs, "TypeOne", "CodeThree").Should().BeFalse();
        }

        [Fact]
        public void HasLearningDeliveryFAMType_True()
        {
            var learningDeliveryFAMs = new MessageLearnerLearningDeliveryLearningDeliveryFAM[]
            {
                new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "TypeOne" },
                new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "TypeOne" },
                new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "TypeTwo" }
            };
            
            var queryService = new MessageLearnerLearningDeliveryLearningDeliveryFAMQueryService();

            queryService.HasLearningDeliveryFAMType(learningDeliveryFAMs, "TypeOne");
        }

        [Fact]
        public void HasLearningDeliveryFAMType_False()
        {
            var learningDeliveryFAMs = new MessageLearnerLearningDeliveryLearningDeliveryFAM[]
            {
                new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "TypeOne" },
                new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "TypeOne" },
                new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "TypeTwo" }
            };

            var queryService = new MessageLearnerLearningDeliveryLearningDeliveryFAMQueryService();

            queryService.HasLearningDeliveryFAMType(learningDeliveryFAMs, "TypeThree");
        }

        [Fact]
        public void HasLearningDeliveryFAMType_False_Null()
        {
            var queryService = new MessageLearnerLearningDeliveryLearningDeliveryFAMQueryService();

            queryService.HasLearningDeliveryFAMType(null, "Doesn't Matter");
        }
    }
}
