using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.Model.Tests
{
    public class MessageHeaderCollectionDetailsTests
    {
        [Fact]
        public void CollectionString()
        {
            var collectionDetails = new MessageHeaderCollectionDetails()
            {
                Collection = MessageHeaderCollectionDetailsCollection.ILR
            };

            collectionDetails.CollectionString.Should().Be("ILR");
        }

        [Fact]
        public void YearString()
        {
            var collectionDetails = new MessageHeaderCollectionDetails()
            {
                Year = MessageHeaderCollectionDetailsYear.Item1718
            };

            collectionDetails.YearString.Should().Be("1718");
        }
    }
}
