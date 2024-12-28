using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCatalogy
{
    public partial class AdminEditForm : Form
    {
        public AdminEditForm(AdminForm af)
        {
            InitializeComponent();
            adminForm = af;
        }
        AdminForm adminForm;
        NpgsqlConnection conn;
        NpgsqlDataReader dr;
        NpgsqlCommand cmd;
        DataTable dt;
        string command;
        string connectionString;
        public string tag, table;
        public int id;

        private void AdminEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            adminForm.Show();
        }

        string[] tabl;
        string[] typ;

        public void ConnectToDB()
        {
            connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=postgres;Database=GameCatalogyDB;";
            conn = new NpgsqlConnection(connectionString);
            conn.Open();
        }

        //void ViewData(string tab)
        //{
        //    int count = 0;
        //    int i = 0;
        //    ConnectToDB();
        //    command = $"SELECT count(column_name) FROM information_schema.columns WHERE table_name = '{tab}' AND table_schema = 'public'";
        //    cmd = new NpgsqlCommand(command, conn);
        //    var reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        count = reader.GetInt32(0);
        //    }
        //    conn.Close();

        //    tabl = new string[count];
        //    typ = new string[count];
        //    ConnectToDB();
        //    command = $"SELECT column_name, data_type FROM information_schema.columns WHERE table_name = '{tab}' AND table_schema = 'public'";
        //    cmd = new NpgsqlCommand(command, conn);
        //    reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        tabl[i] = reader.GetString(0);
        //        typ[i] = reader.GetString(1);
        //        i++;
        //    }
        //    conn.Close();
        //}


        void GetItems(ComboBox cb, string tab, string column)
        {
            cb.Items.Clear();
            int i = 0;
            int count = 0;
            ConnectToDB();
            command = $"SELECT count(*) FROM {tab}";
            cmd = new NpgsqlCommand(command, conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                count = reader.GetInt32(0);
            }
            conn.Close();

            ConnectToDB();
            command = $"SELECT {column} FROM {tab}";
            cmd = new NpgsqlCommand(command, conn);
            reader = cmd.ExecuteReader();
            while (reader.Read() && i != count - 1)
            {
                cb.Items.Add(reader.GetString(0));
                i++;
            }
            conn.Close();
        }



        void ComponentsVisible(string tabl, string tagg)
        {

            if (tabl == "t_users")
            {
                this.Text = $"Edit table {tabl}";
                label1.Visible = true;
                label1.Text = "virtual_name";
                textBox1.Visible = true;
                label2.Visible = true;
                label2.Text = "real_name";
                textBox2.Visible = true;
                label3.Visible = true;
                label3.Text = "location";
                textBox3.Visible = true;

            }
            else if (tabl == "t_games" && (tag == "update" || tag == "delete"))
            {
                this.Text = $"Edit table {tabl}";

                label1.Visible = true;
                label1.Text = "game";
                textBox1.Visible = true;
                label2.Visible = false;
                label2.Text = "developer";
                comboBox2.Visible = false;
                label3.Visible = true;
                label3.Text = "price";
                textBox3.Visible = true;
                label4.Visible = false;
                label4.Text = "genre";
                comboBox4.Visible = false;

            }
            else if (tabl == "t_games" && (tag == "insert"))
            {
                this.Text = $"Edit table {tabl}";

                label1.Visible = true;
                label1.Text = "game";
                textBox1.Visible = true;
                label2.Visible = true;
                label2.Text = "developer";
                comboBox2.Visible = true;
                GetItems(comboBox2, "t_developer", "name_developer");
                label3.Visible = true;
                label3.Text = "price";
                textBox3.Visible = true;
                label4.Visible = true;
                label4.Text = "genre";
                comboBox4.Visible = true;
                GetItems(comboBox4, "t_genre_games", "genre");
            }
            else if (tabl == "t_developer")
            {
                this.Text = $"Edit table {tabl}";

                label1.Visible = true;
                label1.Text = "name_developer";
                textBox1.Visible = true;

            }
            else if (tabl == "t_genre_games")
            {
                this.Text = $"Edit table {tabl}";

                label1.Visible = true;
                label1.Text = "genre";
                textBox1.Visible = true;

            }
            else if (tabl == "t_requirements")
            {
                this.Text = $"Edit table {tabl}";

                label1.Visible = true;
                label1.Text = "OS";
                textBox1.Visible = true;
                label2.Visible = true;
                label2.Text = "CPU";
                textBox2.Visible = true;
                label3.Visible = true;
                label3.Text = "RAM";
                textBox3.Visible = true;
                label4.Visible = true;
                label4.Text = "video_card";
                textBox4.Visible = true;
                label5.Visible = true;
                label5.Text = "memory";
                textBox5.Visible = true;
            }
            else if (tabl == "t_game_reviews" && tagg == "delete")
            {
                this.Text = $"Edit table {tabl}";
                label1.Visible = true;
                label1.Text = "game";
                comboBox1.Visible = true;
                GetItems(comboBox1, "t_games", "game");
                comboBox1.Enabled = false;
                label2.Visible = true;
                label2.Text = "user";
                comboBox2.Visible = true;
                GetItems(comboBox2, "t_users", "virtual_name");
                comboBox2.Enabled = false;
                label3.Visible = true;
                label3.Text = "review";
                textBox3.Visible = true;
                textBox3.Enabled = false;
                label4.Visible = true;
                label4.Text = "rating";
                textBox4.Visible = true;
                textBox4.Enabled = false;
            }

        }

        void GetData(string tabl, int idcol)
        {

            string game = "";
            string develop = "";
            int Idevelop = 0;
            int price = 0;
            string genre = "";
            int Igenre = 0;
            if (tabl == "t_games" && (tag == "update" || tag == "delete"))
            {
                ConnectToDB();
                command = $"select game, id_developer, price, id_game_genre from {tabl} where id_game = {idcol}";
                cmd = new NpgsqlCommand(command, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    game = reader.GetString(0);
                    Idevelop = reader.GetInt32(1);
                    price = reader.GetInt32(2);
                    Igenre = reader.GetInt32(3);
                }
                conn.Close();

                ConnectToDB();
                command = $"select name_developer from t_developer where id_developer = {Idevelop}";
                cmd = new NpgsqlCommand(command, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    develop = reader.GetString(0);
                }
                conn.Close();

                ConnectToDB();
                command = $"select genre from t_genre_games where id_game_genre = {Igenre}";
                cmd = new NpgsqlCommand(command, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    genre = reader.GetString(0);
                }
                conn.Close();

            }
            textBox1.Text = game;
            comboBox2.Text = develop;
            textBox3.Text = price.ToString();
            comboBox4.Text = genre.ToString();

        }

        private void AdminEditForm_Load(object sender, EventArgs e)
        {
            //ViewData(table);
            ComponentsVisible(table, tag);
            GetData(table, id);
        }

        void CreateAcc(out int idacc)
        {

            string acc = "";
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                acc += rnd.Next(1000, 9999);
            }


            ConnectToDB();
            int check = 0;
            command = $"select 1 from t_bank where acc = '{acc}'";
            cmd = new NpgsqlCommand(command, conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                check = reader.GetInt32(0);
            conn.Close();

            if (check != 1)
            {
                ConnectToDB();
                command = $"insert into t_bank (acc) values ('{acc}')";
                cmd = new NpgsqlCommand(command, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            ConnectToDB();
            idacc = 0;
            command = $"select id_acc from t_bank where acc = '{acc}'";
            cmd = new NpgsqlCommand(command, conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
                idacc = reader.GetInt32(0);
            conn.Close();

        }

        bool CheckUser(string login)
        {
            ConnectToDB();
            int check = 0;
            int check1 = 0;
            command = $"select 1 from t_users where virtual_name = '{login}'";
            cmd = new NpgsqlCommand(command, conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                check = reader.GetInt32(0);
            conn.Close();
            if (check == 1)
                return false;
            else
            {
                ConnectToDB();
                command = $"select 1 from tsysuser where login = '{login}'";
                cmd = new NpgsqlCommand(command, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    check1 = reader.GetInt32(0);
                if (check1 == 1)
                    return false;
                else
                    return true;
            }

        }

        bool CheckGame(string game, int develop, int price, int genre, int requirement)
        {
            int check = 0;
            ConnectToDB();
            command = $"select 1 from t_games where game = '{game}' and id_developer = {develop} and price = {price} and id_game_genre = {genre} and id_requirements = {requirement}";
            cmd = new NpgsqlCommand(command, conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                check = reader.GetInt32(0);
            conn.Close();
            if (check == 1) return true;
            else return false;
        }

        bool CheckDeveloper(string develop)
        {
            int check = 0;
            ConnectToDB();
            command = $"select 1 from t_developer where name_developer = '{develop}'";
            cmd = new NpgsqlCommand(command, conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                check = reader.GetInt32(0);
            conn.Close();
            if (check == 1) return true;
            else return false;
        }

        bool CheckGenre(string genre)
        {
            int check = 0;
            ConnectToDB();
            command = $"select 1 from t_genre_games where genre = '{genre}'";
            cmd = new NpgsqlCommand(command, conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                check = reader.GetInt32(0);
            conn.Close();
            if (check == 1) return true;
            else return false;
        }

        bool CheckRequirement(string OS, string CPU, int RAM, string videocard, int memory)
        {
            int check = 0;
            ConnectToDB();
            command = $"select 1 from t_requirements where OS = '{OS}' and CPU = '{CPU}' and video_card = '{videocard}' and RAM = {RAM} and memory = {memory}";
            cmd = new NpgsqlCommand(command, conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                check = reader.GetInt32(0);
            conn.Close();
            if (check == 1) return true;
            else return false;
        }


        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {

                if (tag == "insert")
                {
                    if (table == "t_users" && textBox1.Text != null && textBox2.Text != null && textBox3.Text != null)
                    {
                        string virtname, realname, location, password;
                        int id_acc;

                        virtname = textBox1.Text;
                        realname = textBox2.Text;
                        location = textBox3.Text;
                        password = virtname;

                        try
                        {
                            if (CheckUser(virtname))
                            {
                                string path = "";
                                OpenFileDialog openFileDialog = new OpenFileDialog();
                                openFileDialog.Title = "Profile avatar selection";
                                if (openFileDialog.ShowDialog() == DialogResult.OK) { path = openFileDialog.FileName; }

                                FileStream pgFileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                                BinaryReader pgReader = new BinaryReader(new BufferedStream(pgFileStream));
                                byte[] ImgByteA = pgReader.ReadBytes(Convert.ToInt32(pgFileStream.Length));
                                var con = new NpgsqlConnection(connectionString);
                                string sQL = "insert into t_users (virtual_name, real_name, location_user, id_acc, avatar) VALUES (@virtual_name, @real_name, @location_user, @id_acc, @Image)";
                                var com = new NpgsqlCommand(sQL, con);

                                NpgsqlParameter param = com.CreateParameter();
                                param.ParameterName = "@virtual_name";
                                param.Value = virtname;
                                com.Parameters.Add(param);
                                param = com.CreateParameter();
                                param.ParameterName = "@real_name";
                                param.Value = realname;
                                com.Parameters.Add(param);
                                param = com.CreateParameter();
                                param.ParameterName = "@location_user";
                                param.Value = location;
                                com.Parameters.Add(param);
                                CreateAcc(out id_acc);
                                param = com.CreateParameter();
                                param.ParameterName = "@id_acc";
                                param.Value = id_acc;
                                com.Parameters.Add(param);
                                param = com.CreateParameter();
                                param.ParameterName = "@Image";
                                param.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Bytea;
                                param.Value = ImgByteA;
                                com.Parameters.Add(param);

                                con.Open();
                                com.ExecuteNonQuery();
                                con.Close();



                                ConnectToDB();
                                command = $"call AddSysUser('{virtname}', '{password}')";
                                cmd = new NpgsqlCommand(command, conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                                MessageBox.Show("Success");
                            }
                        }
                        catch { MessageBox.Show("error"); }

                    }
                    else if (table == "t_games" && textBox1.Text != null && textBox3.Text != null)
                    {
                        string game;
                        int develop = 0;
                        int price = 0;
                        int genre = 0;
                        int requirement = 0;

                        game = textBox1.Text;
                        price = Convert.ToInt32(textBox3.Text);


                        try
                        {

                            ConnectToDB();
                            command = $"select id_developer from t_developer where name_developer = '{comboBox2.Text}'";
                            cmd = new NpgsqlCommand(command, conn);
                            var reader = cmd.ExecuteReader();
                            while (reader.Read())
                                develop = reader.GetInt32(0);
                            conn.Close();

                            ConnectToDB();
                            command = $"select id_game_genre from t_genre_games where genre = '{comboBox4.Text}'";
                            cmd = new NpgsqlCommand(command, conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                                genre = reader.GetInt32(0);
                            conn.Close();

                            int countreq = 0;
                            ConnectToDB();
                            command = $"select count(*) from t_requirements";
                            cmd = new NpgsqlCommand(command, conn);
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                                countreq = reader.GetInt32(0);
                            conn.Close();

                            Random r = new Random();
                            requirement = r.Next(1, countreq - 1);

                            if (!CheckGame(game, develop, price, genre, requirement))
                            {

                                ConnectToDB();
                                command = $"insert into t_games (game, id_developer, price, id_game_genre, id_requirements) values ('{game}',{develop},{price},{genre},{requirement})";
                                cmd = new NpgsqlCommand(command, conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                                MessageBox.Show("Success");
                            }
                        }
                        catch { MessageBox.Show("error"); }


                    }
                    else if (table == "t_developer" && textBox1.Text != null)
                    {
                        string develop = textBox1.Text;

                        try
                        {
                            if (!CheckDeveloper(develop))
                            {
                                ConnectToDB();
                                command = $"insert into t_developer (name_developer) values ('{develop}')";
                                cmd = new NpgsqlCommand(command, conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                                MessageBox.Show("Success");
                            }
                        }
                        catch { MessageBox.Show("error"); }

                    }
                    else if (table == "t_genre_games" && textBox1.Text != null)
                    {


                        string genre = textBox1.Text;

                        try
                        {
                            if (!CheckGenre(genre))
                            {
                                ConnectToDB();
                                command = $"insert into t_genre_games (genre) values ('{genre}')";
                                cmd = new NpgsqlCommand(command, conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                                MessageBox.Show("Success");
                            }
                        }
                        catch { MessageBox.Show("error"); }

                    }
                    else if (table == "t_requirements" && textBox1.Text != null && textBox2.Text != null && textBox3.Text != null && textBox4.Text != null && textBox5.Text != null)
                    {
                        string OS = textBox1.Text;
                        string CPU = textBox2.Text;
                        int RAM = Convert.ToInt32(textBox3.Text);
                        string videocard = textBox4.Text;
                        int memory = Convert.ToInt32(textBox5.Text);

                        try
                        {
                            if (!CheckRequirement(OS, CPU, RAM, videocard, memory))
                            {
                                ConnectToDB();
                                command = $"insert into t_requirements (os, cpu, ram, video_card, memory) values ('{OS}', '{CPU}', {RAM}, '{videocard}', {memory})";
                                cmd = new NpgsqlCommand(command, conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                                MessageBox.Show("Success");
                            }
                        }
                        catch { MessageBox.Show("error"); }

                    }
                }
                else if (tag == "update")
                {
                    try
                    {
                        if (table == "t_games" && textBox1.Text != null && textBox3.Text != null)
                        {
                            string game = textBox1.Text;
                            int develop = 0;
                            int price = Convert.ToInt32(textBox3.Text);
                            int genre = 0;

                            ConnectToDB();
                            command = $"update {table} set game = '{game}', price = {price} where id_game = {id}";
                            cmd = new NpgsqlCommand(command, conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();

                            MessageBox.Show("Success");
                        }
                    }
                    catch { MessageBox.Show("error"); }
                }
                else if (tag == "delete")
                {
                    try
                    {
                        ConnectToDB();
                        if (table == "t_users")
                        {
                            int check = -1;
                            command = $"select 1 from t_library where id_user = {id}";
                            cmd = new NpgsqlCommand(command, conn);
                            var reader = cmd.ExecuteReader();
                            while (reader.Read())
                                check = reader.GetInt32(0);
                            conn.Close();
                            if (check == 1)
                            {
                                command = $"delete from t_library where id_user = {id}";
                                cmd = new NpgsqlCommand(command, conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                            command = $"delete from {table} where id_user = {id}";
                            cmd = new NpgsqlCommand(command, conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            command = $"delete from tsysuser where login = (select virtual_name from t_users where id_user = {id})";
                            cmd = new NpgsqlCommand(command, conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();

                        }
                        else if (table == "t_games")
                        {
                            //command = $"delete from {table} where id_game = {id}";
                            command = $"update t_games set state = 'Disabled' where id_game = {id}";
                            cmd = new NpgsqlCommand(command, conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();

                        }
                        else if (table == "t_developer")
                        {
                            command = $"delete from {table} where id_developer = {id}";
                            cmd = new NpgsqlCommand(command, conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();

                        }
                        else if (table == "t_genre_games")
                        {
                            command = $"delete from {table} where id_game_genre = {id}";
                            cmd = new NpgsqlCommand(command, conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();

                        }
                        else if (table == "t_requirements")
                        {
                            command = $"delete from {table} where id_requirements = {id}";
                            cmd = new NpgsqlCommand(command, conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                        else if (table == "t_game_reviews")
                        {
                            command = $"delete from {table} where id_game_review = {id}";
                            cmd = new NpgsqlCommand(command, conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                        MessageBox.Show("Success");
                    }
                    catch { MessageBox.Show("error"); }
                }
                else
                    MessageBox.Show("error");


                ConnectToDB();
                command = $"select * from {table}";
                adminForm.SelectTable(command, adminForm.dgvTable);
                this.Close();
            }
            catch { }
        }

        private void btnConfirm_MouseEnter(object sender, EventArgs e)
        {
            btnConfirm.BackColor = Color.CornflowerBlue;
        }

        private void btnConfirm_MouseLeave(object sender, EventArgs e)
        {
            btnConfirm.BackColor = BackColor;
        }
    }
}
