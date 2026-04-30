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
        protected ShapeBase() { }

        /// <summary>
        /// Формат вывода чисел с плавающей точкой.
        /// </summary>
        public const string DoubleFormat = "F2";

        /// <summary>
        /// Проверяет, что значение положительное и является числом.
        /// </summary>
        /// <param name="value">Проверяемое значение.</param>
        /// <param name="paramName">Имя параметра.</param>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если значение меньше или равно 0, или равно NaN.
        /// </exception>
        protected static void ValidatePositive(
            double value,
            string paramName)
        {
            if (double.IsNaN(value))
            {
                throw new ArgumentException(
                    $"Параметр '{paramName}' не является числом (NaN).");
            }

            if (value <= MinValue)
            {
                throw new ArgumentException(
                    $"Параметр '{paramName}' должен быть " +
                    $"положительным. Получено: {value}");
            }
        }

        /// <summary>
        /// Проверяет корректность параметров фигуры.
        /// </summary>
        public virtual void Validate() { }

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

        //TODO: XML+
        /// <summary>
        /// Возвращает тип фигуры.
        /// </summary>
        public abstract string GetShapeType();
    }
}