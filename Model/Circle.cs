using System;

namespace Model
{
    /// <summary>
    /// Класс, представляющий круг.
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Радиус круга.
        /// </summary>
        private double _radius;

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Circle()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса Circle.
        /// </summary>
        /// <param name="radius">Радиус круга.</param>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если радиус меньше или равен 0.
        /// </exception>
        public Circle(double radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Получает или задает радиус круга.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если радиус меньше или равен 0.
        /// </exception>
        public double Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                ValidatePositive(value, nameof(Radius));
                _radius = value;
            }
        }

        /// <summary>
        /// Вычисляет площадь круга.
        /// </summary>
        /// <returns>Площадь круга.</returns>
        public override double CalculateArea()
        {
            return Math.PI * _radius * _radius;
        }

        /// <summary>
        /// Возвращает информацию о круге.
        /// </summary>
        /// <returns>Строка с информацией о круге.</returns>
        public override string GetInfo()
        {
            return $"Круг: радиус = {_radius:F2}, " +
                   $"площадь = {CalculateArea():F2}";
        }
    }
}