using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Представляет список объектов и базовые операции управления.
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// Список объектов класса Person 
        /// </summary>
        private List<Person> _persons;

        /// <summary>
        /// Инициализирует новый экземпляр класса с пустым списком.
        /// </summary>
        public PersonList()
        {
            _persons = new List<Person>();
        }

        /// <summary>
        /// Добавляет указанного человека в конец списка.
        /// </summary>
        public void Add(Person person)
        {
            _persons.Add(person);
        }

        /// <summary>
        /// Удаляет все элементы из списка.
        /// </summary>
        public void Clear()
        {
            _persons.Clear();
        }

        /// <summary>
        /// Удаляет первое вхождение указанного человека из списка.
        /// </summary>
        public void Remove(Person person)
        {
            _persons.Remove(person);
        }

        /// <summary>
        /// Удаляет человека по указанному индексу.
        /// </summary>
        public void RemoveAt(int index)
        {
            _persons.RemoveAt(index);
        }

        /// <summary>
        /// Возвращает человека по указанному индексу.
        /// </summary>
        public Person GetByIndex(int index)
        {
            return _persons[index];
        }

        /// <summary>
        /// Определяет индекс первого вхождения указанного человека в списке.
        /// </summary>
        public int IndexOf(Person person)
        {
            return _persons.IndexOf(person);
        }

        /// <summary>
        /// Возвращает количество людей в списке.
        /// </summary>
        public int Count()
        {
            return _persons.Count;
        }

        /// <summary>
        /// Возвращает список.
        /// </summary>
        public List<Person> Persons
        {
            get
            {
                return _persons;
            }
        }
    }
}
