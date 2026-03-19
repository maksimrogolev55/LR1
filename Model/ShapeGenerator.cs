using System;

namespace Model
{
    /// <summary>
    /// Представляет статические методы для генерации
    /// случайных геометрических фигур.
    /// </summary>
    public static class ShapeGenerator
    {
        /// <summary>
        /// Генератор случайных чисел.
        /// </summary>
        private static readonly Random _random = new Random();

        /// <summary>
        /// Генерирует случайный круг с радиусом от 1 до 10.
        /// </summary>
        /// <returns>Случайный круг.</returns>
        public static Circle GetRandomCircle()
        {
            double radius = _random.NextDouble() * 9 + 1;
            return new Circle(radius);
        }

        /// <summary>
        /// Генерирует случайный прямоугольник со сторонами от 1 до 10.
        /// </summary>
        /// <returns>Случайный прямоугольник.</returns>
        public static Rectangle GetRandomRectangle()
        {
            double width = _random.NextDouble() * 9 + 1;
            double height = _random.NextDouble() * 9 + 1;
            return new Rectangle(width, height);
        }

        /// <summary>
        /// Генерирует случайный треугольник с валидными сторонами.
        /// </summary>
        /// <returns>Случайный треугольник.</returns>
        public static Triangle GetRandomTriangle()
        {
            double a = _random.NextDouble() * 6 + 2;
            double b = _random.NextDouble() * 6 + 2;

            double angleDegrees = _random.NextDouble() * 178 + 1;
            double angleRadians = angleDegrees * Math.PI / 180.0;

            double c = Math.Sqrt(
                a * a +
                b * b -
                2 * a * b * Math.Cos(angleRadians)
            );
            return new Triangle(a, b, c);
        }

        /// <summary>
        /// Генерирует случайную фигуру.
        /// </summary>
        /// <returns>Случайная фигура.</returns>
        public static ShapeBase GetRandomShape()
        {
            int type = _random.Next(0, 3);

            switch (type)
            {
                case 0:
                { 
                    return GetRandomCircle(); 
                }
                case 1:
                {
                    return GetRandomRectangle(); 
                }
                default:
                {
                    return GetRandomTriangle();
                }
            }
        }
    }
}