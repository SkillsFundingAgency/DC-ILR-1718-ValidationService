using ESFA.DC.ILR.ValidationService.Rules.Query.Interface;
using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.Model;

namespace ESFA.DC.ILR.ValidationService.Rules.Query
{
    public class LearnerFAMQueryService : ILearnerFAMQueryService
    {
        public bool HasAnyLearnerFAMCodesForType(IEnumerable<ILearnerFAM> learnerFams, string famType, IEnumerable<long> famCodes)
        {
            if (learnerFams == null || famCodes == null)
            {
                return false;
            }

            return learnerFams.Any(lfam => lfam.LearnFAMType == famType && famCodes.Contains(lfam.LearnFAMCodeNullable ?? 0));            
        }

        public bool HasLearnerFAMCodeForType(IEnumerable<ILearnerFAM> learnerFams, string famType, long famCode)
        {
            if (learnerFams == null)
            {
                return false;
            }

            return learnerFams.Any(ldfam => ldfam.LearnFAMType == famType && ldfam.LearnFAMCodeNullable.HasValue && ldfam.LearnFAMCodeNullable.Value == famCode);
        }

        public bool HasLearnerFAMType(IEnumerable<ILearnerFAM> learnerFams, string famType)
        {
            if (learnerFams == null)
            {
                return false;
            }

            return learnerFams.Any(ldfam => ldfam.LearnFAMType == famType);
        }

        
    }
}
