namespace View
{
    partial class SearchForm
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
            _textBoxSearch = new TextBox();
            _buttonSearch = new Button();
            _dataGridViewResult = new DataGridView();
            _labelCount = new Label();
            columnType = new DataGridViewTextBoxColumn();
            columnInfo = new DataGridViewTextBoxColumn();
            columnArea = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)_dataGridViewResult).BeginInit();
            SuspendLayout();
            // 
            // _textBoxSearch
            // 
            _textBoxSearch.Location = new Point(12, 10);
            _textBoxSearch.Name = "_textBoxSearch";
            _textBoxSearch.Size = new Size(379, 23);
            _textBoxSearch.TabIndex = 0;
            // 
            // _buttonSearch
            // 
            _buttonSearch.Location = new Point(397, 10);
            _buttonSearch.Name = "_buttonSearch";
            _buttonSearch.Size = new Size(75, 23);
            _buttonSearch.TabIndex = 1;
            _buttonSearch.Text = "Найти";
            _buttonSearch.UseVisualStyleBackColor = true;
            _buttonSearch.Click += ButtonSearchClick;
            // 
            // _dataGridViewResult
            // 
            _dataGridViewResult.AllowUserToAddRows = false;
            _dataGridViewResult.AllowUserToDeleteRows = false;
            _dataGridViewResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dataGridViewResult.Columns.AddRange(new DataGridViewColumn[] { columnType, columnInfo, columnArea });
            _dataGridViewResult.Location = new Point(12, 39);
            _dataGridViewResult.Name = "_dataGridViewResult";
            _dataGridViewResult.ReadOnly = true;
            _dataGridViewResult.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dataGridViewResult.Size = new Size(460, 275);
            _dataGridViewResult.TabIndex = 2;
            // 
            // _labelCount
            // 
            _labelCount.AutoSize = true;
            _labelCount.Location = new Point(12, 317);
            _labelCount.Name = "_labelCount";
            _labelCount.Size = new Size(104, 15);
            _labelCount.TabIndex = 3;
            _labelCount.Text = "Найдено фигур: 0";
            // 
            // columnType
            // 
            columnType.HeaderText = "Тип";
            columnType.Name = "columnType";
            columnType.ReadOnly = true;
            // 
            // columnInfo
            // 
            columnInfo.HeaderText = "Информация\t";
            columnInfo.Name = "columnInfo";
            columnInfo.ReadOnly = true;
            columnInfo.Width = 235;
            // 
            // columnArea
            // 
            columnArea.HeaderText = "Площадь";
            columnArea.Name = "columnArea";
            columnArea.ReadOnly = true;
            columnArea.Width = 80;
            // 
            // SearchForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 341);
            Controls.Add(_labelCount);
            Controls.Add(_dataGridViewResult);
            Controls.Add(_buttonSearch);
            Controls.Add(_textBoxSearch);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SearchForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Поиск фигур";
            ((System.ComponentModel.ISupportInitialize)_dataGridViewResult).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox _textBoxSearch;
        private Button _buttonSearch;
        private DataGridView _dataGridViewResult;
        private Label _labelCount;
        private DataGridViewTextBoxColumn columnType;
        private DataGridViewTextBoxColumn columnInfo;
        private DataGridViewTextBoxColumn columnArea;
    }
}