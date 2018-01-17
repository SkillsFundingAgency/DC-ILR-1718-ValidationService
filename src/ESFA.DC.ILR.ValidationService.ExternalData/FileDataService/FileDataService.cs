using System;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.ValidationService.ExternalData.FileDataService.Interface;

namespace ESFA.DC.ILR.ValidationService.ExternalData.FileDataService
{
    public class FileDataService : IFileDataService
    {
        public DateTime FilePreparationDate { get; private set; }

        public void Populate(Message message)
        {
            FilePreparationDate = message.Header.CollectionDetails.FilePreparationDate;
        }
    }
}
