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
        public void LearningDeliveryFAMCodeForType()
        {

        }

        [Fact]
        public void LearningDeliveryFAMCodeForType_Null()
        {
            var queryService = new MessageLearnerLearningDeliveryLearningDeliveryFAMQueryService();

            queryService.LearningDeliveryFAMCodeForType(null, "Type").Should().BeNull();
        }

        [Fact]
        public void LearningDeliveryFAMCodeForType_NotFound()
        {
            var learningDeliveryFAMs = new List<MessageLearnerLearningDeliveryLearningDeliveryFAM>()
            {
                new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "Type"}
            };

            var queryService = new MessageLearnerLearningDeliveryLearningDeliveryFAMQueryService();

            queryService.LearningDeliveryFAMCodeForType(learningDeliveryFAMs, "TypeNotFound").Should().BeNull();
        }

        [Fact]
        public void LearningDeliveryFAMCodeForType_Duplicate()
        {
            var learningDeliveryFAMs = new List<MessageLearnerLearningDeliveryLearningDeliveryFAM>()
            {
                new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "Type", LearnDelFAMCode = "CodeOne" },
                new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "Type", LearnDelFAMCode = "CodeTwo" },
            };

            var queryService = new MessageLearnerLearningDeliveryLearningDeliveryFAMQueryService();

            queryService.LearningDeliveryFAMCodeForType(learningDeliveryFAMs, "Type").Should().Be("CodeOne");
        }

        [Fact]
        public void LearningDeliveryFAMCodeForType_Single()
        {
            var learningDeliveryFAMs = new List<MessageLearnerLearningDeliveryLearningDeliveryFAM>()
            {
                new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "TypeOne", LearnDelFAMCode = "CodeOne" },
                new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "TypeTwo", LearnDelFAMCode = "CodeTwo" },
            };

            var queryService = new MessageLearnerLearningDeliveryLearningDeliveryFAMQueryService();

            queryService.LearningDeliveryFAMCodeForType(learningDeliveryFAMs, "TypeTwo").Should().Be("CodeTwo");
        }

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
    }
}
