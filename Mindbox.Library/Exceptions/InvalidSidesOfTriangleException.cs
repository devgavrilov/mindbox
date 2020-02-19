using System;

namespace Mindbox.Library.Exceptions
{
    public class InvalidSidesOfTriangleException : ApplicationException
    {
        private const string MESSAGE = "One side of triangle: {0} bigger, than sum of two other sides: {1} and {2}";

        public InvalidSidesOfTriangleException(double biggestSide, double otherSide1, double otherSide2)
            : base(string.Format(MESSAGE, biggestSide, otherSide1, otherSide2))
        {
        }
    }
}