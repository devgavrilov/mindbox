using System;

namespace Mindbox.Library
{
    public class Circle : IFigure
    {
        private readonly double radius;

        public double Area => Math.PI * radius * radius;

        public Circle(double radius) {
            if (radius <= 0) {
                throw new ArgumentOutOfRangeException(nameof(radius));
            }

            this.radius = radius;
        }
    }
}