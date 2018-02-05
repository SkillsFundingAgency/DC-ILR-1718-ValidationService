using System.Collections.Generic;

namespace ESFA.DC.ILR.Model.Interface
{
    public interface IMessage
    {
        IMessageHeader HeaderEntity { get; }        
        IReadOnlyCollection<IMessageSourceFile> SourceFilesCollection { get; }
        IMessageLearningProvider LearningProviderEntity { get; }
        IReadOnlyCollection<IMessageLearner> Learners { get; }
        IReadOnlyCollection<IMessageLearnerDestinationAndProgression> LearnerDestinationAndProgressions { get; }        
    }
}
