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

            if (!double.TryParse(textBox1.Text.Replace('.', ','),
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

            if (!double.TryParse(textBox1.Text.Replace('.', ','),
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

            if (!double.TryParse(textBox2.Text.Replace('.', ','),
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

            if (!double.TryParse(textBox1.Text.Replace('.', ','), out a))
            {
                AddError("Сторона A: введите корректное число");
                isValid = false;
            }
            else if (a <= 0)
            {
                AddError("Сторона A: должна быть больше 0");
                isValid = false;
            }

            if (!double.TryParse(textBox2.Text.Replace('.', ','), out b))
            {
                AddError("Сторона B: введите корректное число");
                isValid = false;
            }
            else if (b <= 0)
            {
                AddError("Сторона B: должна быть больше 0");
                isValid = false;
            }

            if (!double.TryParse(textBox3.Text.Replace('.', ','), out c))
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
        /// Обрабатывает нажатие кнопки "ОК". Создает фигуру на основе выбранного типа и введенных параметров.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked)
                {
                    //TODO: duplication+
                    double radius = ParseDouble(textBox1.Text);
                    CreatedShape = new Circle(radius);
                }
                else if (radioButton2.Checked)
                {
                    double width = ParseDouble(textBox1.Text);
                    double height = ParseDouble(textBox2.Text);
                    CreatedShape = new Model.Rectangle(width, height);
                }
                else
                {
                    double a = ParseDouble(textBox1.Text);
                    double b = ParseDouble(textBox2.Text);
                    double c = ParseDouble(textBox3.Text);
                    CreatedShape = new Triangle(a, b, c);
                }

                DialogResult = DialogResult.OK;

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                radioButton1.Checked = true;

                RadioButton1_CheckedChanged(null, null);
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

        //TODO: RSDN+
        /// <summary>
        /// Обрабатывает нажатие кнопки "Случайная фигура". Генерирует и отображает случайную фигуру.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>

        private void BtnRandom_Click(object sender, EventArgs e)
        {
            ShapeBase randomShape = ShapeGenerator.GetRandomShape();

            switch (randomShape)
            {
                //TODO: {}+
                case Circle circle:
                {
                    //TODO: RSDN+
                    radioButton1.Checked = true;
                    textBox1.Text = circle.Radius.ToString();
                    break;
                }
                case Model.Rectangle rect:
                {
                    radioButton2.Checked = true;
                    textBox1.Text = rect.Width.ToString();
                    textBox2.Text = rect.Height.ToString();
                    break;
                }
                case Triangle triangle:
                {
                    radioButton3.Checked = true;
                    textBox1.Text = triangle.SideA.ToString();
                    textBox2.Text = triangle.SideB.ToString();
                    textBox3.Text = triangle.SideC.ToString();
                    break;
                }
            }
        }
        /// <summary>
        /// Обрабатывает изменение выбора радио-кнопки для круга. Настраивает интерфейс для ввода радиуса.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Радиус:";
            label2.Visible = false;
            label3.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
        }

        /// <summary>
        /// Обрабатывает изменение выбора радио-кнопки для прямоугольника. Настраивает интерфейс для ввода ширины и высоты.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Ширина:";
            label2.Text = "Высота:";
            label2.Visible = true;
            label3.Visible = false;
            textBox2.Visible = true;
            textBox3.Visible = false;
        }

        /// <summary>
        /// Обрабатывает изменение выбора радио-кнопки для треугольника. Настраивает интерфейс для ввода трех сторон.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Сторона A:";
            label2.Text = "Сторона B:";
            label3.Text = "Сторона C:";
            label2.Visible = true;
            label3.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
        }
    }
}