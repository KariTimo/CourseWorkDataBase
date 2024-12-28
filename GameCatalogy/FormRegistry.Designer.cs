namespace GameCatalogy
{
    partial class FormRegistry
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tbVirtName = new TextBox();
            tbRealName = new TextBox();
            tbLocation = new TextBox();
            btnConfirm = new Button();
            tbPassword = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bookman Old Style", 12F);
            label1.Location = new Point(14, 17);
            label1.Name = "label1";
            label1.Size = new Size(103, 23);
            label1.TabIndex = 0;
            label1.Text = "Никнейм";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bookman Old Style", 12F);
            label2.Location = new Point(12, 86);
            label2.Name = "label2";
            label2.Size = new Size(169, 23);
            label2.TabIndex = 1;
            label2.Text = "Настоящее имя";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Bookman Old Style", 12F);
            label3.Location = new Point(14, 155);
            label3.Name = "label3";
            label3.Size = new Size(182, 23);
            label3.TabIndex = 2;
            label3.Text = "Местоположение";
            // 
            // tbVirtName
            // 
            tbVirtName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tbVirtName.Location = new Point(14, 44);
            tbVirtName.Margin = new Padding(3, 4, 3, 4);
            tbVirtName.Multiline = true;
            tbVirtName.Name = "tbVirtName";
            tbVirtName.Size = new Size(190, 33);
            tbVirtName.TabIndex = 3;
            // 
            // tbRealName
            // 
            tbRealName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tbRealName.Location = new Point(15, 113);
            tbRealName.Margin = new Padding(3, 4, 3, 4);
            tbRealName.Multiline = true;
            tbRealName.Name = "tbRealName";
            tbRealName.Size = new Size(190, 33);
            tbRealName.TabIndex = 4;
            // 
            // tbLocation
            // 
            tbLocation.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tbLocation.Location = new Point(14, 182);
            tbLocation.Margin = new Padding(3, 4, 3, 4);
            tbLocation.Multiline = true;
            tbLocation.Name = "tbLocation";
            tbLocation.Size = new Size(190, 33);
            tbLocation.TabIndex = 5;
            // 
            // btnConfirm
            // 
            btnConfirm.Cursor = Cursors.Hand;
            btnConfirm.FlatStyle = FlatStyle.Popup;
            btnConfirm.Font = new Font("Bookman Old Style", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnConfirm.Location = new Point(11, 306);
            btnConfirm.Margin = new Padding(3, 4, 3, 4);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(191, 35);
            btnConfirm.TabIndex = 9;
            btnConfirm.Text = "Подтвердить";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            btnConfirm.MouseEnter += btnConfirm_MouseEnter;
            btnConfirm.MouseLeave += btnConfirm_MouseLeave;
            // 
            // tbPassword
            // 
            tbPassword.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tbPassword.Location = new Point(12, 251);
            tbPassword.Margin = new Padding(3, 4, 3, 4);
            tbPassword.Multiline = true;
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(190, 33);
            tbPassword.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Bookman Old Style", 12F);
            label5.Location = new Point(11, 224);
            label5.Name = "label5";
            label5.Size = new Size(82, 23);
            label5.TabIndex = 10;
            label5.Text = "Пароль";
            // 
            // FormRegistry
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 255);
            ClientSize = new Size(215, 351);
            Controls.Add(tbPassword);
            Controls.Add(label5);
            Controls.Add(btnConfirm);
            Controls.Add(tbLocation);
            Controls.Add(tbRealName);
            Controls.Add(tbVirtName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormRegistry";
            Text = "Registry";
            FormClosing += FormRegistry_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tbVirtName;
        private TextBox tbRealName;
        private TextBox tbLocation;
        private Button btnConfirm;
        private TextBox tbPassword;
        private Label label5;
    }
}