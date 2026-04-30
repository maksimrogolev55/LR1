using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;

namespace View
{
    /// <summary>
    /// Форма для поиска геометрических фигур по их характеристикам.
    /// </summary>
    public partial class SearchForm : Form
    {
        /// <summary>
        /// Коллекция всех фигур для поиска.
        /// </summary>
        private List<ShapeBase> _allShapes;

        /// <summary>
        /// Коллекция результатов поиска.
        /// </summary>
        private List<ShapeBase> _searchResult;

        /// <summary>
        /// Инициализирует новый экземпляр формы поиска.
        /// </summary>
        /// <param name="shapes">Коллекция всех фигур, среди которых будет выполняться поиск.</param>
        public SearchForm(List<ShapeBase> shapes)
        {
            InitializeComponent();
            _allShapes = shapes;
            _searchResult = new List<ShapeBase>();
        }

        //TODO: RSDN
        /// <summary>
        /// Обрабатывает нажатие кнопки "Поиск". Выполняет поиск фигур по введенному тексту.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            _searchResult.Clear();
            string searchText = txtSearch.Text.ToLower();

            foreach (ShapeBase shape in _allShapes)
            {
                if (shape.GetInfo().ToLower().Contains(searchText))
                {
                    _searchResult.Add(shape);
                }
            }

            UpdateResultGrid();
            //TODO: RSDN
            lblCount.Text = $"Найдено фигур: {_searchResult.Count}";
        }

        /// <summary>
        /// Обновляет отображение таблицы с результатами поиска.
        /// </summary>
        private void UpdateResultGrid()
        {
            dataGridViewResult.Rows.Clear();

            foreach (ShapeBase shape in _searchResult)
            {
                dataGridViewResult.Rows.Add(
                    shape.GetShapeType(),
                    shape.GetInfo(),
                    shape.CalculateArea().ToString(ShapeBase.DoubleFormat)
                );
            }
        }
    }
}