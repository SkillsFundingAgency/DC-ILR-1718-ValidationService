using ESFA.DC.ILR.Model.Extension;
using FluentAssertions;
using System.Xml.Serialization;
using Xunit;

namespace ESFA.DC.ILR.Model.Tests
{
    public class EnumExtensionsTests
    {
        public enum TestEnum
        {            
            [XmlEnum("NoSpace")]
            NoSpace,
                     
            [XmlEnum("Space Bar")]
            Space,
                        
            NoAttribute,
        }

        [Fact]
        public void NoSpace()
        {
            TestEnum.NoSpace.XmlEnumToString().Should().Be("NoSpace");
        }       

        [Fact]
        public void Space()
        {
            TestEnum.Space.XmlEnumToString().Should().Be("Space Bar");
        }

        [Fact]
        public void NoAttribute()
        {
            TestEnum.NoAttribute.XmlEnumToString().Should().Be("NoAttribute");
        }
    }
}
