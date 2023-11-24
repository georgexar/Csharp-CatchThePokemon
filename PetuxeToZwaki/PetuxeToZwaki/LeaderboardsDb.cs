using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetuxeToZwaki
{
    public partial class LeaderboardsDb : Form
    {
        public LeaderboardsDb()
        {
            InitializeComponent();
        }

        private void LeaderboardsDb_Load(object sender, EventArgs e)
        {
            this.userInfoTableAdapter.Connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=ZwakiDatabase.mdb;";

            Program.getFileManager().getConnection().Open();
            OleDbCommand cmd = Program.getFileManager().getConnection().CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from userInfo";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            OleDbDataAdapter dp = new OleDbDataAdapter(cmd);
            dp.Fill(dt);
            dataGridView1.DataSource = dt;

            Program.getFileManager().getConnection().Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Program.orderPos < 1)
            {
                Program.orderPos++;
            }
            else
            {
                Program.orderPos = 0;
            }
            switch(Program.orderPos)
            {
                case 0:

                        
                        dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Descending);
                    
                    button1.Text = "Click to Order Ascending";
                    break;
                case 1:
       
                        dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
                    
                    button1.Text = "Click to Order Descending";
                    break;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("username LIKE '%{0}%'", textBox1.Text);
        }
    }
}
