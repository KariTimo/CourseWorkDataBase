namespace GameCatalogy
{
    partial class UserForm
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
            button1 = new Button();
            button2 = new Button();
            dgvGame = new DataGridView();
            groupBox1 = new GroupBox();
            tbMemory = new TextBox();
            label8 = new Label();
            tbVideo = new TextBox();
            label7 = new Label();
            tbRAM = new TextBox();
            label6 = new Label();
            tbCPU = new TextBox();
            label5 = new Label();
            tbOS = new TextBox();
            label2 = new Label();
            groupBox2 = new GroupBox();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            label3 = new Label();
            checkBox1 = new CheckBox();
            groupBox3 = new GroupBox();
            tbBalance = new MaskedTextBox();
            button3 = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvGame).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Bookman Old Style", 9F);
            button1.Location = new Point(7, 231);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(121, 34);
            button1.TabIndex = 1;
            button1.Text = "Купить игру";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            button1.MouseEnter += button1_MouseEnter;
            button1.MouseLeave += button1_MouseLeave;
            // 
            // button2
            // 
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Bookman Old Style", 9F);
            button2.Location = new Point(6, 85);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(244, 34);
            button2.TabIndex = 2;
            button2.Text = "моя библиотека";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            button2.MouseEnter += button2_MouseEnter;
            button2.MouseLeave += button2_MouseLeave;
            // 
            // dgvGame
            // 
            dgvGame.AllowUserToAddRows = false;
            dgvGame.AllowUserToDeleteRows = false;
            dgvGame.AllowUserToResizeColumns = false;
            dgvGame.AllowUserToResizeRows = false;
            dgvGame.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvGame.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvGame.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGame.Location = new Point(16, 12);
            dgvGame.Margin = new Padding(3, 4, 3, 4);
            dgvGame.Name = "dgvGame";
            dgvGame.ReadOnly = true;
            dgvGame.RowHeadersVisible = false;
            dgvGame.RowHeadersWidth = 51;
            dgvGame.Size = new Size(604, 273);
            dgvGame.TabIndex = 3;
            dgvGame.SelectionChanged += dgvGame_SelectionChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tbMemory);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(tbVideo);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(tbRAM);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(tbCPU);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(tbOS);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Bookman Old Style", 9F);
            groupBox1.Location = new Point(627, 12);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(360, 273);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Системные требования";
            // 
            // tbMemory
            // 
            tbMemory.BorderStyle = BorderStyle.FixedSingle;
            tbMemory.Font = new Font("Bookman Old Style", 9F);
            tbMemory.Location = new Point(111, 162);
            tbMemory.Margin = new Padding(3, 4, 3, 4);
            tbMemory.Name = "tbMemory";
            tbMemory.ReadOnly = true;
            tbMemory.Size = new Size(243, 25);
            tbMemory.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Bookman Old Style", 9F);
            label8.Location = new Point(39, 169);
            label8.Name = "label8";
            label8.Size = new Size(66, 19);
            label8.TabIndex = 8;
            label8.Text = "Память";
            // 
            // tbVideo
            // 
            tbVideo.BorderStyle = BorderStyle.FixedSingle;
            tbVideo.Font = new Font("Bookman Old Style", 9F);
            tbVideo.Location = new Point(111, 125);
            tbVideo.Margin = new Padding(3, 4, 3, 4);
            tbVideo.Name = "tbVideo";
            tbVideo.ReadOnly = true;
            tbVideo.Size = new Size(243, 25);
            tbVideo.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Bookman Old Style", 9F);
            label7.Location = new Point(7, 128);
            label7.Name = "label7";
            label7.Size = new Size(99, 19);
            label7.TabIndex = 6;
            label7.Text = "Видеокарта";
            // 
            // tbRAM
            // 
            tbRAM.BorderStyle = BorderStyle.FixedSingle;
            tbRAM.Font = new Font("Bookman Old Style", 9F);
            tbRAM.Location = new Point(111, 92);
            tbRAM.Margin = new Padding(3, 4, 3, 4);
            tbRAM.Name = "tbRAM";
            tbRAM.ReadOnly = true;
            tbRAM.Size = new Size(243, 25);
            tbRAM.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Bookman Old Style", 9F);
            label6.Location = new Point(62, 96);
            label6.Name = "label6";
            label6.Size = new Size(41, 19);
            label6.TabIndex = 4;
            label6.Text = "ОЗУ";
            // 
            // tbCPU
            // 
            tbCPU.BorderStyle = BorderStyle.FixedSingle;
            tbCPU.Font = new Font("Bookman Old Style", 9F);
            tbCPU.Location = new Point(111, 58);
            tbCPU.Margin = new Padding(3, 4, 3, 4);
            tbCPU.Name = "tbCPU";
            tbCPU.ReadOnly = true;
            tbCPU.Size = new Size(243, 25);
            tbCPU.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Bookman Old Style", 9F);
            label5.Location = new Point(69, 61);
            label5.Name = "label5";
            label5.Size = new Size(33, 19);
            label5.TabIndex = 2;
            label5.Text = "ЦП";
            // 
            // tbOS
            // 
            tbOS.BorderStyle = BorderStyle.FixedSingle;
            tbOS.Font = new Font("Bookman Old Style", 9F);
            tbOS.Location = new Point(111, 22);
            tbOS.Margin = new Padding(3, 4, 3, 4);
            tbOS.Name = "tbOS";
            tbOS.ReadOnly = true;
            tbOS.Size = new Size(243, 25);
            tbOS.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bookman Old Style", 9F);
            label2.Location = new Point(71, 24);
            label2.Name = "label2";
            label2.Size = new Size(32, 19);
            label2.TabIndex = 0;
            label2.Text = "ОС";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBox2);
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(checkBox1);
            groupBox2.Font = new Font("Bookman Old Style", 9F);
            groupBox2.Location = new Point(17, 293);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(336, 138);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Сортировка";
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FlatStyle = FlatStyle.Flat;
            comboBox2.Font = new Font("Bookman Old Style", 9F);
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(165, 92);
            comboBox2.Margin = new Padding(3, 4, 3, 4);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(155, 27);
            comboBox2.TabIndex = 4;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.Font = new Font("Bookman Old Style", 9F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Жанр", "Автор", " " });
            comboBox1.Location = new Point(165, 57);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(155, 27);
            comboBox1.TabIndex = 3;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Bookman Old Style", 9F);
            label3.Location = new Point(6, 57);
            label3.Name = "label3";
            label3.Size = new Size(161, 19);
            label3.TabIndex = 2;
            label3.Text = "Показать только по:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.FlatStyle = FlatStyle.System;
            checkBox1.Font = new Font("Bookman Old Style", 9F);
            checkBox1.Location = new Point(6, 26);
            checkBox1.Margin = new Padding(3, 4, 3, 4);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(218, 24);
            checkBox1.TabIndex = 1;
            checkBox1.Text = "Отсортировать по цене";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(tbBalance);
            groupBox3.Controls.Add(button3);
            groupBox3.Controls.Add(button2);
            groupBox3.Font = new Font("Bookman Old Style", 9F);
            groupBox3.Location = new Point(359, 293);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(261, 138);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            // 
            // tbBalance
            // 
            tbBalance.Font = new Font("Bookman Old Style", 9F);
            tbBalance.Location = new Point(168, 29);
            tbBalance.Margin = new Padding(3, 4, 3, 4);
            tbBalance.Mask = "00000";
            tbBalance.Name = "tbBalance";
            tbBalance.Size = new Size(82, 25);
            tbBalance.TabIndex = 5;
            tbBalance.ValidatingType = typeof(int);
            // 
            // button3
            // 
            button3.Cursor = Cursors.Hand;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Bookman Old Style", 9F);
            button3.Location = new Point(6, 26);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(156, 30);
            button3.TabIndex = 3;
            button3.Text = "Пополнить баланс";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            button3.MouseEnter += button3_MouseEnter;
            button3.MouseLeave += button3_MouseLeave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(627, 293);
            label1.Name = "label1";
            label1.Size = new Size(54, 19);
            label1.TabIndex = 10;
            label1.Text = "label1";
            label1.Visible = false;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 255);
            ClientSize = new Size(999, 447);
            Controls.Add(label1);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(dgvGame);
            Font = new Font("Bookman Old Style", 9F);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "UserForm";
            FormClosing += UserForm_FormClosing;
            Load += UserForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvGame).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Button button2;
        private DataGridView dgvGame;
        private GroupBox groupBox1;
        private TextBox tbOS;
        private Label label2;
        private GroupBox groupBox2;
        private CheckBox checkBox1;
        private Label label3;
        private ComboBox comboBox1;
        private GroupBox groupBox3;
        private ComboBox comboBox2;
        private TextBox tbMemory;
        private Label label8;
        private TextBox tbVideo;
        private Label label7;
        private TextBox tbRAM;
        private Label label6;
        private TextBox tbCPU;
        private Label label5;
        private Button button3;
        private MaskedTextBox tbBalance;
        private Label label1;
    }
}
