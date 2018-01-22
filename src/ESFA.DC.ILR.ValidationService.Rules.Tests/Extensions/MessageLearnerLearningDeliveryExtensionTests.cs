using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Rules.Extensions;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Extensions
{
    public class MessageLearnerLearningDeliveryExtensionTests
    {
        [Fact]
        public void LearningDeliveryFAMCodeForType_Null()
        {
            var learningDelivery = new MessageLearnerLearningDelivery
            {
                LearningDeliveryFAM = null
            };

            learningDelivery.LearningDeliveryFAMCodeForType("Type").Should().BeNull();
        }

        [Fact]
        public void LearningDeliveryFAMCodeForType_NotFound()
        {
            var learningDelivery = new MessageLearnerLearningDelivery
            {
                LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[]
                {
                    new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "Type"}
                }
            };

            learningDelivery.LearningDeliveryFAMCodeForType("TypeNotFound").Should().BeNull();
        }

        [Fact]
        public void LearningDeliveryFAMCodeForType_Duplicate()
        {
            var learningDelivery = new MessageLearnerLearningDelivery
            {
                LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[]
                {
                    new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "Type", LearnDelFAMCode = "CodeOne" },
                    new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "Type", LearnDelFAMCode = "CodeTwo" },
                }
            };

            learningDelivery.LearningDeliveryFAMCodeForType("Type").Should().Be("CodeOne");
        }

        [Fact]
        public void LearningDeliveryFAMCodeForType_Single()
        {
            var learningDelivery = new MessageLearnerLearningDelivery
            {
                LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[]
                {
                    new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "TypeOne", LearnDelFAMCode = "CodeOne" },
                    new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "TypeTwo", LearnDelFAMCode = "CodeTwo" },
                }
            };

            learningDelivery.LearningDeliveryFAMCodeForType("TypeTwo").Should().Be("CodeTwo");
        }

        [Fact]
        public void HasLearningDeliveryFAMCodeForType_True()
        {
            var learningDelivery = new MessageLearnerLearningDelivery
            {
                LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[]
                   {
                    new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "TypeOne", LearnDelFAMCode = "CodeOne" },
                    new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "TypeTwo", LearnDelFAMCode = "CodeTwo" },
                   }
            };

            learningDelivery.HasLearningDeliveryFAMCodeForType("TypeTwo", "CodeTwo").Should().BeTrue();
        }

        [Fact]
        public void HasLearningDeliveryFAMCodeForType_FalseNull()
        {
            var learningDelivery = new MessageLearnerLearningDelivery
            {
                LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[]
                {
                    new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "TypeOne", LearnDelFAMCode = "CodeOne" },
                    new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "TypeTwo", LearnDelFAMCode = "CodeTwo" },
                }
            };

            learningDelivery.HasLearningDeliveryFAMCodeForType("Fiction", "CodeOne").Should().BeFalse();
        }

        [Fact]
        public void HasLearningDeliveryFAMCodeForType_FalseMismatch()
        {
            var learningDelivery = new MessageLearnerLearningDelivery
            {
                LearningDeliveryFAM = new MessageLearnerLearningDeliveryLearningDeliveryFAM[]
                {
                    new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "TypeOne", LearnDelFAMCode = "CodeOne" },
                    new MessageLearnerLearningDeliveryLearningDeliveryFAM() { LearnDelFAMType = "TypeTwo", LearnDelFAMCode = "CodeTwo" },
                }
            };

            learningDelivery.HasLearningDeliveryFAMCodeForType("TypeOne", "CodeThree").Should().BeFalse();
        }
    }
}
