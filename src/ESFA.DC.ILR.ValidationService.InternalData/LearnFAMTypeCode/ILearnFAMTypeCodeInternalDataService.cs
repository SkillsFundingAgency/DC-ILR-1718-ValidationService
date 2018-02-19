using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFA.DC.ILR.ValidationService.InternalData.LearnFAMTypeCode
{
    public interface ILearnFAMTypeCodeInternalDataService
    {
        bool TypeExists(string type);
        bool TypeCodeExists(string type, long? code);
        bool TypeCodeForDateExists(string type, long? code, DateTime? validTo);
    }
}
