using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFA.DC.ILR.ValidationService.ExternalData.PriorAttain
{
    public interface IPriorAttainReferenceDataService
    {
        bool Exists(long priorAttain);
    }
}
