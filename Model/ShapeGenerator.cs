using System;

namespace Model
{
    //TODO: refactor
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
            double a;
            double b;
            double c;

            do
            {
                a = _random.NextDouble() * 8 + 2;
                b = _random.NextDouble() * 8 + 2;
                c = _random.NextDouble() * 8 + 2;
            }
            while (a + b <= c || a + c <= b || b + c <= a);

            return new Triangle(a, b, c);
        }

        /// <summary>
        /// Генерирует случайную фигуру.
        /// </summary>
        /// <returns>Случайная фигура.</returns>
        public static Shape GetRandomShape()
        {
            int type = _random.Next(0, 3);

            switch (type)
            {
                case 0:
                    return GetRandomCircle();

                case 1:
                    return GetRandomRectangle();

                default:
                    return GetRandomTriangle();
            }
        }

        /// <summary>
        /// Вспомогательный метод для безопасного ввода double
        /// с повторными попытками.
        /// </summary>
        /// <param name="prompt">Приглашение для ввода.</param>
        /// <returns>Положительное число.</returns>
        private static double ReadPositiveDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Replace('.', ',');

                if (!double.TryParse(input, out double value))
                {
                    Console.WriteLine(
                        "Ошибка: введите корректное число.");
                    continue;
                }

                if (value <= 0)
                {
                    Console.WriteLine(
                        "Ошибка: значение должно быть " +
                        "положительным (больше 0).");
                    continue;
                }

                return value;
            }
        }

        /// <summary>
        /// Вспомогательный метод для безопасного ввода целого числа
        /// с повторными попытками.
        /// </summary>
        /// <param name="prompt">Приглашение для ввода.</param>
        /// <param name="min">Минимальное значение.</param>
        /// <param name="max">Максимальное значение.</param>
        /// <returns>Целое число в заданном диапазоне.</returns>
        private static int ReadInt(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);

                if (int.TryParse(Console.ReadLine(), out int result)
                    && result >= min
                    && result <= max)
                {
                    return result;
                }

                Console.WriteLine(
                    $"Ошибка: введите целое число от {min} до {max}.");
            }
        }

        /// <summary>
        /// Генерирует фигуру на основе ввода пользователя
        /// с повторными попытками при ошибках.
        /// </summary>
        /// <returns>Созданная пользователем фигура.</returns>
        public static Shape CreateShapeFromInput()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\nВыберите тип фигуры:");
                    Console.WriteLine("1 — круг");
                    Console.WriteLine("2 — прямоугольник");
                    Console.WriteLine("3 — треугольник");

                    int choice = ReadInt("Ваш выбор: ", 1, 3);

                    switch (choice)
                    {
                        //TOOD: отступы
                        case 1:
                            {
                                double radius = ReadPositiveDouble(
                                    "Введите радиус: ");
                                return new Circle(radius);
                            }

                        case 2:
                            {
                                double width = ReadPositiveDouble(
                                    "Введите ширину: ");
                                double height = ReadPositiveDouble(
                                    "Введите высоту: ");
                                return new Rectangle(width, height);
                            }

                        case 3:
                            {
                                Console.WriteLine(
                                    "\nВведите стороны треугольника:");

                                double a = ReadPositiveDouble("Сторона A: ");
                                double b = ReadPositiveDouble("Сторона B: ");
                                double c = ReadPositiveDouble("Сторона C: ");

                                //TODO: refactor
                                if (a + b <= c
                                    || a + c <= b
                                    || b + c <= a)
                                {
                                    Console.WriteLine(
                                        "Ошибка: стороны не образуют " +
                                        "треугольник.");
                                    continue;
                                }

                                return new Triangle(a, b, c);
                            }

                        default:
                            {
                                throw new Exception("Неверный выбор.");
                            }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(
                        $"Ошибка: {ex.Message} Попробуйте снова.");
                }
            }
        }
    }
}