namespace View
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            dataGridViewShapes = new DataGridView();
            colType = new DataGridViewTextBoxColumn();
            colInfo = new DataGridViewTextBoxColumn();
            colArea = new DataGridViewTextBoxColumn();
            btnAdd = new Button();
            btnRemove = new Button();
            btnSearch = new Button();
            btnSave = new Button();
            btnLoad = new Button();
            labelCount = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewShapes).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridViewShapes);
            groupBox1.Location = new Point(12, 8);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(560, 300);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Список фигур";
            // 
            // dataGridViewShapes
            // 
            dataGridViewShapes.AllowUserToAddRows = false;
            dataGridViewShapes.AllowUserToDeleteRows = false;
            dataGridViewShapes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewShapes.Columns.AddRange(new DataGridViewColumn[] { colType, colInfo, colArea });
            dataGridViewShapes.Dock = DockStyle.Fill;
            dataGridViewShapes.Location = new Point(3, 19);
            dataGridViewShapes.Name = "dataGridViewShapes";
            dataGridViewShapes.ReadOnly = true;
            dataGridViewShapes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewShapes.Size = new Size(554, 278);
            dataGridViewShapes.TabIndex = 0;
            // 
            // colType
            // 
            colType.HeaderText = "Тип";
            colType.Name = "colType";
            colType.ReadOnly = true;
            // 
            // colInfo
            // 
            colInfo.HeaderText = "Информация";
            colInfo.Name = "colInfo";
            colInfo.ReadOnly = true;
            colInfo.Width = 350;
            // 
            // colArea
            // 
            colArea.HeaderText = "Площадь";
            colArea.Name = "colArea";
            colArea.ReadOnly = true;
            colArea.Width = 80;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(413, 329);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(494, 329);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(75, 23);
            btnRemove.TabIndex = 2;
            btnRemove.Text = "Удалить";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(413, 358);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Поиск";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(15, 329);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 4;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(96, 329);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(75, 23);
            btnLoad.TabIndex = 5;
            btnLoad.Text = "Загрузить";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // labelCount
            // 
            labelCount.AutoSize = true;
            labelCount.Location = new Point(482, 311);
            labelCount.Name = "labelCount";
            labelCount.Size = new Size(87, 15);
            labelCount.TabIndex = 6;
            labelCount.Text = "Всего фигур: 0";
            labelCount.Click += labelCount_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 411);
            Controls.Add(labelCount);
            Controls.Add(btnLoad);
            Controls.Add(btnSave);
            Controls.Add(btnSearch);
            Controls.Add(btnRemove);
            Controls.Add(btnAdd);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Геометрические фигуры";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewShapes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dataGridViewShapes;
        private Button btnAdd;
        private Button btnRemove;
        private Button btnSearch;
        private Button btnSave;
        private Button btnLoad;
        private Label labelCount;
        private DataGridViewTextBoxColumn colType;
        private DataGridViewTextBoxColumn colInfo;
        private DataGridViewTextBoxColumn colArea;
    }
}
