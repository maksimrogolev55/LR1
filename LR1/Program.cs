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
        /// Индекс третьей фигуры в списке (нумерация с 0).
        /// </summary>
        private const int ThirdShapeIndex = 2;

        /// <summary>
        /// Главное тело программы.
        /// </summary>
        public static void Main(string[] args)
        {
            ShapeList list1 = new ShapeList();
            ShapeList list2 = new ShapeList();

            Console.WriteLine("Генерация начальных данных");

            for (int i = 0; i < 3; ++i)
            {
                list1.Add(Shape.GetRandomShape());
            }

            for (int i = 0; i < 3; ++i)
            {
                list2.Add(Shape.GetRandomShape());
            }

            Pause("показать начальное состояние");
            PrintShapeList(list1, "Список 1");
            PrintShapeList(list2, "Список 2");

            Pause("добавить новую фигуру в Список 1");
            list1.Add(new Circle(5.5));
            PrintShapeList(list1, "Список 1 (после добавления)");

            Pause("скопировать 2-ю фигуру из Списка 1 в Список 2");

            Shape shapeToCopy = list1.GetByIndex(1);
            list2.Add(shapeToCopy);
            PrintShapeList(list1, "Список 1 (после копирования)");
            PrintShapeList(list2, "Список 2 (после копирования)");

            Pause("удалить 2-ю фигуру из Списка 1");
            list1.RemoveAt(1);
            PrintShapeList(list1, "Список 1 (после удаления)");
            PrintShapeList(
                list2,
                "Список 2 (остался без изменений)");

            Pause("очистить Список 2");
            list2.Clear();
            PrintShapeList(list2, "Список 2 (очищен)");

            Console.WriteLine(
                "\nДобавим фигуру вручную в Список 1:");

            Shape newShape = ReadFromConsole();
            list1.Add(newShape);
            PrintShapeList(
                list1,
                "Список 1 (после ручного добавления)");

            Console.WriteLine(
                "\nРабота завершена. Нажмите любую " +
                "клавишу для выхода...");

            Console.ReadKey();
        }

        /// <summary>
        /// Выводит приглашение к продолжению работы.
        /// </summary>
        /// <param name="nextAction">Описание дальнейшего действия.</param>
        private static void Pause(string nextAction)
        {
            Console.WriteLine(
                $"\nНажмите любую клавишу, чтобы " +
                $"продолжить и {nextAction}");

            Console.ReadKey();
        }

        /// <summary>
        /// Выводит содержимое списка фигур в консоль.
        /// </summary>
        /// <param name="list">Список фигур.</param>
        /// <param name="listName">Название списка.</param>
        public static void PrintShapeList(
            ShapeList list,
            string listName)
        {
            Console.WriteLine($"\n=== {listName} ===");

            if (list.Count() == 0)
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            int number = 1;
            foreach (Shape shape in list.Shapes)
            {
                Console.WriteLine(
                    $"Фигура номер {number}: " +
                    $"{shape.GetInfo()}");

                ++number;
            }
        }

        /// <summary>
        /// Безопасное чтение double с проверкой на положительность.
        /// </summary>
        /// <param name="prompt">Приглашение для ввода.</param>
        /// <returns>Положительное число.</returns>
        private static double ReadPositiveDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()
                    ?.Replace('.', ',');

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
        /// Безопасное чтение целого числа из диапазона.
        /// </summary>
        /// <param name="prompt">Приглашение для ввода.</param>
        /// <param name="min">Минимальное значение.</param>
        /// <param name="max">Максимальное значение.</param>
        /// <returns>Целое число в заданном диапазоне.</returns>
        private static int ReadInt(
            string prompt,
            int min,
            int max)
        {
            while (true)
            {
                Console.Write(prompt);

                if (int.TryParse(
                    Console.ReadLine(),
                    out int result)
                    && result >= min
                    && result <= max)
                {
                    return result;
                }

                Console.WriteLine(
                    $"Ошибка: введите целое число " +
                    $"от {min} до {max}.");
            }
        }

        /// <summary>
        /// Ввод пользователя с консоли с валидацией до создания объекта.
        /// </summary>
        /// <returns>Созданная фигура.</returns>
        public static Shape ReadFromConsole()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(
                        "\nВыберите тип фигуры:");
                    Console.WriteLine("1 — круг");
                    Console.WriteLine("2 — прямоугольник");
                    Console.WriteLine("3 — треугольник");

                    int choice = ReadInt(
                        "Ваш выбор: ",
                        1,
                        3);

                    switch (choice)
                    {
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

                                double a = ReadPositiveDouble(
                                    "Сторона A: ");
                                double b = ReadPositiveDouble(
                                    "Сторона B: ");
                                double c = ReadPositiveDouble(
                                    "Сторона C: ");

                                if (a + b <= c
                                    || a + c <= b
                                    || b + c <= a)
                                {
                                    Console.WriteLine(
                                        "Ошибка: стороны " +
                                        "не образуют треугольник.");
                                    continue;
                                }

                                return new Triangle(a, b, c);
                            }

                        default:
                            {
                                throw new Exception(
                                    "Неверный выбор.");
                            }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(
                        $"Ошибка: {ex.Message} " +
                        $"Попробуйте снова.");
                }
            }
        }
    }
}