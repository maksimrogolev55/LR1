using System;
using System.Windows.Forms;
using Model;

namespace View
{
    /// <summary>
    /// Форма для добавления новой геометрической фигуры.
    /// </summary>
    public partial class AddShapeForm : Form
    {
        /// <summary>
        /// Получает созданную фигуру после успешного подтверждения.
        /// </summary>
        public ShapeBase CreatedShape { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр формы добавления фигуры.
        /// </summary>
        public AddShapeForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Преобразует строку в число, заменяя точку на запятую.
        /// </summary>
        /// <param name="text">Строка для преобразования.</param>
        /// <returns>Числовое значение.</returns>
        private double ParseDouble(string text)
        {
            return double.Parse(text.Replace('.', ','));
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки "ОК". Создает фигуру на основе
        /// выбранного типа и введенных параметров.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void ButtonOkClick(object sender, EventArgs e)
        {
            try
            {
                if (_radioButtonCircle.Checked)
                {
                    double radius = ParseDouble(_textBoxParameterOne.Text);
                    CreatedShape = new Circle(radius);
                }
                else if (_radioButtonRectangle.Checked)
                {
                    double width = ParseDouble(_textBoxParameterOne.Text);
                    double height = ParseDouble(_textBoxParameterTwo.Text);
                    CreatedShape = new Model.Rectangle(width, height);
                }
                else
                {
                    double a = ParseDouble(_textBoxParameterOne.Text);
                    double b = ParseDouble(_textBoxParameterTwo.Text);
                    double c = ParseDouble(_textBoxParameterThree.Text);
                    CreatedShape = new Triangle(a, b, c);
                }

                DialogResult = DialogResult.OK;

                _textBoxParameterOne.Clear();
                _textBoxParameterTwo.Clear();
                _textBoxParameterThree.Clear();
                _radioButtonCircle.Checked = true;

                RadioButtonCircleCheckedChanged(null, null);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка ввода: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки "Случайная фигура".
        /// Генерирует и отображает случайную фигуру.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void ButtonRandomClick(object sender, EventArgs e)
        {
            ShapeBase randomShape = ShapeGenerator.GetRandomShape();

            switch (randomShape)
            {
                case Circle circle:
                {
                    _radioButtonCircle.Checked = true;
                    _textBoxParameterOne.Text = circle.Radius.ToString();
                    break;
                }
                case Model.Rectangle rect:
                {
                    _radioButtonRectangle.Checked = true;
                    _textBoxParameterOne.Text = rect.Width.ToString();
                    _textBoxParameterTwo.Text = rect.Height.ToString();
                    break;
                }
                case Triangle triangle:
                {
                    _radioButtonTriangle.Checked = true;
                    _textBoxParameterOne.Text = triangle.SideA.ToString();
                    _textBoxParameterTwo.Text = triangle.SideB.ToString();
                    _textBoxParameterThree.Text = triangle.SideC.ToString();
                    break;
                }
            }
        }

        /// <summary>
        /// Обрабатывает изменение выбора радио-кнопки для круга.
        /// Настраивает интерфейс для ввода радиуса.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void RadioButtonCircleCheckedChanged(object sender, EventArgs e)
        {
            _labelParameterOne.Text = "Радиус:";
            _labelParameterTwo.Visible = false;
            _labelParameterThree.Visible = false;
            _textBoxParameterTwo.Visible = false;
            _textBoxParameterThree.Visible = false;
        }

        /// <summary>
        /// Обрабатывает изменение выбора радио-кнопки для прямоугольника.
        /// Настраивает интерфейс для ввода ширины и высоты.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void RadioButtonRectangleCheckedChanged(object sender, EventArgs e)
        {
            _labelParameterOne.Text = "Ширина:";
            _labelParameterTwo.Text = "Высота:";
            _labelParameterTwo.Visible = true;
            _labelParameterThree.Visible = false;
            _textBoxParameterTwo.Visible = true;
            _textBoxParameterThree.Visible = false;
        }

        /// <summary>
        /// Обрабатывает изменение выбора радио-кнопки для треугольника.
        /// Настраивает интерфейс для ввода трех сторон.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void RadioButtonTriangleCheckedChanged(object sender, EventArgs e)
        {
            _labelParameterOne.Text = "Сторона A:";
            _labelParameterTwo.Text = "Сторона B:";
            _labelParameterThree.Text = "Сторона C:";
            _labelParameterTwo.Visible = true;
            _labelParameterThree.Visible = true;
            _textBoxParameterTwo.Visible = true;
            _textBoxParameterThree.Visible = true;
        }
    }
}