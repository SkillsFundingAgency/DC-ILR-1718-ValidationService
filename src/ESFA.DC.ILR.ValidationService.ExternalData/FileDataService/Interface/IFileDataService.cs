using ESFA.DC.ILR.Model;
using System;

namespace ESFA.DC.ILR.ValidationService.ExternalData.FileDataService.Interface
{
    public interface IFileDataService
    {
        DateTime FilePreparationDate { get; }

        void Populate(Message message);
    }
}
