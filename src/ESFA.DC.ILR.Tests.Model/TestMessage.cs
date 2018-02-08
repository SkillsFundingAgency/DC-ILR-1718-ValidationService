using System.Collections.Generic;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Tests.Model
{
    public class TestMessage : IMessage
    {
        public IHeader HeaderEntity { get; set; }

        public IReadOnlyCollection<ISourceFile> SourceFilesCollection { get; set; }

        public ILearningProvider LearningProviderEntity { get; set; }

        public IReadOnlyCollection<ILearner> Learners { get; set; }

        public IReadOnlyCollection<ILearnerDestinationAndProgression> LearnerDestinationAndProgressions { get; set; }
    }
}
