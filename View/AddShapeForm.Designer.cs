namespace View
{
    partial class AddShapeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _groupBoxShapeType = new GroupBox();
            _radioButtonTriangle = new RadioButton();
            _radioButtonRectangle = new RadioButton();
            _radioButtonCircle = new RadioButton();
            _labelParameterOne = new Label();
            _labelParameterTwo = new Label();
            _labelParameterThree = new Label();
            _textBoxParameterOne = new TextBox();
            _textBoxParameterTwo = new TextBox();
            _textBoxParameterThree = new TextBox();
            _buttonRandom = new Button();
            _buttonOk = new Button();
            _buttonCancel = new Button();
            _groupBoxShapeType.SuspendLayout();
            SuspendLayout();
            // 
            // _groupBoxShapeType
            // 
            _groupBoxShapeType.Controls.Add(_radioButtonTriangle);
            _groupBoxShapeType.Controls.Add(_radioButtonRectangle);
            _groupBoxShapeType.Controls.Add(_radioButtonCircle);
            _groupBoxShapeType.Location = new Point(12, 12);
            _groupBoxShapeType.Name = "_groupBoxShapeType";
            _groupBoxShapeType.Size = new Size(260, 100);
            _groupBoxShapeType.TabIndex = 0;
            _groupBoxShapeType.TabStop = false;
            _groupBoxShapeType.Text = "Тип фигуры";
            // 
            // _radioButtonTriangle
            // 
            _radioButtonTriangle.AutoSize = true;
            _radioButtonTriangle.Location = new Point(6, 65);
            _radioButtonTriangle.Name = "_radioButtonTriangle";
            _radioButtonTriangle.Size = new Size(96, 19);
            _radioButtonTriangle.TabIndex = 2;
            _radioButtonTriangle.Text = "Треугольник";
            _radioButtonTriangle.UseVisualStyleBackColor = true;
            _radioButtonTriangle.CheckedChanged += RadioButtonTriangleCheckedChanged;
            // 
            // _radioButtonRectangle
            // 
            _radioButtonRectangle.AutoSize = true;
            _radioButtonRectangle.Location = new Point(6, 42);
            _radioButtonRectangle.Name = "_radioButtonRectangle";
            _radioButtonRectangle.Size = new Size(114, 19);
            _radioButtonRectangle.TabIndex = 1;
            _radioButtonRectangle.Text = "Прямоугольник";
            _radioButtonRectangle.UseVisualStyleBackColor = true;
            _radioButtonRectangle.CheckedChanged += RadioButtonRectangleCheckedChanged;
            // 
            // _radioButtonCircle
            // 
            _radioButtonCircle.AutoSize = true;
            _radioButtonCircle.Checked = true;
            _radioButtonCircle.Location = new Point(6, 19);
            _radioButtonCircle.Name = "_radioButtonCircle";
            _radioButtonCircle.Size = new Size(50, 19);
            _radioButtonCircle.TabIndex = 0;
            _radioButtonCircle.TabStop = true;
            _radioButtonCircle.Text = "Круг";
            _radioButtonCircle.UseVisualStyleBackColor = true;
            _radioButtonCircle.CheckedChanged += RadioButtonCircleCheckedChanged;
            // 
            // _labelParameterOne
            // 
            _labelParameterOne.AutoSize = true;
            _labelParameterOne.Location = new Point(12, 125);
            _labelParameterOne.Name = "_labelParameterOne";
            _labelParameterOne.Size = new Size(48, 15);
            _labelParameterOne.TabIndex = 1;
            _labelParameterOne.Text = "Радиус:";
            // 
            // _labelParameterTwo
            // 
            _labelParameterTwo.AutoSize = true;
            _labelParameterTwo.Location = new Point(12, 155);
            _labelParameterTwo.Name = "_labelParameterTwo";
            _labelParameterTwo.Size = new Size(50, 15);
            _labelParameterTwo.TabIndex = 2;
            _labelParameterTwo.Text = "Высота:";
            _labelParameterTwo.Visible = false;
            // 
            // _labelParameterThree
            // 
            _labelParameterThree.AutoSize = true;
            _labelParameterThree.Location = new Point(12, 185);
            _labelParameterThree.Name = "_labelParameterThree";
            _labelParameterThree.Size = new Size(68, 15);
            _labelParameterThree.TabIndex = 3;
            _labelParameterThree.Text = "Сторона C:";
            _labelParameterThree.Visible = false;
            // 
            // _textBoxParameterOne
            // 
            _textBoxParameterOne.Location = new Point(80, 122);
            _textBoxParameterOne.Name = "_textBoxParameterOne";
            _textBoxParameterOne.Size = new Size(192, 23);
            _textBoxParameterOne.TabIndex = 4;
            // 
            // _textBoxParameterTwo
            // 
            _textBoxParameterTwo.Location = new Point(80, 152);
            _textBoxParameterTwo.Name = "_textBoxParameterTwo";
            _textBoxParameterTwo.Size = new Size(192, 23);
            _textBoxParameterTwo.TabIndex = 5;
            _textBoxParameterTwo.Visible = false;
            // 
            // _textBoxParameterThree
            // 
            _textBoxParameterThree.Location = new Point(80, 182);
            _textBoxParameterThree.Name = "_textBoxParameterThree";
            _textBoxParameterThree.Size = new Size(192, 23);
            _textBoxParameterThree.TabIndex = 6;
            _textBoxParameterThree.Visible = false;
            // 
            // _buttonRandom
            // 
            _buttonRandom.Location = new Point(197, 211);
            _buttonRandom.Name = "_buttonRandom";
            _buttonRandom.Size = new Size(75, 23);
            _buttonRandom.TabIndex = 7;
            _buttonRandom.Text = "Случайно";
            _buttonRandom.UseVisualStyleBackColor = true;
            _buttonRandom.Click += ButtonRandomClick;
            // 
            // _buttonOk
            // 
            _buttonOk.Location = new Point(12, 211);
            _buttonOk.Name = "_buttonOk";
            _buttonOk.Size = new Size(75, 23);
            _buttonOk.TabIndex = 8;
            _buttonOk.Text = "Ок";
            _buttonOk.UseVisualStyleBackColor = true;
            _buttonOk.Click += ButtonOkClick;
            // 
            // _buttonCancel
            // 
            _buttonCancel.DialogResult = DialogResult.Cancel;
            _buttonCancel.Location = new Point(93, 211);
            _buttonCancel.Name = "_buttonCancel";
            _buttonCancel.Size = new Size(75, 23);
            _buttonCancel.TabIndex = 9;
            _buttonCancel.Text = "Отмэна";
            _buttonCancel.UseVisualStyleBackColor = true;
            // 
            // AddShapeForm
            // 
            AcceptButton = _buttonOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = _buttonCancel;
            ClientSize = new Size(284, 281);
            Controls.Add(_buttonCancel);
            Controls.Add(_buttonOk);
            Controls.Add(_buttonRandom);
            Controls.Add(_textBoxParameterThree);
            Controls.Add(_textBoxParameterTwo);
            Controls.Add(_textBoxParameterOne);
            Controls.Add(_labelParameterThree);
            Controls.Add(_labelParameterTwo);
            Controls.Add(_labelParameterOne);
            Controls.Add(_groupBoxShapeType);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddShapeForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Добавление фигуры";
            _groupBoxShapeType.ResumeLayout(false);
            _groupBoxShapeType.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox _groupBoxShapeType;
        private RadioButton _radioButtonTriangle;
        private RadioButton _radioButtonRectangle;
        private RadioButton _radioButtonCircle;
        private Label _labelParameterOne;
        private Label _labelParameterTwo;
        private Label _labelParameterThree;
        private TextBox _textBoxParameterOne;
        private TextBox _textBoxParameterTwo;
        private TextBox _textBoxParameterThree;
        private Button _buttonRandom;
        private Button _buttonOk;
        private Button _buttonCancel;
    }
}