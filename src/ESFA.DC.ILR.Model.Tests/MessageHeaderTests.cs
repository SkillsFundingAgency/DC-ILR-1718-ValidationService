using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.Model.Tests
{
    public class MessageHeaderTests
    {
        [Fact]
        public void CollectionDetailsEntity()
        {
            var header = new MessageHeader()
            {
                CollectionDetails = new MessageHeaderCollectionDetails()
            };

            header.CollectionDetailsEntity.Should().BeSameAs(header.CollectionDetails);
        }

        [Fact]
        public void SourceEntity()
        {
            var header = new MessageHeader()
            {
                Source = new MessageHeaderSource()
            };

            header.SourceEntity.Should().BeSameAs(header.Source);
        }
    }
}
