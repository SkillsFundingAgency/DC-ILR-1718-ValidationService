using System.Collections.Generic;

namespace ESFA.DC.ILR.Model.Interface
{
    public interface IMessage
    {
        IHeader HeaderEntity { get; }        
        IReadOnlyCollection<ISourceFile> SourceFilesCollection { get; }
        ILearningProvider LearningProviderEntity { get; }
        IReadOnlyCollection<ILearner> Learners { get; }
        IReadOnlyCollection<ILearnerDestinationAndProgression> LearnerDestinationAndProgressions { get; }        
    }
}
