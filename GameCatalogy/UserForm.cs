using Microsoft.VisualBasic.Logging;
using Npgsql;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace GameCatalogy
{
    public partial class UserForm : Form
    {
        public UserForm(Autorization autor)
        {
            InitializeComponent();
            autorization = autor;
        }

        Autorization autorization;
        public string login;
        NpgsqlConnection conn;
        NpgsqlDataReader dr;
        NpgsqlCommand cmd;
        DataTable dt;
        string command;
        string connectionString;
        int IdGame, IdUser;

        void MinusBalance(int balance, int price)
        {
            int nextval = balance - price;

            ConnectToDB();
            command = $"UPDATE t_bank SET balance = {nextval} WHERE id_acc = (select id_acc from t_users where id_user = {IdUser})";
            cmd = new NpgsqlCommand(command, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        bool CheckGame()
        {
            ConnectToDB();
            int check = 0;
            command = $"select 1 from t_library where id_user = {IdUser} and id_game = {IdGame}";
            cmd = new NpgsqlCommand(command, conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                check = reader.GetInt32(0);
            conn.Close();
            if (check == 1)
                return false;
            else
                return true;
        }

        bool TryToLoseBalance()//проверка хватит ли денег на игру
        {
            try
            {
                int price = 0;
                int balance = GetBalance();

                if (dgvGame.CurrentRow is not null)
                {
                    ConnectToDB();
                    int a = dgvGame.CurrentRow.Index;
                    command = $"select price from t_games where game = '{dgvGame.Rows[a].Cells[0].Value.ToString()}'";
                    cmd = new NpgsqlCommand(command, conn);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        price = reader.GetInt32(0);
                    conn.Close();
                }

                if (balance >= price)
                {
                    MinusBalance(balance, price);
                    return true;
                }
                else
                    return false;
            }
            catch { return false; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            if (CheckGame())
            {
                if (TryToLoseBalance())
                {

                    ConnectToDB();
                    command = $"insert into t_library (id_user, id_game) values ({IdUser}, {IdGame})";
                    cmd = new NpgsqlCommand(command, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    groupBox3.Text = $"Баланс: {GetBalance()}";
                    label1.Visible = true;
                    label1.Text = "Игра была добавлена в Вашу библиотеку!";
                }
                else
                    MessageBox.Show("Не хватает средств, пополните баланс");
            }
            else
                MessageBox.Show("Игра уже есть в Вашей библиотеке");
        }
        int GetBalance()
        {
            ConnectToDB();
            int check = 0;
            command = $"select b.balance from t_users u left join t_bank b on u.id_acc = b.id_acc where u.virtual_name = '{login}'";
            cmd = new NpgsqlCommand(command, conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                check = reader.GetInt32(0);
            conn.Close();
            return check;
        }

        public void GetIDGame(out int idgame)
        {

            idgame = 0;
            if (dgvGame.CurrentRow is not null)
            {
                ConnectToDB();
                idgame = 0;
                int a = dgvGame.CurrentRow.Index;
                command = $"select id_game from t_games where game = '{dgvGame.Rows[a].Cells[0].Value.ToString()}'";
                cmd = new NpgsqlCommand(command, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    idgame = reader.GetInt32(0);
                conn.Close();
            }

        }

        public void GetIDUser(out int iduser)
        {
            ConnectToDB();
            iduser = 0;
            command = $"select id_user from t_users where virtual_name = '{login}'";
            cmd = new NpgsqlCommand(command, conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                iduser = reader.GetInt32(0);
            conn.Close();
        }
        void GetRequirements(int id, out string OS, out string CPU, out string RAM, out string videocard, out string memory)
        {
            OS = "";
            CPU = "";
            RAM = "";
            videocard = "";
            memory = "";
            ConnectToDB();
            command = $"select r.OS, r.CPU, r.RAM, r.video_card, r.memory from t_requirements r right join t_games g on g.id_requirements = r.id_requirements where g.id_game = {id}";
            cmd = new NpgsqlCommand(command, conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                OS = reader.GetString(0);
                CPU = reader.GetString(1);
                RAM = reader.GetString(2);
                videocard = reader.GetString(3);
                memory = reader.GetString(4);
            }
            conn.Close();
        }

        public void ConnectToDB()
        {
            connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=postgres;Database=GameCatalogyDB;";
            conn = new NpgsqlConnection(connectionString);
            conn.Open();
        }

        public void SelectTable(string command, DataGridView dgv)
        {
            ConnectToDB();
            cmd = new NpgsqlCommand(command, conn);
            dt = new DataTable();
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            dgv.DataSource = dt;

            conn.Close();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            this.Text = login + " - подключен";
            groupBox3.Text = $"Баланс: {GetBalance()}";

            if (comboBox1.Text == "")
                comboBox2.Visible = false;
            command = "select g.game, d.name_developer, gen.genre, g.price from T_Games g join T_Developer d on g.id_developer = d.id_developer join T_Genre_Games gen on g.id_game_genre = gen.id_game_genre where g.state = 'Enabled'";
            SelectTable(command, dgvGame);
            GetIDUser(out IdUser);

            dgvGame.Columns[0].HeaderText = "Игра";
            dgvGame.Columns[1].HeaderText = "Разработчик";
            dgvGame.Columns[2].HeaderText = "Жанр";
            dgvGame.Columns[3].HeaderText = "Цена";

        }

        private void dgvGame_SelectionChanged(object sender, EventArgs e)
        {
            GetIDGame(out IdGame);
            string OS, CPU, RAM, videocard, memory;
            GetRequirements(IdGame, out OS, out CPU, out RAM, out videocard, out memory);

            tbOS.Text = OS;
            tbCPU.Text = CPU;
            tbRAM.Text = RAM;
            tbVideo.Text = videocard;
            tbMemory.Text = memory;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                command = "select g.game, d.name_developer, gen.genre, g.price from T_Games g join T_Developer d on g.id_developer = d.id_developer join T_Genre_Games gen on g.id_game_genre = gen.id_game_genre where g.state = 'Enabled' order by g.price asc";
                SelectTable(command, dgvGame);
            }
            else
            {
                command = "select g.game, d.name_developer, gen.genre, g.price from T_Games g join T_Developer d on g.id_developer = d.id_developer join T_Genre_Games gen on g.id_game_genre = gen.id_game_genre where g.state = 'Enabled'";
                SelectTable(command, dgvGame);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;
            comboBox2.Visible = true;
            comboBox2.Items.Clear();
            comboBox2.Text = string.Empty;
            
            int count, i;
            if (comboBox1.Text.ToString() == "Автор")
            {               
                checkBox1.Checked = false;
                i = 0;
                count = 0;
                ConnectToDB();
                command = $"select distinct count(d.name_developer) from T_Games g join T_Developer d on g.id_developer = d.id_developer where g.state = 'Enabled'";
                cmd = new NpgsqlCommand(command, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    count = reader.GetInt32(0);
                }
                conn.Close();

                ConnectToDB();
                command = $"select distinct d.name_developer from T_Games g join T_Developer d on g.id_developer = d.id_developer where g.state = 'Enabled' order by d.name_developer asc";
                cmd = new NpgsqlCommand(command, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() && i != count - 1)
                {
                    comboBox2.Items.Add(reader.GetString(0));
                    i++;
                }
                conn.Close();

            }
            else if (comboBox1.Text.ToString() == "Жанр")
            {
                checkBox1.Checked = false;
                i = 0;
                count = 0;
                ConnectToDB();
                command = $"select distinct count(gen.genre) from T_Games g join T_Genre_Games gen on g.id_game_genre = gen.id_game_genre where g.state = 'Enabled'";
                cmd = new NpgsqlCommand(command, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    count = reader.GetInt32(0);
                }
                conn.Close();

                ConnectToDB();
                command = $"select distinct gen.genre from T_Games g join T_Genre_Games gen on g.id_game_genre = gen.id_game_genre where g.state = 'Enabled' order by gen.genre asc";
                cmd = new NpgsqlCommand(command, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() && i != count - 1)
                {
                    comboBox2.Items.Add(reader.GetString(0));
                    i++;
                }
                conn.Close();
            }
            else if (comboBox1.Text.ToString() == " ")
            {
                checkBox1.Enabled = true;
                comboBox2.Visible = false;
                comboBox2.Items.Clear();
                comboBox2.Text = string.Empty;
                command = $"select g.game, d.name_developer, gen.genre, g.price from T_Games g join T_Developer d on g.id_developer = d.id_developer join T_Genre_Games gen on g.id_game_genre = gen.id_game_genre where g.state = 'Enabled'";
                SelectTable(command, dgvGame);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;
            string selrow = comboBox2.Text.ToString();
            if (comboBox1.Text.ToString() == "Автор")
            {
                command = $"select g.game, d.name_developer, gen.genre, g.price from T_Games g join T_Developer d on g.id_developer = d.id_developer join T_Genre_Games gen on g.id_game_genre = gen.id_game_genre where d.id_developer = (select id_developer from t_developer where name_developer = '{selrow}') and g.state = 'Enabled' order by price asc";
                SelectTable(command, dgvGame);

            }
            else if (comboBox1.Text.ToString() == "Жанр")
            {
                command = $"select g.game, d.name_developer, gen.genre, g.price from T_Games g join T_Developer d on g.id_developer = d.id_developer join T_Genre_Games gen on g.id_game_genre = gen.id_game_genre where gen.id_game_genre = (select id_game_genre from t_genre_games where genre = '{selrow}') and g.state = 'Enabled' order by price asc";
                SelectTable(command, dgvGame);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OwnLibrary ol = new OwnLibrary(this);
            ol.login = login;

            ol.Show();
            this.Hide();
        }

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            autorization.Show();
        }

        void AddBalance(int iduser, int balance)
        {
            int idacc = 0;

            ConnectToDB();
            command = $"select id_acc from t_users where id_user = {IdUser}";
            cmd = new NpgsqlCommand(command, conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                idacc = reader.GetInt32(0);
            }
            conn.Close();
            ConnectToDB();
            command = $"update t_bank set balance = balance + {balance} where id_acc = {idacc}";
            cmd = new NpgsqlCommand(command, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            groupBox3.Text = $"Баланс: {GetBalance()}";




        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(tbBalance.Text) > 0)
                {
                    AddBalance(IdUser, Convert.ToInt32(tbBalance.Text));
                }
                tbBalance.Clear();
            }
            catch 
            {
                MessageBox.Show("Введен неккоректный символ");
            }
        }

        #region style
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.CornflowerBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = BackColor;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.CornflowerBlue;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = BackColor;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.CornflowerBlue;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = BackColor;
        }
        #endregion
    }
}
