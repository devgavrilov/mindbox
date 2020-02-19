using System;
using Xunit;

namespace Mindbox.Library.Tests
{
    public class CircleTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(5.4236543)]
        [InlineData(13.314364756)]
        public void PositiveRadiusShouldReturnCorrectArea(int value)
        {
            Assert.True(Math.Abs(new Circle(value).Area - Math.PI * value * value) <= 0.00001);
        }

        [Fact]
        public void NegativeRadiusShouldThrowAnException() {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(-1));
        }

        [Fact]
        public void ZeroRadiusShouldThrowAnException() {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(0));
        }
    }
}
