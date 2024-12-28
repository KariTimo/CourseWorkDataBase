using Npgsql;
using System.Data;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GameCatalogy
{
    public partial class Autorization : Form
    {
        public Autorization()
        {
            InitializeComponent();
        }

        NpgsqlConnection conn;
        NpgsqlDataReader dr;
        NpgsqlCommand cmd;
        DataTable dt;
        string command;
        string connectionString;
        public string login, password;

        public void ConnectToDB()
        {
            connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=postgres;Database=GameCatalogyDB;";
            conn = new NpgsqlConnection(connectionString);
            conn.Open();
        }

        public void CheckUser(string login, string password)
        {
            ConnectToDB();
            int check = 0;
            command = $"select 1 from tsysuser where login = '{login}' and password = '{password}'";
            cmd = new NpgsqlCommand(command, conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                check = reader.GetInt32(0);
            conn.Close();
            if (check != 1)
                MessageBox.Show("Пользователь не зарегестрирован");
            else
                CheckRole(login, password);
        }

        public void CheckRole(string login, string password)
        {
            UserForm uf = new UserForm(this);
            uf.login = login;
            AdminForm af = new AdminForm(this);
            ConnectToDB();


            string role = "";
            command = $"select role from TSysUser where login = '{login}' and password = '{password}'";
            cmd = new NpgsqlCommand(command, conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                role = reader.GetString(0);
            conn.Close();

            if (role == "user")
            {
                this.Hide();
                uf.Show();
            }
            else if (role == "admin")
            {
                this.Hide();
                af.Show();
            }
            else
                MessageBox.Show("Данного аккаунта не существует. Зарегестрируйтесь!");
        }

        private void btnAutorization_Click(object sender, EventArgs e)
        {
            login = tbLogin.Text.ToLower();
            password = tbPassword.Text.ToLower();
            CheckUser(login, password);
        }

        private void Autorization_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
            Application.Exit();
        }

        private void btnRegistry_Click(object sender, EventArgs e)
        {
            FormRegistry fr = new FormRegistry(this);
            fr.Show();
            this.Hide();
        }

        void DelSpace(string input, out string output)
        {
            output = input.Replace(" ", "");
        }
                    #region Style
                    private void btnAutorization_MouseEnter(object sender, EventArgs e)
        {
            btnAutorization.BackColor = Color.CornflowerBlue;
        }

        private void btnAutorization_MouseLeave(object sender, EventArgs e)
        {
            btnAutorization.BackColor = BackColor;
        }

        private void btnRegistry_MouseEnter(object sender, EventArgs e)
        {
            btnRegistry.BackColor = Color.CornflowerBlue;
        }

        private void btnRegistry_MouseLeave(object sender, EventArgs e)
        {
            btnRegistry.BackColor = BackColor;
        }
        #endregion
    }
}

