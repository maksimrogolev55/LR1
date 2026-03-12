namespace Model
{
    /// <summary>
    /// Класс, представляющий прямоугольник.
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// Ширина прямоугольника.
        /// </summary>
        private double _width;

        /// <summary>
        /// Высота прямоугольника.
        /// </summary>
        private double _height;

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Rectangle()
        {
        }

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
        }

        /// <summary>
        /// Получает или задает ширину прямоугольника.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если ширина меньше или равна 0.
        /// </exception>
        public double Width
        {
            get
            {
                return _width;
            }
            set
            {
                ValidatePositive(value, nameof(Width));
                _width = value;
            }
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
                ValidatePositive(value, nameof(Height));
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
            return $"Прямоугольник: ширина = {_width:F2}, " +
                   $"высота = {_height:F2}, " +
                   $"площадь = {CalculateArea():F2}";
        }
    }
}