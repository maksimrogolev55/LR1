using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// Представляет список объектов и базовые операции управления.
    /// </summary>
    public class PersonList
    {
        private List<PersonBase> _persons;

        public PersonList()
        {
            _persons = new List<PersonBase>();
        }

        public void Add(PersonBase person)
        {
            _persons.Add(person);
        }

        public void Clear()
        {
            _persons.Clear();
        }

        public void Remove(PersonBase person)
        {
            _persons.Remove(person);
        }

        public void RemoveAt(int index)
        {
            _persons.RemoveAt(index);
        }

        public PersonBase GetByIndex(int index)
        {
            return _persons[index];
        }

        public int IndexOf(PersonBase person)
        {
            return _persons.IndexOf(person);
        }

        public int Count()
        {
            return _persons.Count;
        }

        public List<PersonBase> Persons
        {
            get
            {
                return new List<PersonBase>(_persons);
            }
        }
    }
}
