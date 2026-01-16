using System;
using System.Reflection;
using Model;

namespace LR1
{
    /// <summary>
    /// Точка входа в консольное приложение.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Главное тело программы.
        /// </summary>
        /// <param name="args">аргумент</param>
        public static void Main(string[] args)
        {
            PersonList list1 = new PersonList();
            PersonList list2 = new PersonList();

            Console.WriteLine("Генерация начальных данных");

            // Заполняем list1 тремя случайными персонами
            for (int i = 0; i < 3; i++)
            {
                list1.Add(Person.GetRandomPerson());
            }

            // Заполняем list2 тремя случайными персонами
            for (int i = 0; i < 3; i++)
            {
                list2.Add(Person.GetRandomPerson());
            }

            // Выводим исходное состояние
            Pause("показать начальное состояние");
            PrintPersonList(list1, "Список 1");
            PrintPersonList(list2, "Список 2");

            // Добавляем нового человека в первый список
            Pause("добавить нового человека в Список 1");
            list1.Add(new Person("Октябрина", "Картошкина", 27, Gender.Female));
            PrintPersonList(list1, "Список 1 (после добавления)");

            // Копируем второго человека из первого списка в конец второго
            Pause("скопировать 2-го человека из Списка 1 в Список 2");
            Person personToCopy = list1.GetByIndex(1);
            list2.Add(personToCopy);
            PrintPersonList(list1, "Список 1 (после копирования)");
            PrintPersonList(list2, "Список 2 (после копирования)");

            // Удаляем второго человека из первого списка
            Pause("удалить 2-го человека из Списка 1");
            list1.RemoveAt(1); // Удаляем по индексу
            PrintPersonList(list1, "Список 1 (после удаления)");
            PrintPersonList(list2, "Список 2 (остался без изменений)");

            // Очищаем второй список
            Pause("очистить Список 2");
            list2.Clear();
            PrintPersonList(list2, "Список 2 (очищен)");
            Console.WriteLine("\nРабота завершена." +
                " Нажмите любую клавишу для выхода...");
            Console.ReadKey();

            // Ввод, добавление в список, вывод
            Console.WriteLine("\nДобавим человека вручную в Список 1:");
            Person newperson = ReadFromConsole();
            list1.Add(newperson);
            PrintPersonList(list1, "Список 1 (после ручного добавления)");
            Console.WriteLine("\nГотово! Нажмите любую клавишу.");
            Console.ReadKey();
        }

        /// <summary>
        /// Выводит приглашение к продолжению работы.
        /// </summary>
        /// <param name="nextAction">описание дальнейшего действия</param>
        static void Pause(string nextAction)
        {
            Console.WriteLine($"\nНажмите любую клавишу," +
                $" чтобы продолжить и {nextAction}");
            Console.ReadKey();
        }
        /// <summary>
        /// Выводит содержимое списка людей в консоль.
        /// </summary>
        /// <param name="list">список людей</param>
        /// <param name="listName">название списка</param>
        public static void PrintPersonList(PersonList list, string listName)
        {
            Console.WriteLine($"\n=^-^= {listName} =^-^=");
            foreach (Person person in list.Persons)
            {
                string genderStr = person.Gender switch
                {
                    Gender.Male => "Мужчина",
                    Gender.Female => "Женщина",
                    _ => "Неизвестно"
                };
                Console.WriteLine($"Имя: {person.Name}," +
                    $" Фамилия: {person.Surname}," +
                    $" Возраст: {person.Age}," + $" Пол: {genderStr}");
            }
        }

        /// <summary>
        /// Ввод пользователя с консоли.
        /// </summary>
        /// <returns>возвращает объект класса Person</returns>
        /// <exception cref="Exception">создание при неверном вводе</exception>
        public static Person ReadFromConsole()
        {
            var person = new Person();

            var actionDictionary = new Dictionary<string, Action>()
            {
                {
                    "имя",
                    new Action(() =>
                    {
                        person.Name = Console.ReadLine();
                    })
                },
                {
                    "фамилию",
                    new Action(() =>
                    {
                        person.Surname = Console.ReadLine();
                    })
                },
                {
                    "возраст",
                    new Action(() =>
                    {
                        if (int.TryParse(Console.ReadLine(), out int age))
                        {
                            person.Age = age;
                        }
                        else
                        {
                            throw new Exception("Введённая строка " +
                                "не может быть преобразована в число");
                        }
                    })
                },
                {
                    "пол (1 — Мужчина, 2 — Женщина)",
                    new Action(() =>
                    {
                        string input = Console.ReadLine();
                        switch (input)
                        {
                            case "1":
                            {
                                person.Gender = Gender.Male;
                                break;
                            }
                            case "2":
                            {
                                person.Gender = Gender.Female;
                                break;
                            }
                            default:
                            {
                                throw new Exception("Некорректный ввод" +
                                    " Введите 1 или 2.");
                            }

                        }
                    })
                }
            };

            foreach (var actionHandler in actionDictionary)
            {
                ActionHandler(actionHandler.Value, actionHandler.Key);
            }

            return person;
        }
        /// <summary>
        /// При возникновении исключения выводит сообщение и повторяет ввод.
        /// </summary>
        /// <param name="action">Действие, ввод и присваивание</param>
        /// <param name="fieldName">Название поля</param>
        private static void ActionHandler(Action action, string fieldName)
        {
            while (true)
            {
                try
                {
                    Console.Write($"Введите {fieldName}: ");
                    action.Invoke();
                    return;
                }
                catch (Exception exception)
                {
                    Console.WriteLine($" Ошибка: {exception.Message}" +
                        $" Попробуйте снова.");
                }
            }
        }
    }
}