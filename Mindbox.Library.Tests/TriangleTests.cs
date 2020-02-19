using System;
using Mindbox.Library.Exceptions;
using Xunit;

namespace Mindbox.Library.Tests
{
    public class TriangleTests {
        [Fact]
        public void SimpleTrianglesShouldReturnCorrectArea() {
            Assert.True(Math.Abs(new Triangle(4, 5, 6).Area - 9.9215674164922) <= 0.00001);
            Assert.True(Math.Abs(new Triangle(2, 5, 4).Area - 3.7996710383927) <= 0.00001);
        }

        [Fact]
        public void RightTrianglesShouldReturnCorrectArea() {
            Assert.True(Math.Abs(new Triangle(3, 4, 5).Area - 6) <= 0.00001);
            Assert.True(Math.Abs(new Triangle(12, 12, 16.97).Area - 72) <= 0.00001);
        }

        [Fact]
        public void IsRightShouldReturnFalseOnNonRightTriangle() {
            Assert.False(new Triangle(3, 4, 4).IsRight);
        }

        [Fact]
        public void IsRightShouldReturnTrueOnRightTriangle() {
            Assert.True(new Triangle(3, 4, 5).IsRight);
        }

        [Fact]
        public void IsRightShouldWorkWithDifferentOrderOfSides() {
            Assert.True(new Triangle(3, 5, 4).IsRight);
            Assert.True(new Triangle(4, 3, 5).IsRight);
            Assert.True(new Triangle(4, 5, 3).IsRight);
            Assert.True(new Triangle(5, 4, 3).IsRight);
        }

        [Fact]
        public void InvalidSidesOfTriangleShouldThrowAnException() {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(-1, 1, 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(10, -23, 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(4, 2, 0));
        }

        [Fact]
        public void InvalidTrianglesShouldThrowAnException() {
            Assert.Throws<InvalidSidesOfTriangleException>(() => new Triangle(3, 1, 1));
            Assert.Throws<InvalidSidesOfTriangleException>(() => new Triangle(1, 6, 2));
            Assert.Throws<InvalidSidesOfTriangleException>(() => new Triangle(3, 7, 20));
        }
    }
}