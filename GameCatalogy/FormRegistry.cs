using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCatalogy
{
    public partial class FormRegistry : Form
    {
        public FormRegistry(Autorization autor)
        {
            InitializeComponent();
            autorization = autor;
        }
        Autorization autorization;
        NpgsqlConnection conn;
        NpgsqlDataReader dr;
        NpgsqlCommand cmd;
        DataTable dt;
        string command;
        string connectionString;
        object avatar;
        string virtname, realname, location, password;
        int id_acc;


        public void ConnectToDB()
        {
            connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=postgres;Database=GameCatalogyDB;";
            conn = new NpgsqlConnection(connectionString);
            conn.Open();
        }

        private void FormRegistry_FormClosing(object sender, FormClosingEventArgs e)
        {
            autorization.Show();
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
            {
                MessageBox.Show("Такой пользователь уже существует");
                return false;
            }

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

        void DelSpace(string input, out string output)
        {
            output = input.Replace(" ", "");
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

            DelSpace(tbVirtName.Text.ToLower(), out virtname);
            DelSpace(tbRealName.Text.ToLower(), out realname);
            DelSpace(tbLocation.Text.ToLower(), out location);
            DelSpace(tbPassword.Text.ToLower(), out password);

            if (!string.IsNullOrWhiteSpace(virtname) &&
                !string.IsNullOrWhiteSpace(realname) &&
                !string.IsNullOrWhiteSpace(location) &&
                !string.IsNullOrWhiteSpace(password))
            {
                if (CheckUser(virtname))
                {
                    string path = "";
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Title = "Profile avatar selection";
                    if (openFileDialog.ShowDialog() == DialogResult.OK) { path = openFileDialog.FileName; }
                    else
                    {
                        string DIR = Directory.GetCurrentDirectory();
                        path = Path.Combine(DIR, @"imgnull.jpg");
                    }
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
                    MessageBox.Show("Профиль добавлен");
                 }
            }
        else
        {
            MessageBox.Show("Заполните все поля!");
        }
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
