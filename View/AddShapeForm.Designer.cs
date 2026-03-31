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
            groupBox1 = new GroupBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            btnRandom = new Button();
            btnOk = new Button();
            btnCancel = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(260, 100);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Тип фигуры";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(6, 19);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(50, 19);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Круг";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(6, 42);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(114, 19);
            radioButton2.TabIndex = 1;
            radioButton2.Text = "Прямоугольник";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(6, 65);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(96, 19);
            radioButton3.TabIndex = 2;
            radioButton3.Text = "Треугольник";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 125);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 1;
            label1.Text = "Радиус:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 155);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 2;
            label2.Text = "Высота:";
            label2.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 185);
            label3.Name = "label3";
            label3.Size = new Size(68, 15);
            label3.TabIndex = 3;
            label3.Text = "Сторона C:";
            label3.Visible = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(80, 122);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(192, 23);
            textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(80, 152);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(192, 23);
            textBox2.TabIndex = 5;
            textBox2.Visible = false;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(80, 182);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(192, 23);
            textBox3.TabIndex = 6;
            textBox3.Visible = false;
            // 
            // btnRandom
            // 
            btnRandom.Location = new Point(197, 211);
            btnRandom.Name = "btnRandom";
            btnRandom.Size = new Size(75, 23);
            btnRandom.TabIndex = 7;
            btnRandom.Text = "Случайно";
            btnRandom.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(12, 211);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 8;
            btnOk.Text = "Ок";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(93, 211);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Отмэна";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // AddShapeForm
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(284, 281);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(btnRandom);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddShapeForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Добавление фигуры";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button btnRandom;
        private Button btnOk;
        private Button btnCancel;
    }
}