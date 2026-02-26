using System;
using Model;

namespace LR1
{
    /// <summary>
    /// Точка входа в консольное приложение.
    /// </summary>
    public class Program
    {
        //TODO: XML
        public static void Main(string[] args)
        {
            PersonList list = new PersonList();

            Console.WriteLine("Генерация начальных данных");

            // Добавляем 7 случайных людей (взрослых и детей)
            for (int i = 0; i < 7; i++)
            {
                list.Add(PersonGenerator.GetRandomPerson());
            }

            // Выводим начальное состояние
            Pause("показать начальное состояние");
            PrintPersonList(list, "Список людей");

            // Определяем тип четвертого человека
            Pause("определить тип четвертого человека");
            //TODO: magic (to const)
            //TODO: polymorphism
            if (list.Count() > 3)
            {
                PersonBase fourthPerson = list.GetByIndex(3);
                string typeName = fourthPerson is Adult ? "Взрослый" : "Ребенок";
                Console.WriteLine($"Тип четвертого человека: {typeName}");

                // Демонстрируем МЕТОД, присущий конкретному классу
                switch (fourthPerson)
                {
                    //TODO: {}
                    case Adult adult:
                        Console.WriteLine($"Демонстрация метода: " +
                            $"{adult.GetWorkInfo()}\n");
                        break;
                    case Child child:
                        Console.WriteLine($"Демонстрация метода: " +
                            $"{child.GetStudyInfo()}\n");
                        break;
                }
            }
            //TODO: RSDN
            Console.WriteLine("\nРабота завершена. Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        /// <summary>
        /// Выводит приглашение к продолжению работы.
        /// </summary>
        static void Pause(string nextAction)
        {
            Console.WriteLine($"\nНажмите любую клавишу, " +
                $"чтобы продолжить и {nextAction}");
            Console.ReadKey();
        }

        /// <summary>
        /// Выводит содержимое списка людей в консоль.
        /// </summary>
        public static void PrintPersonList(PersonList list, string listName)
        {
            Console.WriteLine($"\n=== {listName} ===");

            int number = 1;
            foreach (PersonBase person in list.Persons)
            {
                Console.WriteLine($"Человек номер {number}");
                Console.WriteLine(person.GetInfo());
                Console.WriteLine();
                number++;
            }
        }
    }
}