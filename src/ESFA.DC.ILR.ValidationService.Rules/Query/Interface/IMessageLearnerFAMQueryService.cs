using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.Model.Interface;
using System.Collections.Generic;

namespace ESFA.DC.ILR.ValidationService.Rules.Query.Interface
{
    public interface IMessageLearnerFAMQueryService
    {
        bool HasAnyLearnerFAMCodesForType(IEnumerable<IMessageLearnerLearnerFAM> learnerFAMs, string famType, IEnumerable<long> famCodes);
        bool HasLearnerFAMCodeForType(IEnumerable<IMessageLearnerLearnerFAM> learnerFAMs, string famType, long famCode);
        bool HasLearnerFAMType(IEnumerable<IMessageLearnerLearnerFAM> learnerFAMs, string famType);
    }
}
