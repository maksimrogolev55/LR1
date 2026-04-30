using System;

namespace Model
{
    /// <summary>
    /// Класс, представляющий треугольник.
    /// </summary>
    public class Triangle : ShapeBase
    {
        //TODO: XML+
        /// <summary>
        /// Конструктор по умолчанию для сериализации.
        /// </summary>
        public Triangle() { }

        /// <summary>
        /// Сторона A.
        /// </summary>
        private double _sideA;

        /// <summary>
        /// Сторона B.
        /// </summary>
        private double _sideB;

        /// <summary>
        /// Сторона C.
        /// </summary>
        private double _sideC;

        /// <summary>
        /// Инициализирует новый экземпляр класса Triangle.
        /// </summary>
        /// <param name="sideA">Сторона A.</param>
        /// <param name="sideB">Сторона B.</param>
        /// <param name="sideC">Сторона C.</param>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если стороны некорректны.
        /// </exception>
        public Triangle(double sideA, double sideB, double sideC)
        {
            _sideA = sideA;
            _sideB = sideB;
            _sideC = sideC;
            Validate();
        }

/// <summary>
/// Проверяет корректность параметров треугольника.
/// </summary>
/// <exception cref="ArgumentException">
/// Выбрасывается, если стороны некорректны.
/// </exception>
public override void Validate()
{
    ValidatePositive(_sideA, nameof(SideA));
    ValidatePositive(_sideB, nameof(SideB));
    ValidatePositive(_sideC, nameof(SideC));

    if (_sideA + _sideB <= _sideC ||
        _sideA + _sideC <= _sideB ||
        _sideB + _sideC <= _sideA)
    {
        throw new ArgumentException(
            $"Стороны ({_sideA.ToString(DoubleFormat)}, " +
            $"{_sideB.ToString(DoubleFormat)}, " +
            $"{_sideC.ToString(DoubleFormat)}) не образуют треугольник.");
    }
}

        /// <summary>
        /// Получает или задает сторону A.
        /// <summary>
        public double SideA
        {
            get
            {
                return _sideA;
            }
            set
            {
                _sideA = value;
            }
        }

        /// <summary>
        /// Получает или задает сторону B.
        /// <summary>
        public double SideB
        {
            get
            {
                return _sideB;
            }
            set
            {
                _sideB = value;
            }
        }

        /// <summary>
        /// Получает или задает сторону C.
        /// <summary>
        public double SideC
        {
            get
            {
                return _sideC;
            }
            set
            {
                _sideC = value;
            }
        }

        /// <summary>
        /// Вычисляет площадь треугольника по формуле Герона.
        /// </summary>
        /// <returns>Площадь треугольника.</returns>
        public override double CalculateArea()
        {
            double semiPerimeter = (_sideA + _sideB + _sideC) / 2.0;
            double area = Math.Sqrt(
                semiPerimeter
                * (semiPerimeter - _sideA)
                * (semiPerimeter - _sideB)
                * (semiPerimeter - _sideC));
            return area;
        }

        /// <summary>
        /// Возвращает информацию о треугольнике.
        /// </summary>
        /// <returns>Строка с информацией о треугольнике.</returns>
        public override string GetInfo()
        {
            return $"Треугольник: стороны = " +
                   $"{_sideA.ToString(DoubleFormat)}, " +
                   $"{_sideB.ToString(DoubleFormat)}, " +
                   $"{_sideC.ToString(DoubleFormat)}, " +
                   $"площадь = {CalculateArea().ToString(DoubleFormat)}";
        }

        //TODO: XML+
        /// <summary>
        /// Возвращает тип фигуры.
        /// </summary>
        public override string GetShapeType()
        {
            return "Треугольник";
        }
    }
}