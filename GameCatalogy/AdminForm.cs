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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Design;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace GameCatalogy
{
    public partial class AdminForm : Form
    {
        public AdminForm(Autorization autor)
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
        string tag, table, namecol;
        int CurRow = 0;
        int id = 0;

        private void AdminForm_Load(object sender, EventArgs e)
        {
            //ViewTables();
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


        private void cbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            table = cbTables.Text;
            ConnectToDB();
            command = $"select * from {table}";
            SelectTable(command, dgvTable);

            if (table == "t_games")
            {
                btnInsert.Enabled = true;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;

            }
            if (table == "t_users")
            {
                btnInsert.Enabled = true;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
            }
            if (table == "t_developer")
            {
                btnInsert.Enabled = true;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
            }
            if (table == "t_genre_games")
            {
                btnInsert.Enabled = true;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;

            }
            if (table == "t_requirements")
            {
                btnInsert.Enabled = true;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
            }
            if (table == "t_game_reviews")
            {
                btnInsert.Enabled = true;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = false;
            }


        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            autorization.Show();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (table != null)
            {
                tag = "insert";
                AdminEditForm aef = new AdminEditForm(this);
                aef.tag = tag;
                aef.table = table;

                aef.Show();
                this.Hide();

            }



        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (table != null)
            {
                tag = "update";
                AdminEditForm aef = new AdminEditForm(this);
                aef.tag = tag;
                aef.table = table;
                aef.id = id;

                aef.Show();
                this.Hide();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (table != null)
            {
                tag = "delete";
                AdminEditForm aef = new AdminEditForm(this);
                aef.tag = tag;
                aef.table = table;
                aef.id = id;

                aef.Show();
                this.Hide();
            }
        }

        private void dgvTable_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTable.CurrentRow is not null)
            {
                CurRow = dgvTable.CurrentRow.Index;
                id = Convert.ToInt32(dgvTable.Rows[CurRow].Cells[0].Value);
            }
        }

        private void btnDelete_MouseEnter(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.CornflowerBlue;
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackColor = BackColor;
        }

        private void btnUpdate_MouseLeave(object sender, EventArgs e)
        {
            btnUpdate.BackColor = BackColor;
        }

        private void btnUpdate_MouseEnter(object sender, EventArgs e)
        {
            btnUpdate.BackColor = Color.CornflowerBlue;
        }

        private void btnInsert_MouseEnter(object sender, EventArgs e)
        {
            btnInsert.BackColor = Color.CornflowerBlue;
        }

        private void btnInsert_MouseLeave(object sender, EventArgs e)
        {
            btnInsert.BackColor = BackColor;
        }
    }
}
