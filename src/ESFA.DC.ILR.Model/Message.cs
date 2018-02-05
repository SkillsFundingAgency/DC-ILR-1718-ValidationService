using System.Collections.Generic;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.Model
{
    public partial class Message : IMessage
    {
        public IReadOnlyCollection<IMessageLearner> Learners
        {
            get { return learnerField; }
        }

        public IReadOnlyCollection<IMessageLearnerDestinationAndProgression> LearnerDestinationAndProgressions
        {
            get { return learnerDestinationandProgressionField; }
        }

        public IReadOnlyCollection<IMessageSourceFile> SourceFilesCollection
        {
            get { return sourceFilesField; }
        }

        public IMessageLearningProvider LearningProviderEntity
        {
            get { return learningProviderField; }
        }

        public IMessageHeader HeaderEntity
        {
            get { return headerField; }
        }
    }
}
