using System;
using Mindbox.Library.Exceptions;

namespace Mindbox.Library
{
    /*
     * Я решил логику, связанную с прямоугольным треугольником, закинуть в текущий класс,
     * но можно было создать подкласс RightTriangle и создавать классы треугольников через метод-фабрику.
     * Но это выглядит слишком громоздко для такой простой библиотеки.
    */
    public class Triangle : IFigure
    {
        private const double EPSILON = 0.00001;

        /*
         * В данном случае я использовал поля, а не свойства, так как в задаче
         * явно не требуется доступ к сторонам и возможность их модификации
         */

        private readonly double a;
        private readonly double b;
        private readonly double c;

        private double Perimeter => a + b + c;
        private double HalfPerimeter => Perimeter / 2;

        /*
         * Вообще, я бы предпочел оставить тут только формулу Герона.
         * Но в пояснении к задаче не было уточнения по поводу ожидаемой точности
         */
        public double Area => IsRight
            ? (b * c / 2) // Для улучшения точности, площадь прямоугольного треугольника считается по-другому
            : Math.Sqrt(HalfPerimeter * (HalfPerimeter - a) * (HalfPerimeter - b) * (HalfPerimeter - c));

        // ? почему-то "прямоугольный треугольник" именуется как "right triangle"
        public bool IsRight => Math.Abs(Math.Sqrt(Math.Pow(b, 2) + Math.Pow(c, 2)) - a) <= EPSILON;

        public Triangle(double a, double b, double c) {
            if (a <= 0) {
                throw new ArgumentOutOfRangeException(nameof(a));
            }

            if (b <= 0) {
                throw new ArgumentOutOfRangeException(nameof(b));
            }

            if (c <= 0) {
                throw new ArgumentOutOfRangeException(nameof(c));
            }

            // Для удобства определения прямоугольного треугольника,
            // сортируем стороны в порядке убывания величин
            this.a = Math.Max(Math.Max(a, b), c);
            this.c = Math.Min(Math.Min(a, b), c);
            this.b = (a + b + c) - this.a - this.c;

            ensureExisting();
        }

        private void ensureExisting() {
            if (a >= b + c) {
                throw new InvalidSidesOfTriangleException(a, b, c);
            }

            if (b >= a + c) {
                throw new InvalidSidesOfTriangleException(b, c, a);
            }

            if (c >= a + b) {
                throw new InvalidSidesOfTriangleException(c, a, b);
            }
        }
    }
}