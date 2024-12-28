namespace GameCatalogy
{
    partial class Autorization
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
            tbLogin = new TextBox();
            tbPassword = new TextBox();
            btnAutorization = new Button();
            btnRegistry = new Button();
            SuspendLayout();
            // 
            // tbLogin
            // 
            tbLogin.Font = new Font("Bookman Old Style", 12F, FontStyle.Bold);
            tbLogin.Location = new Point(12, 29);
            tbLogin.Margin = new Padding(3, 4, 3, 4);
            tbLogin.Name = "tbLogin";
            tbLogin.Size = new Size(252, 31);
            tbLogin.TabIndex = 0;
            // 
            // tbPassword
            // 
            tbPassword.Font = new Font("Bookman Old Style", 12F, FontStyle.Bold);
            tbPassword.Location = new Point(12, 72);
            tbPassword.Margin = new Padding(3, 4, 3, 4);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.Size = new Size(252, 31);
            tbPassword.TabIndex = 1;
            // 
            // btnAutorization
            // 
            btnAutorization.Cursor = Cursors.Hand;
            btnAutorization.FlatStyle = FlatStyle.Popup;
            btnAutorization.Font = new Font("Bookman Old Style", 9F);
            btnAutorization.Location = new Point(12, 128);
            btnAutorization.Margin = new Padding(3, 4, 3, 4);
            btnAutorization.Name = "btnAutorization";
            btnAutorization.Size = new Size(86, 32);
            btnAutorization.TabIndex = 2;
            btnAutorization.Text = "Вход";
            btnAutorization.UseVisualStyleBackColor = true;
            btnAutorization.Click += btnAutorization_Click;
            btnAutorization.MouseEnter += btnAutorization_MouseEnter;
            btnAutorization.MouseLeave += btnAutorization_MouseLeave;
            // 
            // btnRegistry
            // 
            btnRegistry.Cursor = Cursors.Hand;
            btnRegistry.FlatStyle = FlatStyle.Popup;
            btnRegistry.Font = new Font("Bookman Old Style", 9F);
            btnRegistry.Location = new Point(104, 128);
            btnRegistry.Margin = new Padding(3, 4, 3, 4);
            btnRegistry.Name = "btnRegistry";
            btnRegistry.Size = new Size(172, 32);
            btnRegistry.TabIndex = 3;
            btnRegistry.Text = "Зарегистрироваться";
            btnRegistry.UseVisualStyleBackColor = true;
            btnRegistry.Click += btnRegistry_Click;
            btnRegistry.MouseEnter += btnRegistry_MouseEnter;
            btnRegistry.MouseLeave += btnRegistry_MouseLeave;
            // 
            // Autorization
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 255);
            ClientSize = new Size(288, 182);
            Controls.Add(btnRegistry);
            Controls.Add(btnAutorization);
            Controls.Add(tbPassword);
            Controls.Add(tbLogin);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Autorization";
            Text = "Авторизация";
            FormClosing += Autorization_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbLogin;
        private TextBox tbPassword;
        private Button btnAutorization;
        private Button btnRegistry;
    }
}