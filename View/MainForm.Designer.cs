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
            _groupBoxShapes = new GroupBox();
            _dataGridViewShapes = new DataGridView();
            columnType = new DataGridViewTextBoxColumn();
            columnInfo = new DataGridViewTextBoxColumn();
            columnArea = new DataGridViewTextBoxColumn();
            _buttonAdd = new Button();
            _buttonRemove = new Button();
            _buttonSearch = new Button();
            _buttonSave = new Button();
            _buttonLoad = new Button();
            _labelCount = new Label();
            _groupBoxShapes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dataGridViewShapes).BeginInit();
            SuspendLayout();
            // 
            // _groupBoxShapes
            // 
            _groupBoxShapes.Controls.Add(_dataGridViewShapes);
            _groupBoxShapes.Location = new Point(12, 8);
            _groupBoxShapes.Name = "_groupBoxShapes";
            _groupBoxShapes.Size = new Size(560, 300);
            _groupBoxShapes.TabIndex = 0;
            _groupBoxShapes.TabStop = false;
            _groupBoxShapes.Text = "Список фигур";
            // 
            // _dataGridViewShapes
            // 
            _dataGridViewShapes.AllowUserToAddRows = false;
            _dataGridViewShapes.AllowUserToDeleteRows = false;
            _dataGridViewShapes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dataGridViewShapes.Columns.AddRange(new DataGridViewColumn[] { columnType, columnInfo, columnArea });
            _dataGridViewShapes.Dock = DockStyle.Fill;
            _dataGridViewShapes.Location = new Point(3, 19);
            _dataGridViewShapes.Name = "_dataGridViewShapes";
            _dataGridViewShapes.ReadOnly = true;
            _dataGridViewShapes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dataGridViewShapes.Size = new Size(554, 278);
            _dataGridViewShapes.TabIndex = 0;
            // 
            // columnType
            // 
            columnType.HeaderText = "Тип";
            columnType.Name = "columnType";
            columnType.ReadOnly = true;
            // 
            // columnInfo
            // 
            columnInfo.HeaderText = "Информация";
            columnInfo.Name = "columnInfo";
            columnInfo.ReadOnly = true;
            columnInfo.Width = 330;
            // 
            // columnArea
            // 
            columnArea.HeaderText = "Площадь";
            columnArea.Name = "columnArea";
            columnArea.ReadOnly = true;
            columnArea.Width = 80;
            // 
            // _buttonAdd
            // 
            _buttonAdd.Location = new Point(15, 351);
            _buttonAdd.Name = "_buttonAdd";
            _buttonAdd.Size = new Size(75, 23);
            _buttonAdd.TabIndex = 1;
            _buttonAdd.Text = "Добавить";
            _buttonAdd.UseVisualStyleBackColor = true;
            _buttonAdd.Click += ButtonAddClick;
            // 
            // _buttonRemove
            // 
            _buttonRemove.Location = new Point(15, 375);
            _buttonRemove.Name = "_buttonRemove";
            _buttonRemove.Size = new Size(75, 23);
            _buttonRemove.TabIndex = 2;
            _buttonRemove.Text = "Удалить";
            _buttonRemove.UseVisualStyleBackColor = true;
            _buttonRemove.Click += ButtonRemoveClick;
            // 
            // _buttonSearch
            // 
            _buttonSearch.Location = new Point(15, 314);
            _buttonSearch.Name = "_buttonSearch";
            _buttonSearch.Size = new Size(75, 23);
            _buttonSearch.TabIndex = 3;
            _buttonSearch.Text = "Поиск";
            _buttonSearch.UseVisualStyleBackColor = true;
            _buttonSearch.Click += ButtonSearchClick;
            // 
            // _buttonSave
            // 
            _buttonSave.Location = new Point(413, 314);
            _buttonSave.Name = "_buttonSave";
            _buttonSave.Size = new Size(75, 23);
            _buttonSave.TabIndex = 4;
            _buttonSave.Text = "Сохранить";
            _buttonSave.UseVisualStyleBackColor = true;
            _buttonSave.Click += ButtonSaveClick;
            // 
            // _buttonLoad
            // 
            _buttonLoad.Location = new Point(494, 314);
            _buttonLoad.Name = "_buttonLoad";
            _buttonLoad.Size = new Size(75, 23);
            _buttonLoad.TabIndex = 5;
            _buttonLoad.Text = "Загрузить";
            _buttonLoad.UseVisualStyleBackColor = true;
            _buttonLoad.Click += ButtonLoadClick;
            // 
            // _labelCount
            // 
            _labelCount.AutoSize = true;
            _labelCount.Location = new Point(96, 318);
            _labelCount.Name = "_labelCount";
            _labelCount.Size = new Size(87, 15);
            _labelCount.TabIndex = 6;
            _labelCount.Text = "Всего фигур: 0";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 411);
            Controls.Add(_labelCount);
            Controls.Add(_buttonLoad);
            Controls.Add(_buttonSave);
            Controls.Add(_buttonSearch);
            Controls.Add(_buttonRemove);
            Controls.Add(_buttonAdd);
            Controls.Add(_groupBoxShapes);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Геометрические фигуры";
            _groupBoxShapes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dataGridViewShapes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox _groupBoxShapes;
        private DataGridView _dataGridViewShapes;
        private Button _buttonAdd;
        private Button _buttonRemove;
        private Button _buttonSearch;
        private Button _buttonSave;
        private Button _buttonLoad;
        private Label _labelCount;
        private DataGridViewTextBoxColumn columnType;
        private DataGridViewTextBoxColumn columnInfo;
        private DataGridViewTextBoxColumn columnArea;
    }
}
