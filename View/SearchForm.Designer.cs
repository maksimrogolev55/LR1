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
            txtSearch = new TextBox();
            btnSearch = new Button();
            dataGridViewResult = new DataGridView();
            colType = new DataGridViewTextBoxColumn();
            colInfo = new DataGridViewTextBoxColumn();
            colArea = new DataGridViewTextBoxColumn();
            lblCount = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResult).BeginInit();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(12, 10);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(379, 23);
            txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(397, 10);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Найти";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // dataGridViewResult
            // 
            dataGridViewResult.AllowUserToAddRows = false;
            dataGridViewResult.AllowUserToDeleteRows = false;
            dataGridViewResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResult.Columns.AddRange(new DataGridViewColumn[] { colType, colInfo, colArea });
            dataGridViewResult.Location = new Point(12, 39);
            dataGridViewResult.Name = "dataGridViewResult";
            dataGridViewResult.ReadOnly = true;
            dataGridViewResult.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewResult.Size = new Size(460, 275);
            dataGridViewResult.TabIndex = 2;
            dataGridViewResult.CellContentClick += dataGridViewResult_CellContentClick;
            // 
            // colType
            // 
            colType.HeaderText = "Тип";
            colType.Name = "colType";
            colType.ReadOnly = true;
            // 
            // colInfo
            // 
            colInfo.HeaderText = "Информация\t";
            colInfo.Name = "colInfo";
            colInfo.ReadOnly = true;
            colInfo.Width = 280;
            // 
            // colArea
            // 
            colArea.HeaderText = "Площадь";
            colArea.Name = "colArea";
            colArea.ReadOnly = true;
            colArea.Width = 80;
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Location = new Point(12, 317);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(104, 15);
            lblCount.TabIndex = 3;
            lblCount.Text = "Найдено фигур: 0";
            // 
            // SearchForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 341);
            Controls.Add(lblCount);
            Controls.Add(dataGridViewResult);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SearchForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Поиск фигур";
            ((System.ComponentModel.ISupportInitialize)dataGridViewResult).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dataGridViewResult;
        private DataGridViewTextBoxColumn colType;
        private DataGridViewTextBoxColumn colInfo;
        private DataGridViewTextBoxColumn colArea;
        private Label lblCount;
    }
}