using System;

namespace Model
{
    /// <summary>
    /// Абстрактный базовый класс для всех
    /// геометрических фигур.
    /// </summary>
    public abstract class ShapeBase
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
        /// Абстрактный метод вычисления площади.
        /// </summary>
        /// <returns>Площадь фигуры.</returns>
        public abstract double CalculateArea();

        /// <summary>
        /// Абстрактный метод получения информации.
        /// </summary>
        /// <returns>Строка с информацией о фигуре.</returns>
        public abstract string GetInfo();
    }
}