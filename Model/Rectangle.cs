namespace Model
{
    /// <summary>
    /// Класс, представляющий прямоугольник.
    /// </summary>
    public class Rectangle : ShapeBase
    {
        //TODO: XML+
        /// <summary>
        /// Конструктор по умолчанию для сериализации.
        /// </summary>
        public Rectangle() { }

        /// <summary>
        /// Ширина прямоугольника.
        /// </summary>
        private double _width;

        /// <summary>
        /// Высота прямоугольника.
        /// </summary>
        private double _height;

        /// <summary>
        /// Инициализирует новый экземпляр класса Rectangle.
        /// </summary>
        /// <param name="width">Ширина прямоугольника.</param>
        /// <param name="height">Высота прямоугольника.</param>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если стороны меньше или равны 0.
        /// </exception>
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
            Validate();
        }

        /// <summary>
        /// Получает или задает ширину прямоугольника.
        /// </exception>
        public double Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        /// <summary>
        /// Проверяет корректность параметров прямоугольника.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если стороны меньше или равны 0.
        /// </exception>
        public override void Validate()
        {
            ValidatePositive(_width, nameof(Width));
            ValidatePositive(_height, nameof(Height));
        }

        /// <summary>
        /// Получает или задает высоту прямоугольника.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если высота меньше или равна 0.
        /// </exception>
        public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        /// <summary>
        /// Вычисляет площадь прямоугольника.
        /// </summary>
        /// <returns>Площадь прямоугольника.</returns>
        public override double CalculateArea()
        {
            return _width * _height;
        }

        /// <summary>
        /// Возвращает информацию о прямоугольнике.
        /// </summary>
        /// <returns>Строка с информацией о прямоугольнике.</returns>
        public override string GetInfo()
        {
            return $"Прямоугольник: ширина = " +
                   $"{_width.ToString(DoubleFormat)}, " +
                   $"высота = {_height.ToString(DoubleFormat)}, " +
                   $"площадь = {CalculateArea().ToString(DoubleFormat)}";
        }

        //TODO: XML+
        /// <summary>
        /// Возвращает тип фигуры.
        /// </summary>
        public override string GetShapeType()
        {
            return "Прямоугольник";
        }
    }
}