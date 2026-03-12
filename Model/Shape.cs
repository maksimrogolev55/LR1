using System;

namespace Model
{
    /// <summary>
    /// Абстрактный базовый класс для всех
    /// геометрических фигур.
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Минимально допустимое значение для
        /// параметров фигуры.
        /// </summary>
        protected const double MinValue = 1e-10;

        /// <summary>
        /// Проверяет, что значение положительное.
        /// </summary>
        /// <param name="value">Проверяемое значение.</param>
        /// <param name="paramName">Имя параметра.</param>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если значение меньше или равно 0.
        /// </exception>
        protected static void ValidatePositive(
            double value,
            string paramName)
        {
            if (value <= MinValue)
            {
                throw new ArgumentException(
                    $"Параметр '{paramName}' должен быть положительным. " +
                    $"Получено: {value}");
            }
        }

        /// <summary>
        /// Проверяет, что три стороны могут образовать треугольник.
        /// </summary>
        /// <param name="a">Сторона A.</param>
        /// <param name="b">Сторона B.</param>
        /// <param name="c">Сторона C.</param>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если нарушено неравенство треугольника.
        /// </exception>
        protected static void ValidateTriangleSides(
            double a,
            double b,
            double c)
        {
            if (a + b <= c || a + c <= b || b + c <= a)
            {
                throw new ArgumentException(
                    $"Стороны ({a:F2}, {b:F2}, {c:F2}) " +
                    $"не образуют треугольник.");
            }
        }

        /// <summary>
        /// Абстрактный метод вычисления площади.
        /// </summary>
        /// <returns>Площадь фигуры.</returns>
        public abstract double CalculateArea();

        /// <summary>
        /// Абстрактный метод получения информации.
        /// </summary>
        /// <returns>Строка с информацией о фигуре.</returns>
        public abstract string GetInfo();

        /// <summary>
        /// Статический метод для генерации случайной фигуры.
        /// </summary>
        /// <returns>Случайная фигура.</returns>
        public static Shape GetRandomShape()
        {
            Random random = new Random();
            int type = random.Next(0, 3);

            switch (type)
            {
                case 0:
                    return new Circle(
                        random.NextDouble() * 9 + 1);
                case 1:
                    return new Rectangle(
                        random.NextDouble() * 9 + 1,
                        random.NextDouble() * 9 + 1);
                default:
                    return GenerateRandomTriangle(random);
            }
        }

        /// <summary>
        /// Генерирует случайный треугольник с валидными сторонами.
        /// </summary>
        /// <param name="random">Генератор случайных чисел.</param>
        /// <returns>Случайный треугольник.</returns>
        private static Triangle GenerateRandomTriangle(Random random)
        {
            double a;
            double b;
            double c;

            do
            {
                a = random.NextDouble() * 8 + 2;
                b = random.NextDouble() * 8 + 2;
                c = random.NextDouble() * 8 + 2;
            }
            while (a + b <= c || a + c <= b || b + c <= a);

            return new Triangle(a, b, c);
        }
    }
}