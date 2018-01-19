using ESFA.DC.ILR.Model;
using FluentAssertions;
using System;
using Xunit;

namespace ESFA.DC.ILR.ValidationService.ExternalData.Tests.FileDataService
{
    public class FileDataServiceTests
    {
        [Fact]
        public void Populate_FilePreparationDate()
        {
            var fileData = new ExternalData.FileDataService.FileDataService();

            var filePreparationDate = new DateTime(2018, 1, 5);

            var message = new Message()
            {
                Header = new MessageHeader()
                {
                    CollectionDetails = new MessageHeaderCollectionDetails()
                    {
                        FilePreparationDate = filePreparationDate
                    }
                }
            };

            fileData.Populate(message);

            fileData.FilePreparationDate.Should().Be(filePreparationDate);
        }
    }
}
