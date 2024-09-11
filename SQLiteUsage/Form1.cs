using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLiteUsage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection.CreateFile("MySQLite");
                label1.Text = "Database created.";
            }
            catch (Exception)
            {
                label1.Text = "Database couldn't created.";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLiteConnection sqliteConnection = new SQLiteConnection("DataSource=" + "MySQLite" + "; Version = 3;");
            sqliteConnection.Open();
            if (sqliteConnection.State == ConnectionState.Open)
            {
                string sqlRequest = @"create table projects(id INTEGER PRIMARY KEY AUTOINCREMENT, name varchar(25) NOT NULL, projectCount int(25) NOT NULL);";
                SQLiteCommand sqliteCommand = new SQLiteCommand(sqlRequest, sqliteConnection);
                sqliteCommand.ExecuteNonQuery();
                sqliteConnection.Close();
                label1.Text = "Table created.";
            }
            else
            {
                label1.Text = "Table couldn't created.";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            SQLiteCommand sqliteCommand = new SQLiteCommand();
            SQLiteConnection sqliteConnection = new SQLiteConnection("DataSource=" + "MySQLite" + "; Version = 3;");
            sqliteConnection.Open();
            if (sqliteConnection.State == ConnectionState.Open)
            {
                sqliteCommand.Connection = sqliteConnection;
                sqliteCommand.CommandText = "select * from projects";
                sqliteCommand.ExecuteNonQuery();
                SQLiteDataReader reader = sqliteCommand.ExecuteReader();
                while (reader.Read())
                    listBox1.Items.Add("id= " + reader["id"].ToString() + ",     name= " + reader["name"].ToString() + ",     project count= " + reader["projectCount"].ToString());
                sqliteConnection.Close();

                label1.Text = "List Data";
            }
            else
            {
                label1.Text = "List Error";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int projectCountValue = Convert.ToInt32(textBox1.Text);

            SQLiteCommand sqliteCommand = new SQLiteCommand();
            SQLiteConnection sqliteConnection = new SQLiteConnection("DataSource=" + "MySQLite" + "; Version = 3;");
            sqliteConnection.Open();
            if (sqliteConnection.State == ConnectionState.Open)
            {
                sqliteCommand.Connection = sqliteConnection;
                sqliteCommand.CommandText = "insert into projects(name, projectCount) values ('" + textBox2.Text + "','" + projectCountValue + "')";
                sqliteCommand.ExecuteNonQuery();
                sqliteConnection.Close();

                label1.Text = "İnsert Data";
            }
            else
            {
                label1.Text = "İnsert Error";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SQLiteCommand sqliteCommand = new SQLiteCommand();
            SQLiteConnection sqliteConnection = new SQLiteConnection("DataSource=" + "MySQLite" + "; Version = 3;");
            sqliteConnection.Open();
            if (sqliteConnection.State == ConnectionState.Open)
            {
                sqliteCommand.Connection = sqliteConnection;
                sqliteCommand.CommandText = "update projects set name='" + textBox2.Text + "' where ID=" + textBox1.Text + "";
                sqliteCommand.ExecuteNonQuery();
                sqliteConnection.Close();

                label1.Text = "Update Data";
            }
            else
            {
                label1.Text = "Update Error";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SQLiteCommand sqliteCommand = new SQLiteCommand();
            SQLiteConnection sqliteConnection = new SQLiteConnection("DataSource=" + "MySQLite" + "; Version = 3;");
            sqliteConnection.Open();
            if (sqliteConnection.State == ConnectionState.Open)
            {
                sqliteCommand.Connection = sqliteConnection;
                sqliteCommand.CommandText = "delete from projects where ID=" + textBox1.Text + "";
                sqliteCommand.ExecuteNonQuery();
                sqliteConnection.Close();

                label1.Text = "Delete Data";
            }
            else
            {
                label1.Text = "Delete Error";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
