namespace GameCatalogy
{
    partial class AdminForm
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
            dgvTable = new DataGridView();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            cbTables = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvTable).BeginInit();
            SuspendLayout();
            // 
            // dgvTable
            // 
            dgvTable.AllowUserToAddRows = false;
            dgvTable.AllowUserToDeleteRows = false;
            dgvTable.AllowUserToResizeColumns = false;
            dgvTable.AllowUserToResizeRows = false;
            dgvTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTable.Location = new Point(14, 16);
            dgvTable.Margin = new Padding(3, 4, 3, 4);
            dgvTable.Name = "dgvTable";
            dgvTable.ReadOnly = true;
            dgvTable.RowHeadersWidth = 51;
            dgvTable.Size = new Size(887, 492);
            dgvTable.TabIndex = 0;
            dgvTable.SelectionChanged += dgvTable_SelectionChanged;
            // 
            // btnInsert
            // 
            btnInsert.Enabled = false;
            btnInsert.FlatStyle = FlatStyle.Popup;
            btnInsert.Font = new Font("Bookman Old Style", 9F);
            btnInsert.Location = new Point(15, 516);
            btnInsert.Margin = new Padding(3, 4, 3, 4);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(142, 39);
            btnInsert.TabIndex = 1;
            btnInsert.Text = "Добавить";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            btnInsert.MouseEnter += btnInsert_MouseEnter;
            btnInsert.MouseLeave += btnInsert_MouseLeave;
            // 
            // btnUpdate
            // 
            btnUpdate.Enabled = false;
            btnUpdate.FlatStyle = FlatStyle.Popup;
            btnUpdate.Font = new Font("Bookman Old Style", 9F);
            btnUpdate.Location = new Point(163, 516);
            btnUpdate.Margin = new Padding(3, 4, 3, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(142, 39);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Обновить";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            btnUpdate.MouseEnter += btnUpdate_MouseEnter;
            btnUpdate.MouseLeave += btnUpdate_MouseLeave;
            // 
            // btnDelete
            // 
            btnDelete.Enabled = false;
            btnDelete.FlatStyle = FlatStyle.Popup;
            btnDelete.Font = new Font("Bookman Old Style", 9F);
            btnDelete.Location = new Point(312, 516);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(142, 39);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            btnDelete.MouseEnter += btnDelete_MouseEnter;
            btnDelete.MouseLeave += btnDelete_MouseLeave;
            // 
            // cbTables
            // 
            cbTables.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTables.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cbTables.FormattingEnabled = true;
            cbTables.Items.AddRange(new object[] { "t_users", "t_games", "t_developer", "t_requirements", "t_genre_games", "t_game_reviews" });
            cbTables.Location = new Point(721, 515);
            cbTables.Margin = new Padding(3, 4, 3, 4);
            cbTables.Name = "cbTables";
            cbTables.Size = new Size(179, 40);
            cbTables.TabIndex = 4;
            cbTables.SelectedIndexChanged += cbTables_SelectedIndexChanged;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 255);
            ClientSize = new Size(914, 569);
            Controls.Add(cbTables);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnInsert);
            Controls.Add(dgvTable);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "AdminForm";
            Text = "Admin";
            FormClosing += AdminForm_FormClosing;
            Load += AdminForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTable).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnDelete;
        private ComboBox cbTables;
        public DataGridView dgvTable;
    }
}