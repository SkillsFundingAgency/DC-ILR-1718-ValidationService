using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.Rules.Query;
using FluentAssertions;
using System.Collections.Generic;
using Moq;
using Xunit;
using System.Collections;
using Castle.Core.Logging;

namespace ESFA.DC.ILR.ValidationService.Rules.Tests.Query
{
    public class MessageLearnerFAMQueryServiceTests
    {   
        [Fact]
        public void HasAnyLearnerFAMCodesForType_True()
        {
            var learnerFams = SetupLearnerFams();

            var codes = new long[] { 1,3 };
            var queryService = new LearnerFAMQueryService();
            queryService.HasAnyLearnerFAMCodesForType(learnerFams, "FamC", codes).Should().BeTrue();
        }
        
        [Fact]
        public void HasAnyLearnerFAMCodesForType_NullFams()
        {
            var queryService = new LearnerFAMQueryService();
            queryService.HasAnyLearnerFAMCodesForType(null, "FamB", It.IsAny<List<long>>()).Should().BeFalse();
        }

        [Fact]
        public void HasAnyLearnerFAMCodesForType_False_CodesNull()
        {
            var learnerFams = SetupLearnerFams();
            var queryService = new LearnerFAMQueryService();

            queryService.HasAnyLearnerFAMCodesForType(learnerFams, "FamB", null).Should().BeFalse();
        }
        
        [Fact]
        public void HasAnyLearnerFAMCodesForType_False_Mismatch()
        {
            var learnerFams = SetupLearnerFams();

            var queryService = new LearnerFAMQueryService();
            queryService.HasAnyLearnerFAMCodesForType(learnerFams, "FamA", new long[] { 2, 3 }).Should().BeFalse();
        }

        [Fact]
        public void HasLearnerFAMCodeForType_True()
        {
            var learnerFams = SetupLearnerFams();

            var queryService = new LearnerFAMQueryService();
            queryService.HasLearnerFAMCodeForType(learnerFams, "FamB", 2).Should().BeTrue();
        }

        [Fact]
        public void HasLearnerFAMCodeForType_NullLearnerFams()
        {
            var queryService = new LearnerFAMQueryService();
            queryService.HasLearnerFAMCodeForType(null, "FamB", 2).Should().BeFalse();
        }

        [Fact]
        public void HasLearnerFAMCodeForType_FalseMismatch()
        {
            var learnerFams = SetupLearnerFams();
            var queryService = new LearnerFAMQueryService();
            queryService.HasLearnerFAMCodeForType(learnerFams, "FamA", 99999).Should().BeFalse();
        }

        [Fact]
        public void HasLearnerFAMType_True()
        {
            var learnerFams = SetupLearnerFams();
            var queryService = new LearnerFAMQueryService();
            queryService.HasLearnerFAMType(learnerFams, "FamA");
        }

        [Fact]
        public void HasLearnerFAMType_False()
        {
            var learnerFams = SetupLearnerFams();
            var queryService = new LearnerFAMQueryService();
            queryService.HasLearnerFAMType(learnerFams, "TYPENOTFOUND");
        }

        [Fact]
        public void HasLearnerFAMType_False_NullLearnerFams()
        {
            var queryService = new LearnerFAMQueryService();
            queryService.HasLearnerFAMType(null, It.IsAny<string>());
        }

        private  MessageLearnerLearnerFAM[] SetupLearnerFams()
        {
            var learnerFams = new MessageLearnerLearnerFAM[]
            {
                new MessageLearnerLearnerFAM() {LearnFAMType = "FamA", LearnFAMCode = 1, LearnFAMCodeSpecified = true},
                new MessageLearnerLearnerFAM() {LearnFAMType = "FamB", LearnFAMCode = 2, LearnFAMCodeSpecified = true},
                new MessageLearnerLearnerFAM() {LearnFAMType = "FamC", LearnFAMCode = 3, LearnFAMCodeSpecified = true},
                new MessageLearnerLearnerFAM() {LearnFAMType = "FamC", LearnFAMCode = 5, LearnFAMCodeSpecified = true},
            };
            return learnerFams;
        }
    }
}
