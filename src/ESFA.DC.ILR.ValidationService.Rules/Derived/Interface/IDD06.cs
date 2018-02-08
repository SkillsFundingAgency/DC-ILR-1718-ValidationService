using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.ValidationService.Rules.Derived.Interface
{
    public interface IDD06
    {
        DateTime? Derive(IEnumerable<ILearningDelivery> learningDeliveries);
    }
}
