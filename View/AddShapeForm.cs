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

#if !DEBUG
            btnRandom.Visible = false;
#endif
        }

        private double ParseDouble(string text)
        {
            return double.Parse(text.Replace('.', ','));
        }

        private List<string> _errors;

        private void ClearErrors()
        {
            _errors = new List<string>();
        }

        private void AddError(string message)
        {
            _errors.Add(message);
        }

        private bool ValidateCircleInput()
        {
            bool isValid = true;

            if (!double.TryParse(_textBoxParameterOne.Text.Replace('.', ','),
                out double radius))
            {
                AddError("Радиус: введите корректное число");
                isValid = false;
            }
            else if (radius <= 0)
            {
                AddError("Радиус: должен быть больше 0");
                isValid = false;
            }

            return isValid;
        }

        private bool ValidateRectangleInput()
        {
            bool isValid = true;

            if (!double.TryParse(_textBoxParameterOne.Text.Replace('.', ','),
                out double width))
            {
                AddError("Ширина: введите корректное число");
                isValid = false;
            }
            else if (width <= 0)
            {
                AddError("Ширина: должна быть больше 0");
                isValid = false;
            }

            if (!double.TryParse(_textBoxParameterTwo.Text.Replace('.', ','),
                out double height))
            {
                AddError("Высота: введите корректное число");
                isValid = false;
            }
            else if (height <= 0)
            {
                AddError("Высота: должна быть больше 0");
                isValid = false;
            }

            return isValid;
        }

        private bool ValidateTriangleInput()
        {
            bool isValid = true;
            double a = 0, b = 0, c = 0;

            if (!double.TryParse(_textBoxParameterOne.Text.Replace('.', ','), out a))
            {
                AddError("Сторона A: введите корректное число");
                isValid = false;
            }
            else if (a <= 0)
            {
                AddError("Сторона A: должна быть больше 0");
                isValid = false;
            }

            if (!double.TryParse(_textBoxParameterTwo.Text.Replace('.', ','), out b))
            {
                AddError("Сторона B: введите корректное число");
                isValid = false;
            }
            else if (b <= 0)
            {
                AddError("Сторона B: должна быть больше 0");
                isValid = false;
            }

            if (!double.TryParse(_textBoxParameterThree.Text.Replace('.', ','), out c))
            {
                AddError("Сторона C: введите корректное число");
                isValid = false;
            }
            else if (c <= 0)
            {
                AddError("Сторона C: должна быть больше 0");
                isValid = false;
            }

            if (isValid)
            {
                if (a + b <= c || a + c <= b || b + c <= a)
                {
                    AddError("Стороны не образуют треугольник");
                    isValid = false;
                }
            }

            return isValid;
        }

        /// <summary>
        /// //TODO: RSDN+
        /// Обрабатывает нажатие кнопки "ОК". Создает фигуру на основе
        /// выбранного типа и введенных параметров.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void ButtonOkClick(object sender, EventArgs e)
        {
            try
            {
                //TODO: RSDN+
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
        /// //TODO: RSDN+
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
        //TODO: RSDN+
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
        /// Обрабатывает изменение выбора радио-кнопки для прямоугольника. Настраивает интерфейс для ввода ширины и высоты.
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
        /// Обрабатывает изменение выбора радио-кнопки для треугольника. Настраивает интерфейс для ввода трех сторон.
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