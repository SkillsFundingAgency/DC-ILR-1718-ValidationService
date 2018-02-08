using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ESFA.DC.ILR.Model.Tests
{
    public class MessageTests
    {
        [Fact]
        public void Learners()
        {
            var message = new Message()
            {
                Learner = new MessageLearner[]
                {
                    new MessageLearner()
                }
            };

            message.Learners.Should().BeSameAs(message.Learner);
            message.Learners.Should().HaveCount(1);
        }

        [Fact]
        public void HeaderEntity()
        {
            var message = new Message()
            {
                Header = new MessageHeader()
            };

            message.HeaderEntity.Should().BeSameAs(message.Header);
        }

        [Fact]
        public void SourceFilesCollection()
        {
            var message = new Message()
            {
                SourceFiles = new MessageSourceFile[]
                {
                    new MessageSourceFile()
                }
            };

            message.SourceFilesCollection.Should().BeSameAs(message.SourceFiles);
            message.SourceFilesCollection.Should().HaveCount(1);
        }

        [Fact]
        public void LearningProviderEntity()
        {
            var message = new Message()
            {
                LearningProvider = new MessageLearningProvider()
            };

            message.LearningProviderEntity.Should().BeSameAs(message.LearningProvider);
        }

        [Fact]
        public void LearnerDestinationAndProgressions()
        {
            var message = new Message()
            {
                LearnerDestinationandProgression = new MessageLearnerDestinationandProgression[]
                {
                    new MessageLearnerDestinationandProgression()
                }
            };

            message.LearnerDestinationAndProgressions.Should().BeSameAs(message.LearnerDestinationandProgression);
            message.LearnerDestinationAndProgressions.Should().HaveCount(1);
        }
    }
}
