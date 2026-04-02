using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Model;

namespace View
{
    /// <summary>
    /// Главная форма приложения для управления коллекцией геометрических фигур.
    /// </summary>
    public partial class MainForm : Form
    {
        private List<ShapeBase> _shapes;

        /// <summary>
        /// Инициализирует новый экземпляр главной формы.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _shapes = new List<ShapeBase>();
            UpdateGrid();
        }

        /// <summary>
        /// Обновляет отображение таблицы с фигурами и счетчик общего количества фигур.
        /// </summary>
        private void UpdateGrid()
        {
            dataGridViewShapes.Rows.Clear();

            foreach (ShapeBase shape in _shapes)
            {
                string info = shape.GetInfo();
                // Извлекаем только информацию о фигуре без площади
                string cleanInfo = info.Substring(info.IndexOf(":") + 2);
                // Удаляем часть с площадью, если она есть
                int areaIndex = cleanInfo.IndexOf(", Площадь:");
                if (areaIndex >= 0)
                {
                    cleanInfo = cleanInfo.Substring(0, areaIndex);
                }

                dataGridViewShapes.Rows.Add(
                    shape.GetShapeType(),
                    cleanInfo,
                    shape.CalculateArea().ToString("F2")
                );
            }

            labelCount.Text = $"Всего фигур: {_shapes.Count}";
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки "Удалить". Удаляет выбранную фигуру из списка.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dataGridViewShapes.SelectedRows.Count > 0)
            {
                int index = dataGridViewShapes.SelectedRows[0].Index;
                _shapes.RemoveAt(index);
                UpdateGrid();
            }
            else
            {
                MessageBox.Show("Выберите фигуру для удаления.", "Удаление",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки "Поиск". Открывает форму поиска фигур.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SearchForm searchForm = new SearchForm(_shapes))
            {
                searchForm.ShowDialog();
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки "Сохранить". Сохраняет коллекцию фигур в XML-файл.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Файлы фигур (*.shp)|*.shp";
                saveDialog.DefaultExt = "shp";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XmlSerializer serializer = new XmlSerializer(
                            typeof(List<ShapeBase>),
                            new Type[] { typeof(Circle), typeof(Model.Rectangle), typeof(Triangle) });

                        using (StreamWriter writer = new StreamWriter(saveDialog.FileName))
                        {
                            serializer.Serialize(writer, _shapes);
                        }

                        MessageBox.Show("Данные сохранены успешно.", "Сохранение",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки "Добавить". Открывает форму добавления новой фигуры.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddShapeForm addForm = new AddShapeForm();
            addForm.ShowDialog();

            if (addForm.CreatedShape != null)
            {
                _shapes.Add(addForm.CreatedShape);
                UpdateGrid();
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки "Загрузить". Загружает коллекцию фигур из XML-файла.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "Файлы фигур (*.shp)|*.shp";

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (!File.Exists(openDialog.FileName))
                        {
                            MessageBox.Show("Файл не существует.", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string content = File.ReadAllText(openDialog.FileName);
                        if (string.IsNullOrWhiteSpace(content))
                        {
                            MessageBox.Show("Файл пуст.", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        XmlSerializer serializer = new XmlSerializer(
                            typeof(List<ShapeBase>),
                            new Type[] { typeof(Circle), typeof(Model.Rectangle), typeof(Triangle) });

                        using (StreamReader reader = new StreamReader(openDialog.FileName))
                        {
                            _shapes = (List<ShapeBase>)serializer.Deserialize(reader);
                        }

                        UpdateGrid();
                        MessageBox.Show("Данные загружены успешно.", "Загрузка",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (InvalidOperationException)
                    {
                        MessageBox.Show("Ошибка: файл повреждён или имеет неверный формат.", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}