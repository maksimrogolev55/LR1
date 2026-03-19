using System;
using System.Collections.Generic;
using Model;

namespace ConsoleLoader
{
    /// <summary>
    /// Точка входа в консольное приложение.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Главное тело программы.
        /// </summary>
        public static void Main(string[] args)
        {
            Console.WriteLine("Демонстрация работы с геометрическими фигурами\n");

            Console.WriteLine("--- Создание фигур через конструкторы ---");

            Circle circle = new Circle(5);
            Console.WriteLine(circle.GetInfo());

            Rectangle rectangle = new Rectangle(4, 6);
            Console.WriteLine(rectangle.GetInfo());

            Triangle triangle = new Triangle(3, 4, 5);
            Console.WriteLine(triangle.GetInfo());

            Console.WriteLine("\n--- Проверка валидации ---");
            try
            {
                Console.WriteLine("Пытаемся создать круг с радиусом -1:");
                Circle badCircle = new Circle(-1);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"  Ошибка: {ex.Message}");
            }

            try
            {
                Console.WriteLine("\nПытаемся создать треугольник со сторонами 1, 2, 5:");
                Triangle badTriangle = new Triangle(1, 2, 5);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"  Ошибка: {ex.Message}");
            }

            Console.WriteLine("\n--- Демонстрация полиморфизма ---");

            List<ShapeBase> shapes = 
                [
                    new Circle(3), 
                    new Rectangle(2, 8), 
                    new Triangle(5, 6, 7)
                ];

            for (int i = 0; i < 4; i++)
            {
                shapes.Add(ShapeGenerator.GetRandomShape());
            }

            Console.WriteLine($"Создано {shapes.Count} фигур:");
            foreach (ShapeBase shape in shapes)
            {
                Console.WriteLine($"  {shape.GetInfo()}");
            }


            //TODO: remove
            Console.WriteLine("\n--- Работа через ссылку на базовый класс ---");

            ShapeBase shape1 = new Circle(10);
            Console.WriteLine($"shape1: {shape1.GetInfo()}");

            shape1 = new Rectangle(5, 7);
            Console.WriteLine($"shape1: {shape1.GetInfo()}");

            shape1 = new Triangle(6, 8, 10);
            Console.WriteLine($"shape1: {shape1.GetInfo()}");

            Console.WriteLine("\n--- Генерация случайных фигур ---");
            Console.WriteLine("5 случайных фигур:");
            for (int i = 0; i < 5; i++)
            {
                ShapeBase randomShape = ShapeGenerator.GetRandomShape();
                Console.WriteLine($"  {randomShape.GetInfo()}");
            }

            Console.WriteLine("\n--- Ручное создание фигуры ---");
            ShapeBase userShape = ReadShapeFromConsole();
            if (userShape != null)
            {
                Console.WriteLine($"\nСоздана фигура: {userShape.GetInfo()}");
            }

            Console.WriteLine("\nРабота завершена. Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        /// <summary>
        /// Безопасное чтение положительного числа с консоли.
        /// </summary>
        private static double ReadPositiveDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Replace('.', ',');

                if (!double.TryParse(input, out double value))
                {
                    Console.WriteLine("Ошибка: введите корректное число.");
                    continue;
                }

                if (value <= 0)
                {
                    Console.WriteLine("Ошибка: значение должно быть положительным (больше 0).");
                    continue;
                }

                return value;
            }
        }

        /// <summary>
        /// Безопасное чтение целого числа из диапазона.
        /// </summary>
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

                Console.WriteLine($"Ошибка: введите целое число от {min} до {max}.");
            }
        }

        /// <summary>
        /// Создаёт фигуру на основе ввода пользователя.
        /// </summary>
        public static ShapeBase ReadShapeFromConsole()
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
                        case 1:
                        {
                            double radius = ReadPositiveDouble("Введите радиус: ");
                            return new Circle(radius);
                        }

                        case 2:
                        {
                            double width = ReadPositiveDouble("Введите ширину: ");
                            double height = ReadPositiveDouble("Введите высоту: ");
                            return new Rectangle(width, height);
                        }

                        case 3:
                        {
                            Console.WriteLine("\nВведите стороны треугольника:");
                                //TODO: remove
                            double a = ReadPositiveDouble("Сторона A: ");
                            double b = ReadPositiveDouble("Сторона B: ");
                            double c = ReadPositiveDouble("Сторона C: ");

                            if (a + b <= c || a + c <= b || b + c <= a)
                            {
                                Console.WriteLine("Ошибка: стороны не образуют треугольник.");
                                continue;
                            }

                            return new Triangle(a, b, c);
                        }

                        default:
                            //TODO: remove
                            throw new Exception("Неверный выбор.");
                    }
                }
                //TODO: refactor
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message} Попробуйте снова.");
                }
            }
        }
    }
}