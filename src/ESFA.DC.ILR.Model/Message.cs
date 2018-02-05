using System.Collections.Generic;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Model
{
    public partial class Message : IMessage
    {
        public IReadOnlyCollection<ILearner> Learners
        {
            get { return learnerField; }
        }

        public IReadOnlyCollection<ILearnerDestinationAndProgression> LearnerDestinationAndProgressions
        {
            get { return learnerDestinationandProgressionField; }
        }

        public IReadOnlyCollection<ISourceFile> SourceFilesCollection
        {
            get { return sourceFilesField; }
        }

        public ILearningProvider LearningProviderEntity
        {
            get { return learningProviderField; }
        }

        public IHeader HeaderEntity
        {
            get { return headerField; }
        }
    }
}
