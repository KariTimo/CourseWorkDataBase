namespace GameCatalogy
{
    partial class OwnLibrary
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
            dgvGameLibrary = new DataGridView();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            dgvReviews = new DataGridView();
            label2 = new Label();
            ofdAvatar = new OpenFileDialog();
            cbAllReview = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvGameLibrary).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvReviews).BeginInit();
            SuspendLayout();
            // 
            // dgvGameLibrary
            // 
            dgvGameLibrary.AllowUserToAddRows = false;
            dgvGameLibrary.AllowUserToDeleteRows = false;
            dgvGameLibrary.AllowUserToResizeColumns = false;
            dgvGameLibrary.AllowUserToResizeRows = false;
            dgvGameLibrary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvGameLibrary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGameLibrary.Location = new Point(12, 13);
            dgvGameLibrary.Margin = new Padding(3, 4, 3, 4);
            dgvGameLibrary.MultiSelect = false;
            dgvGameLibrary.Name = "dgvGameLibrary";
            dgvGameLibrary.RowHeadersVisible = false;
            dgvGameLibrary.RowHeadersWidth = 51;
            dgvGameLibrary.Size = new Size(464, 422);
            dgvGameLibrary.TabIndex = 4;
            dgvGameLibrary.ColumnHeaderMouseClick += dgvGameLibrary_ColumnHeaderMouseClick;
            dgvGameLibrary.SelectionChanged += dgvGameLibrary_SelectionChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Location = new Point(489, 52);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(201, 235);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Bookman Old Style", 9F);
            button1.Location = new Point(485, 317);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(205, 31);
            button1.TabIndex = 7;
            button1.Text = "Добавить отзыв";
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
            button2.Location = new Point(485, 356);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(205, 31);
            button2.TabIndex = 8;
            button2.Text = "Редактировать  отзыв";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            button2.MouseEnter += button2_MouseEnter;
            button2.MouseLeave += button2_MouseLeave;
            // 
            // button3
            // 
            button3.Cursor = Cursors.Hand;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Bookman Old Style", 9F);
            button3.Location = new Point(485, 395);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(205, 31);
            button3.TabIndex = 9;
            button3.Text = "Удалить отзыв";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            button3.MouseEnter += button3_MouseEnter;
            button3.MouseLeave += button3_MouseLeave;
            // 
            // button4
            // 
            button4.Cursor = Cursors.Hand;
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Bookman Old Style", 9F);
            button4.Location = new Point(488, 13);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(201, 31);
            button4.TabIndex = 10;
            button4.Text = "Изменить аватар";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            button4.MouseEnter += button4_MouseEnter;
            button4.MouseLeave += button4_MouseLeave;
            // 
            // dgvReviews
            // 
            dgvReviews.AllowUserToAddRows = false;
            dgvReviews.AllowUserToDeleteRows = false;
            dgvReviews.AllowUserToResizeColumns = false;
            dgvReviews.AllowUserToResizeRows = false;
            dgvReviews.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvReviews.BackgroundColor = Color.FromArgb(192, 192, 255);
            dgvReviews.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReviews.Location = new Point(12, 482);
            dgvReviews.Margin = new Padding(3, 4, 3, 4);
            dgvReviews.Name = "dgvReviews";
            dgvReviews.RowHeadersVisible = false;
            dgvReviews.RowHeadersWidth = 51;
            dgvReviews.Size = new Size(675, 199);
            dgvReviews.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bookman Old Style", 9F);
            label2.Location = new Point(12, 455);
            label2.Name = "label2";
            label2.Size = new Size(53, 19);
            label2.TabIndex = 12;
            label2.Text = "отзыв";
            // 
            // cbAllReview
            // 
            cbAllReview.AutoSize = true;
            cbAllReview.FlatStyle = FlatStyle.System;
            cbAllReview.Font = new Font("Bookman Old Style", 9F);
            cbAllReview.Location = new Point(562, 450);
            cbAllReview.Margin = new Padding(3, 4, 3, 4);
            cbAllReview.Name = "cbAllReview";
            cbAllReview.Size = new Size(129, 24);
            cbAllReview.TabIndex = 13;
            cbAllReview.Text = "Все отзывы";
            cbAllReview.UseVisualStyleBackColor = true;
            cbAllReview.CheckedChanged += cbAllReview_CheckedChanged;
            // 
            // OwnLibrary
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 255);
            ClientSize = new Size(703, 690);
            Controls.Add(cbAllReview);
            Controls.Add(label2);
            Controls.Add(dgvReviews);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(dgvGameLibrary);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "OwnLibrary";
            Text = "Библиотека";
            FormClosing += OwnLibrary_FormClosing;
            Load += OwnLibrary_Load;
            ((System.ComponentModel.ISupportInitialize)dgvGameLibrary).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvReviews).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvGameLibrary;
        private PictureBox pictureBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private DataGridView dgvReviews;
        private Label label2;
        private OpenFileDialog ofdAvatar;
        private CheckBox cbAllReview;
    }
}