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

        /// <summary>
        /// //TODO: RSDN
        /// Обрабатывает нажатие кнопки "ОК". Создает фигуру на основе выбранного типа и введенных параметров.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked)
                {
                    //TODO: duplication
                    double radius = double.Parse(textBox1.Text.Replace('.', ','));
                    CreatedShape = new Circle(radius);
                }
                else if (radioButton2.Checked)
                {
                    double width = double.Parse(textBox1.Text.Replace('.', ','));
                    double height = double.Parse(textBox2.Text.Replace('.', ','));
                    CreatedShape = new Model.Rectangle(width, height);
                }
                else
                {
                    double a = double.Parse(textBox1.Text.Replace('.', ','));
                    double b = double.Parse(textBox2.Text.Replace('.', ','));
                    double c = double.Parse(textBox3.Text.Replace('.', ','));
                    CreatedShape = new Triangle(a, b, c);
                }

                DialogResult = DialogResult.OK;

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                radioButton1.Checked = true;

                radioButton1_CheckedChanged(null, null);
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

        //TODO: RSDN
        /// <summary>
        /// Обрабатывает нажатие кнопки "Случайная фигура". Генерирует и отображает случайную фигуру.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void btnRandom_Click(object sender, EventArgs e)
        {
            ShapeBase randomShape = ShapeGenerator.GetRandomShape();

            switch (randomShape)
            {
                //TODO: {}
                case Circle circle:
                    //TODO: RSDN
                    radioButton1.Checked = true;
                    textBox1.Text = circle.Radius.ToString();
                    break;
                case Model.Rectangle rect:
                    radioButton2.Checked = true;
                    textBox1.Text = rect.Width.ToString();
                    textBox2.Text = rect.Height.ToString();
                    break;
                case Triangle triangle:
                    radioButton3.Checked = true;
                    textBox1.Text = triangle.SideA.ToString();
                    textBox2.Text = triangle.SideB.ToString();
                    textBox3.Text = triangle.SideC.ToString();
                    break;
            }
        }

        /// <summary>
        /// Обрабатывает изменение выбора радио-кнопки для круга. Настраивает интерфейс для ввода радиуса.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
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
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
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
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
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