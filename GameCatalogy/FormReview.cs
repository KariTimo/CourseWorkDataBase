using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCatalogy
{
    public partial class FormReview : Form
    {
        public FormReview(OwnLibrary ol)
        {
            InitializeComponent();
            ownLibrary = ol;
        }
        OwnLibrary ownLibrary;
        NpgsqlConnection conn;
        NpgsqlDataReader dr;
        NpgsqlCommand cmd;
        DataTable dt;
        string command;
        string connectionString;
        public int IdGame, IdUser;
        public string tag;

        public void ConnectToDB()
        {
            connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=postgres;Database=GameCatalogyDB;";
            conn = new NpgsqlConnection(connectionString);
            conn.Open();
        }

        public bool CheckReview(string review, int rating, int idgame, int iduser)
        {
            ConnectToDB();
            int check = 0;
            command = $"select 1 from t_game_reviews where id_game = {idgame} and review = '{review}' and rating = {rating} and id_user = {iduser}";
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

        private void button1_Click(object sender, EventArgs e)
        {

            int rating = trackBar1.Value;
            string review = textBox1.Text;
            try
            {
                if (tag == "insert")
                {
                    if (CheckReview(review, rating, IdGame, IdUser))
                    {
                        command = $"insert into t_game_reviews (id_user, id_game, review, rating) values ({IdUser}, {IdGame}, '{review}', {rating})";
                        ConnectToDB();
                        cmd = new NpgsqlCommand(command, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    else
                        MessageBox.Show("This review already exists");
                }
                else if (tag == "update")
                {
                    command = $"update t_game_reviews set review = '{review}', rating = {rating} where id_game = {IdGame} and id_user = {IdUser}";
                    ConnectToDB();
                    cmd = new NpgsqlCommand(command, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (tag == "delete")
                {
                    command = $"delete from t_game_reviews where id_game = {IdGame} and id_user = {IdUser} and review = '{review}' and rating = {rating}";
                    ConnectToDB();
                    cmd = new NpgsqlCommand(command, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }



                MessageBox.Show("Success");
            }
            catch { MessageBox.Show("Error"); }
            this.Close();
        }


        private void FormReview_Load(object sender, EventArgs e)
        {
            if (tag == "delete" || tag == "update")
            {

            }
            if (tag == "delete")
            {
                trackBar1.Enabled = false;
                textBox1.Enabled = false;
            }
        }

        private void FormReview_FormClosing(object sender, FormClosingEventArgs e)
        {
            ownLibrary.Show();
            ownLibrary.CheckReview(IdGame, IdUser);
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.CornflowerBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = BackColor;
        }
    }
}
