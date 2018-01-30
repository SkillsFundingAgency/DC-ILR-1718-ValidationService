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
        public void HasAnyLearningDeliveryFAMCodesForType_True()
        {
            var learningDeliveryFAMs = new MessageLearnerLearningDeliveryLearningDeliveryFAM[]
            {
                new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "TypeOne", LearnDelFAMCode = "CodeOne" },
                new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "TypeTwo", LearnDelFAMCode = "CodeTwo" },
                new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "TypeTwo", LearnDelFAMCode = "CodeThree" },
            };

            var codes = new string[] { "CodeOne", "CodeThree" };

            var queryService = new MessageLearnerLearningDeliveryLearningDeliveryFAMQueryService();

            queryService.HasAnyLearningDeliveryFAMCodesForType(learningDeliveryFAMs, "TypeTwo", codes).Should().BeTrue();
        }

        [Fact]
        public void HasAnyLearningDeliveryFAMCodesForType_FalseNull()
        {
            var codes = new string[] { "CodeOne", "CodeThree" };

            var queryService = new MessageLearnerLearningDeliveryLearningDeliveryFAMQueryService();

            queryService.HasAnyLearningDeliveryFAMCodesForType(null, "TypeTwo", codes).Should().BeFalse();
        }

        [Fact]
        public void HasAnyLearningDeliveryFAMCodesForType_False_CodesNull()
        {
            var learningDeliveryFAMs = new MessageLearnerLearningDeliveryLearningDeliveryFAM[]
            {
                new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "TypeOne", LearnDelFAMCode = "CodeOne" },
                new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "TypeTwo", LearnDelFAMCode = "CodeTwo" },
                new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "TypeTwo", LearnDelFAMCode = "CodeThree" },
            };
            

            var queryService = new MessageLearnerLearningDeliveryLearningDeliveryFAMQueryService();

            queryService.HasAnyLearningDeliveryFAMCodesForType(learningDeliveryFAMs, "TypeTwo", null).Should().BeFalse();
        }
        
        [Fact]
        public void HasAnyLearningDeliveryFAMCodesForType_False_Mismatch()
        {
            var learningDeliveryFAMs = new MessageLearnerLearningDeliveryLearningDeliveryFAM[]
            {
                new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "TypeOne", LearnDelFAMCode = "CodeOne" },
                new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "TypeTwo", LearnDelFAMCode = "CodeTwo" },
                new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "TypeTwo", LearnDelFAMCode = "CodeThree" },
            };

            var codes = new string[] { "CodeTwo", "CodeThree" };

            var queryService = new MessageLearnerLearningDeliveryLearningDeliveryFAMQueryService();

            queryService.HasAnyLearningDeliveryFAMCodesForType(learningDeliveryFAMs, "TypeOne", codes).Should().BeFalse();
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
