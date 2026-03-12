using System;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// Представляет список геометрических фигур.
    /// </summary>
    public class ShapeList
    {
        /// <summary>
        /// Внутренний список фигур.
        /// </summary>
        private List<Shape> _shapes;

        /// <summary>
        /// Инициализирует новый экземпляр класса ShapeList.
        /// </summary>
        public ShapeList()
        {
            _shapes = new List<Shape>();
        }

        /// <summary>
        /// Добавляет фигуру в список.
        /// </summary>
        /// <param name="shape">Добавляемая фигура.</param>
        public void Add(Shape shape)
        {
            _shapes.Add(shape);
        }

        /// <summary>
        /// Очищает список.
        /// </summary>
        public void Clear()
        {
            _shapes.Clear();
        }

        /// <summary>
        /// Удаляет фигуру из списка.
        /// </summary>
        /// <param name="shape">Удаляемая фигура.</param>
        public void Remove(Shape shape)
        {
            _shapes.Remove(shape);
        }

        /// <summary>
        /// Удаляет фигуру по индексу.
        /// </summary>
        /// <param name="index">Индекс удаляемой фигуры.</param>
        public void RemoveAt(int index)
        {
            if (index >= 0 && index < _shapes.Count)
            {
                _shapes.RemoveAt(index);
            }
        }

        /// <summary>
        /// Возвращает фигуру по индексу.
        /// </summary>
        /// <param name="index">Индекс фигуры.</param>
        /// <returns>Фигура по указанному индексу.</returns>
        /// <exception cref="IndexOutOfRangeException">
        /// Выбрасывается, если индекс вне границ списка.
        /// </exception>
        public Shape GetByIndex(int index)
        {
            if (index >= 0 && index < _shapes.Count)
            {
                return _shapes[index];
            }

            throw new IndexOutOfRangeException(
                "Индекс вне границ списка.");
        }

        /// <summary>
        /// Возвращает индекс фигуры в списке.
        /// </summary>
        /// <param name="shape">Искомая фигура.</param>
        /// <returns>Индекс фигуры или -1.</returns>
        public int IndexOf(Shape shape)
        {
            return _shapes.IndexOf(shape);
        }

        /// <summary>
        /// Возвращает количество фигур в списке.
        /// </summary>
        /// <returns>Количество фигур.</returns>
        public int Count()
        {
            return _shapes.Count;
        }

        /// <summary>
        /// Возвращает копию списка фигур.
        /// </summary>
        public List<Shape> Shapes
        {
            get
            {
                return new List<Shape>(_shapes);
            }
        }
    }
}