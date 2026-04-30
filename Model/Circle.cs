using System;

namespace Model
{
    /// <summary>
    /// Класс, представляющий круг.
    /// </summary>
    public class Circle : ShapeBase
    {
        /// <summary>
        /// Конструктор по умолчанию для сериализации.
        /// </summary>
        public Circle() { }

        /// <summary>
        /// Радиус круга.
        /// </summary>
        private double _radius;

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
            Validate();
        }

        /// <summary>
        /// Получает или задает радиус круга.
        /// <summary>
        public double Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
            }
        }

        /// <summary>
        /// Проверяет корректность параметров круга.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если радиус меньше или равен 0.
        /// </exception>
        public override void Validate()
        {
            ValidatePositive(_radius, nameof(Radius));
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
            return $"Круг: радиус = {_radius.ToString(DoubleFormat)}, " +
                   $"площадь = {CalculateArea().ToString(DoubleFormat)}";
        }

        //TODO: XML+
        /// <summary>
        /// Возвращает тип фигуры.
        /// </summary>
        public override string GetShapeType()
        {
            return "Круг";
        }
    }
}