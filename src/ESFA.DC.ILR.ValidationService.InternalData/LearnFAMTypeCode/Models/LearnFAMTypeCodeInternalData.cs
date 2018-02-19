using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFA.DC.ILR.ValidationService.InternalData.LearnFAMTypeCode.Models
{
    public class LearnFAMTypeCodeInternalData
    {
        public long Code { get; set; }
        public string Type { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
