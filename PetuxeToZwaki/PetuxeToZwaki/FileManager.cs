using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data.OleDb;

namespace PetuxeToZwaki
{
    public class FileManager
    {
        /*
         *
         * ΣΕ ΣΧΟΛΙΟ ΕΙΝΑΙ ΓΙΑ ΑΠΟΘΗΚΕΥΣΗ ΑΡΧΕΙΩΝ
         *
         */


        private OleDbConnection connection;
        private string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=ZwakiDatabase.mdb;";

        public FileManager()
        {
            init();
        }


        private void init()
        {
            
                this.connection = new OleDbConnection(connectionString);
                connection.Open();

                String sql = "SELECT * FROM userInfo";
                OleDbCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;
                OleDbDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    if (!reader.GetString(0).Equals("") || reader.GetString(0) != null)
                    {
                        Program.getUsers().Add(new User(reader.GetString(0), (int) reader.GetInt32(1)));

                    }
                }
                reader.Close();
                connection.Close();
            
        }

        public void saveUsers()
        {
           
                this.connection = new OleDbConnection(connectionString);
                // Opening Connection
                connection.Open();

                // Better with stringbuilder -> StringBuilder str = new StringBuilder();
                // But we will use string

                String check = "SELECT * FROM userInfo WHERE username=[@user]";
                OleDbCommand read = connection.CreateCommand();
                read.CommandType = System.Data.CommandType.Text;
                read.CommandText = check;
                read.Parameters.AddWithValue("@user", Program.getUser().getName());
                OleDbDataReader reader = read.ExecuteReader();
                int k = 0;
                while(reader.Read())
                {
                    k++;
                }


               
                String sql = "";
                if (k == 0)
                {
                    sql = "INSERT INTO userInfo VALUES([@username], [@score])";

                }
                else
                {
                    sql = "UPDATE userInfo SET username=[@user], score=[@score] WHERE username=[@user]";
                }

                reader.Close();
                OleDbCommand command = connection.CreateCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = sql;
                command.Parameters.AddWithValue("@user", Program.getUser().getName());
                command.Parameters.AddWithValue("@score", Program.getUser().getScore());


                command.ExecuteNonQuery();
                connection.Close();

        }

        public OleDbConnection getConnection()
        {
            return connection;
        }

    }
}
