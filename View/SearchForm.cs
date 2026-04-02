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
        //TODO: XML
        private List<ShapeBase> _allShapes;

        //TODO: XML
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
                    //TODO: duplication
                    shape.CalculateArea().ToString("F2")
                );
            }
        }
    }
}