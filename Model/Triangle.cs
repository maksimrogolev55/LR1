using System;

namespace Model
{
    /// <summary>
    /// Класс, представляющий треугольник.
    /// </summary>
    public class Triangle : Shape
    {
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
        /// Конструктор по умолчанию.
        /// </summary>
        public Triangle()
        {
        }

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
            ValidateAll();
        }

        /// <summary>
        /// Проверяет все условия для сторон треугольника.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если стороны некорректны.
        /// </exception>
        private void ValidateAll()
        {
            ValidatePositive(_sideA, nameof(SideA));
            ValidatePositive(_sideB, nameof(SideB));
            ValidatePositive(_sideC, nameof(SideC));
            ValidateTriangleSides(_sideA, _sideB, _sideC);
        }

        /// <summary>
        /// Получает или задает сторону A.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если сторона некорректна.
        /// </exception>
        public double SideA
        {
            get
            {
                return _sideA;
            }
            set
            {
                _sideA = value;
                ValidateAll();
            }
        }

        /// <summary>
        /// Получает или задает сторону B.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если сторона некорректна.
        /// </exception>
        public double SideB
        {
            get
            {
                return _sideB;
            }
            set
            {
                _sideB = value;
                ValidateAll();
            }
        }

        /// <summary>
        /// Получает или задает сторону C.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если сторона некорректна.
        /// </exception>
        public double SideC
        {
            get
            {
                return _sideC;
            }
            set
            {
                _sideC = value;
                ValidateAll();
            }
        }

        /// <summary>
        /// Вычисляет площадь треугольника по формуле Герона.
        /// </summary>
        /// <returns>Площадь треугольника.</returns>
        public override double CalculateArea()
        {
            double p = (_sideA + _sideB + _sideC) / 2.0;
            double area = Math.Sqrt(
                p * (p - _sideA) * (p - _sideB) * (p - _sideC));
            return area;
        }

        /// <summary>
        /// Возвращает информацию о треугольнике.
        /// </summary>
        /// <returns>Строка с информацией о треугольнике.</returns>
        public override string GetInfo()
        {
            return $"Треугольник: стороны = " +
                   $"{_sideA:F2}, {_sideB:F2}, {_sideC:F2}, " +
                   $"площадь = {CalculateArea():F2}";
        }
    }
}