using Microsoft.VisualBasic.ApplicationServices;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace GameCatalogy
{
    public partial class OwnLibrary : Form
    {
        public OwnLibrary(UserForm uf)
        {
            InitializeComponent();
            userForm = uf;
        }
        UserForm userForm;
        public string login;
        NpgsqlConnection conn;
        NpgsqlDataReader dr;
        NpgsqlCommand cmd;
        DataTable dt;
        string command;
        string connectionString;
        int IdGame, IdUser;

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

        public void CheckReview(int idgame, int iduser)
        {

            if (cbAllReview.Checked)
            {
                command = $"select u.virtual_name, rev.review, rev.rating from t_game_reviews rev join t_users u on rev.id_user = u.id_user where id_game = {idgame}";
                SelectTable(command, dgvReviews);
                dgvReviews.Columns[0].HeaderText = "Ник";
                dgvReviews.Columns[1].HeaderText = "Отзыв";
                dgvReviews.Columns[2].HeaderText = "Рейтинг";
            }
            else
            {
                command = $"select review, rating from t_game_reviews where id_game = {idgame} and id_user = {iduser}";
                SelectTable(command, dgvReviews);

                dgvReviews.Columns[0].HeaderText = "Отзыв";
                dgvReviews.Columns[1].HeaderText = "Рейтинг";
            }


        }

        void GetDataReview(DataGridView dgv, out string review, out int rating)
        {
            review = "";
            rating = 0;
            if (dgv.CurrentRow is not null)
            {
                int a = dgv.CurrentRow.Index;
                review = dgv.Rows[a].Cells[0].Value.ToString();
                rating = Convert.ToInt32(dgv.Rows[a].Cells[1].Value);
            }
        }
        public void GetIDGame(out int idgame)
        {
            idgame = 0;
            if (dgvGameLibrary.CurrentRow is not null)
            {
                ConnectToDB();
                int a = dgvGameLibrary.CurrentRow.Index;
                command = $"select id_game from t_games where game = '{dgvGameLibrary.Rows[a].Cells[0].Value.ToString()}'";
                cmd = new NpgsqlCommand(command, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    idgame = reader.GetInt32(0);
                conn.Close();
            }
        }

        private void dgvGameLibrary_SelectionChanged(object sender, EventArgs e)
        {
            GetIDGame(out IdGame);
            CheckReview(IdGame, IdUser);
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

        private void OwnLibrary_Load(object sender, EventArgs e)
        {
            this.Text = "Моя библиотека";
            GetIDUser(out IdUser);
            command = $"SELECT g.game, d.name_developer, gen.genre FROM t_library l join t_games g on l.id_game = g.id_game join T_Developer d on g.id_developer = d.id_developer join T_Genre_Games gen on g.id_game_genre = gen.id_game_genre where l.id_user = {IdUser}";
            SelectTable(command, dgvGameLibrary);

            GetAvatar(pictureBox1);

            dgvGameLibrary.Columns[0].HeaderText = "Игра";
            dgvGameLibrary.Columns[1].HeaderText = "Разработчик";
            dgvGameLibrary.Columns[2].HeaderText = "Жанр";

        }

        private void OwnLibrary_FormClosing(object sender, FormClosingEventArgs e)
        {
            userForm.Show();
        }

        void GetAvatar(PictureBox picture)
        {
            connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=postgres;Database=GameCatalogyDB;";
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            string sQL = $"SELECT avatar from t_users WHERE id_user = {IdUser}";
            using (var command = new NpgsqlCommand(sQL, conn))
            {
                byte[] productImageByte = null;
                conn.Open();
                var rdr = command.ExecuteReader();
                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(0))
                        productImageByte = (byte[])rdr[0];
                }
                rdr.Close();
                if (productImageByte != null)
                {
                    using (MemoryStream productImageStream = new MemoryStream(productImageByte))
                    {
                        ImageConverter imageConverter = new ImageConverter();
                        pictureBox1.Image = imageConverter.ConvertFrom(productImageByte) as Image;
                    }
                }
            }
            conn.Close();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            
            connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=postgres;Database=GameCatalogyDB;";
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("UPDATE t_users SET avatar = (@image) WHERE id_user = @iduser", conn);
            NpgsqlParameter sqlParameter = new NpgsqlParameter("image", DbType.Binary);

            string path = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK) { path = openFileDialog.FileName; }
            if (path != "")
            {
                Image image = Image.FromFile(path);
                MemoryStream memoryStream = new MemoryStream();
                image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
                sqlParameter.Value = memoryStream.ToArray();
                memoryStream.Dispose();
                cmd.Parameters.Add(sqlParameter);
                sqlParameter = new NpgsqlParameter("iduser", IdUser);
                cmd.Parameters.Add(sqlParameter);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                NpgsqlDataReader dr = da.SelectCommand.ExecuteReader();
                conn.Close();

                GetAvatar(pictureBox1);
            }

        }

        void Review(string tag)
        {
            try
            {
                FormReview fr = new FormReview(this);
                string review;
                int rating;
                GetDataReview(dgvReviews, out review, out rating);
                fr.textBox1.Text = review;
                fr.trackBar1.Value = rating;
                fr.IdGame = IdGame;
                fr.IdUser = IdUser;
                fr.tag = tag;
                fr.Show();
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Нет отзыва для удаления");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormReview formReview = new FormReview(this);
            try
            {
                formReview.IdGame = IdGame;
                formReview.IdUser = IdUser;
                formReview.tag = "insert";
                formReview.Show();
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Нет отзыва для удаления");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Review("update");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Review("delete");
        }

        private void dgvGameLibrary_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvGameLibrary.ReadOnly = true;
        }

        private void cbAllReview_CheckedChanged(object sender, EventArgs e)
        {
            CheckReview(IdGame, IdUser);

        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.CornflowerBlue;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = BackColor;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.CornflowerBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = BackColor;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.CornflowerBlue;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = BackColor;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.CornflowerBlue;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = BackColor;
        }
    }
}
